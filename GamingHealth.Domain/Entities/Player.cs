using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingHealth.Domain.Entities
{
    internal class Player
    {
        public int PlayerId { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public decimal? Income { get; set; }
        public decimal? Bmi { get; set; }

        // Navegação para as outras tabelas
        public GamingHabits? GamingHabits { get; set; }
        public Health? Health { get; set; }
        public Social? Social { get; set; }
        public Performance? Performance { get; set; }
        public FinancialTech? FinancialTech { get; set; }
    }
}
