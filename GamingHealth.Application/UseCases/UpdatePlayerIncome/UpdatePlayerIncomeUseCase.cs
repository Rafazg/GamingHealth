using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamingHealth.Application.DTOs;
using GamingHealth.Domain.Entities;
using GamingHealth.Domain.Interfaces;


namespace GamingHealth.Application.UseCases.UpdatePlayerIncome
{

    public class UpdatePlayerIncomeInput
    {
        public int PlayerId { get; set; }
        public decimal Income { get; set; }
    }
    public class UpdatePlayerIncomeUseCase
    {
        private readonly IPlayerRepository _repository;

        public UpdatePlayerIncomeUseCase(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<PlayerDto> ExecuteAsync(UpdatePlayerIncomeInput input)
        {
            var player = await _repository.GetByIdAsync(input.PlayerId);
            if (player == null)
            {
                throw new Exception("Entitie not found");
            }

            player.UpdateIncome(input.Income);

            await _repository.UpdateAsync(player);

            return new PlayerDto
            {
                PlayerId = player.PlayerId,
                Age = player.Age,
                Gender = player.Gender,
                Income = player.Income,
                Bmi = player.Bmi
            };
        }
    }
}
