using GamingHealth.Application.UseCases.GetPlayerById;
using GamingHealth.Application.UseCases.ListPlayers;
using Microsoft.AspNetCore.Mvc;

namespace GamingHealth.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly ListPlayersUseCase _listPlayersUseCase;
        private readonly GetPlayerByIdUseCase _getPlayerByIdUseCase;

        public PlayersController(
            ListPlayersUseCase listPlayersUseCase,
            GetPlayerByIdUseCase getPlayerByIdUseCase)
        {
            _listPlayersUseCase = listPlayersUseCase;
            _getPlayerByIdUseCase = getPlayerByIdUseCase;
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
    }
}