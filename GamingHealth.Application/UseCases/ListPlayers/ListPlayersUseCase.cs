using GamingHealth.Application.DTOs;
using GamingHealth.Domain.Interfaces;

namespace GamingHealth.Application.UseCases.ListPlayers
{
    public class ListPlayersInput
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }

    public class ListPlayersOutput
    {
        public IEnumerable<PlayerDto> Players { get; set; } = [];
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    }

    public class ListPlayersUseCase
    {
        private readonly IPlayerRepository _repository;

        public ListPlayersUseCase(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<ListPlayersOutput> ExecuteAsync(ListPlayersInput input)
        {
            var players = await _repository.GetAllAsync(input.Page, input.PageSize);
            var total = await _repository.GetTotalCountAsync();

            return new ListPlayersOutput
            {
                Players = players.Select(p => new PlayerDto
                {
                    PlayerId = p.PlayerId,
                    Age = p.Age,
                    Gender = p.Gender,
                    Income = p.Income,
                    Bmi = p.Bmi
                }),
                TotalCount = total,
                Page = input.Page,
                PageSize = input.PageSize
            };
        }
    }
}