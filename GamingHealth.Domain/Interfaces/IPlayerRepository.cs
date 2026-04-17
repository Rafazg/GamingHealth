using GamingHealth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingHealth.Domain.Interfaces
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<Player>> GetAllAsync(int page, int pageSize);
        Task<Player?> GetByIdAsync(int playerId);
        Task<int> GetTotalCountAsync();
    }
}
