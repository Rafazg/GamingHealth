using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingHealth.Domain.Entities
{
    public class Health
    {
        public int PlayerId { get; set; }
        public decimal? SleepHours { get; set; }
        public decimal? CaffeineIntake { get; set; }
        public decimal? ExerciseHours { get; set; }
        public int? StressLevel { get; set; }
        public decimal? AnxietyScore { get; set; }
        public decimal? DepressionScore { get; set; }
        public decimal? ScreenTimeTotal { get; set; }
        public decimal? EyeStrainScore { get; set; }
        public decimal? BackPainScore { get; set; }
    }
}
