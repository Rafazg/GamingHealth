using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingHealth.Domain.Entities
{
    internal class GamingHabits
    {
        public int PlayerId { get; set; }
        public decimal? DailyGamingHours { get; set; }
        public int? WeeklySessions { get; set; }
        public int? YearsGaming { get; set; }
        public decimal? WeekendGamingHours { get; set; }
        public decimal? MultiplayerRatio { get; set; }
        public decimal? ViolentGamesRatio { get; set; }
        public decimal? MobileGamingRatio { get; set; }
        public decimal? NightGamingRatio { get; set; }
        public int? CompetitiveRank { get; set; }
        public int? HeadsetUsage { get; set; }
        public int? EsportsInterest { get; set; }
    }
}
