using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingHealth.Domain.Entities
{
    internal class Performance
    {
        public int PlayerId { get; set; }
        public decimal? AcademicPerformance { get; set; }
        public decimal? WorkProductivity { get; set; }
        public decimal? HappinessScore { get; set; }
        public decimal? AddictionLevel { get; set; }
        public int? ParentalSupervision { get; set; }
    }
}
