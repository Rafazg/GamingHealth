using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingHealth.Application.DTOs
{
    public class PlayerDetailDto
    {
        public int PlayerId { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public decimal? Income { get; set; }
        public decimal? Bmi { get; set; }

        public GamingHabitsDto? GamingHabits { get; set; }
        public HealthDto? Health { get; set; }
        public SocialDto? Social { get; set; }
        public PerformanceDto? Performance { get; set; }
        public FinancialTechDto? FinancialTech { get; set; }
    }

    public class GamingHabitsDto
    {
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

    public class HealthDto
    {
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

    public class SocialDto
    {
        public decimal? SocialInteractionScore { get; set; }
        public decimal? RelationshipSatisfaction { get; set; }
        public int? FriendsGamingCount { get; set; }
        public int? OnlineFriends { get; set; }
        public decimal? LonelinessScore { get; set; }
        public decimal? ToxicExposure { get; set; }
        public decimal? AggressionScore { get; set; }
    }

    public class PerformanceDto
    {
        public decimal? AcademicPerformance { get; set; }
        public decimal? WorkProductivity { get; set; }
        public decimal? HappinessScore { get; set; }
        public decimal? AddictionLevel { get; set; }
        public int? ParentalSupervision { get; set; }
    }

    public class FinancialTechDto
    {
        public decimal? MicrotransactionsSpending { get; set; }
        public decimal? StreamingHours { get; set; }
        public int? InternetQuality { get; set; }
    }
}
