using GamingHealth.API.Requests;
using GamingHealth.Application.UseCases.GetPlayerById;
using GamingHealth.Application.UseCases.ListPlayers;
using GamingHealth.Application.UseCases.UpdatePlayerIncome;
using GamingHealth.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GamingHealth.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly ListPlayersUseCase _listPlayersUseCase;
        private readonly GetPlayerByIdUseCase _getPlayerByIdUseCase;
        private readonly UpdatePlayerIncomeUseCase _updatePlayerIncomeUseCase;

        public PlayersController(
            ListPlayersUseCase listPlayersUseCase,
            GetPlayerByIdUseCase getPlayerByIdUseCase,
            UpdatePlayerIncomeUseCase updatePlayerIncomeUseCase)
        {
            _listPlayersUseCase = listPlayersUseCase;
            _getPlayerByIdUseCase = getPlayerByIdUseCase;
            _updatePlayerIncomeUseCase = updatePlayerIncomeUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 20)
        {
            var result = await _listPlayersUseCase.ExecuteAsync(new ListPlayersInput
            {
                Page = page,
                PageSize = pageSize
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _getPlayerByIdUseCase.ExecuteAsync(new GetPlayerByIdInput
            {
                PlayerId = id
            });

            if (result is null)
                return NotFound(new { message = $"Player {id} não encontrado." });

            return Ok(result);
        }

        [HttpGet("test-income")]
        public IActionResult TestIncome()
        {
            var player = new Player();

            try
            {
                player.UpdateIncome(50000m);
                return Ok(new { message = "Income atualizado com sucesso.", income = player.Income });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao atualizar o income.", error = ex.Message });
            }
        }

        [HttpPatch("{id}/income")]
        public async Task<IActionResult> UpdateIncome(int id, [FromBody] UpdateIncomeRequest request)
        {
            var input = new UpdatePlayerIncomeInput
            {
                PlayerId = id,
                Income = request.Income
            };
            var result = await _updatePlayerIncomeUseCase.ExecuteAsync(input);
            return Ok(result);
        }
    }
}