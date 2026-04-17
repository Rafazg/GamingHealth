using GamingHealth.Application.DTOs;
using GamingHealth.Domain.Interfaces;

namespace GamingHealth.Application.UseCases.GetPlayerById
{
    public class GetPlayerByIdInput
    {
        public int PlayerId { get; set; }
    }

    public class GetPlayerByIdUseCase
    {
        private readonly IPlayerRepository _repository;

        public GetPlayerByIdUseCase(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<PlayerDetailDto?> ExecuteAsync(GetPlayerByIdInput input)
        {
            var player = await _repository.GetByIdAsync(input.PlayerId);

            if (player is null) return null;

            return new PlayerDetailDto
            {
                PlayerId = player.PlayerId,
                Age = player.Age,
                Gender = player.Gender,
                Income = player.Income,
                Bmi = player.Bmi,
                GamingHabits = player.GamingHabits is null ? null : new GamingHabitsDto
                {
                    DailyGamingHours = player.GamingHabits.DailyGamingHours,
                    WeeklySessions = player.GamingHabits.WeeklySessions,
                    YearsGaming = player.GamingHabits.YearsGaming,
                    WeekendGamingHours = player.GamingHabits.WeekendGamingHours,
                    MultiplayerRatio = player.GamingHabits.MultiplayerRatio,
                    ViolentGamesRatio = player.GamingHabits.ViolentGamesRatio,
                    MobileGamingRatio = player.GamingHabits.MobileGamingRatio,
                    NightGamingRatio = player.GamingHabits.NightGamingRatio,
                    CompetitiveRank = player.GamingHabits.CompetitiveRank,
                    HeadsetUsage = player.GamingHabits.HeadsetUsage,
                    EsportsInterest = player.GamingHabits.EsportsInterest
                },
                Health = player.Health is null ? null : new HealthDto
                {
                    SleepHours = player.Health.SleepHours,
                    CaffeineIntake = player.Health.CaffeineIntake,
                    ExerciseHours = player.Health.ExerciseHours,
                    StressLevel = player.Health.StressLevel,
                    AnxietyScore = player.Health.AnxietyScore,
                    DepressionScore = player.Health.DepressionScore,
                    ScreenTimeTotal = player.Health.ScreenTimeTotal,
                    EyeStrainScore = player.Health.EyeStrainScore,
                    BackPainScore = player.Health.BackPainScore
                },
                Social = player.Social is null ? null : new SocialDto
                {
                    SocialInteractionScore = player.Social.SocialInteractionScore,
                    RelationshipSatisfaction = player.Social.RelationshipSatisfaction,
                    FriendsGamingCount = player.Social.FriendsGamingCount,
                    OnlineFriends = player.Social.OnlineFriends,
                    LonelinessScore = player.Social.LonelinessScore,
                    ToxicExposure = player.Social.ToxicExposure,
                    AggressionScore = player.Social.AggressionScore
                },
                Performance = player.Performance is null ? null : new PerformanceDto
                {
                    AcademicPerformance = player.Performance.AcademicPerformance,
                    WorkProductivity = player.Performance.WorkProductivity,
                    HappinessScore = player.Performance.HappinessScore,
                    AddictionLevel = player.Performance.AddictionLevel,
                    ParentalSupervision = player.Performance.ParentalSupervision
                },
                FinancialTech = player.FinancialTech is null ? null : new FinancialTechDto
                {
                    MicrotransactionsSpending = player.FinancialTech.MicrotransactionsSpending,
                    StreamingHours = player.FinancialTech.StreamingHours,
                    InternetQuality = player.FinancialTech.InternetQuality
                }
            };
        }
    }
}