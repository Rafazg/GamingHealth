using Dapper;
using GamingHealth.Domain.Entities;
using GamingHealth.Domain.Interfaces;
using GamingHealth.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GamingHealth.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly OracleDbContext _context;

        public PlayerRepository(OracleDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Player>> GetAllAsync(int page, int pageSize)
        {
            var sql = @"
                SELECT player_id   AS PlayerId,
                       age         AS Age,
                       gender      AS Gender,
                       income      AS Income,
                       bmi         AS Bmi
                FROM player
                ORDER BY player_id
                OFFSET :Offset ROWS FETCH NEXT :PageSize ROWS ONLY";

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<Player>(sql, new
            {
                Offset = (page - 1) * pageSize,
                PageSize = pageSize
            });
        }

        public async Task<Player?> GetByIdAsync(int playerId)
        {
            var sql = @"
                SELECT p.player_id  AS PlayerId,
                       p.age        AS Age,
                       p.gender     AS Gender,
                       p.income     AS Income,
                       p.bmi        AS Bmi
                FROM player p
                WHERE p.player_id = :PlayerId";

            var sqlGamingHabits = @"
                SELECT player_id                AS PlayerId,
                       daily_gaming_hours       AS DailyGamingHours,
                       weekly_sessions          AS WeeklySessions,
                       years_gaming             AS YearsGaming,
                       weekend_gaming_hours     AS WeekendGamingHours,
                       multiplayer_ratio        AS MultiplayerRatio,
                       violent_games_ratio      AS ViolentGamesRatio,
                       mobile_gaming_ratio      AS MobileGamingRatio,
                       night_gaming_ratio       AS NightGamingRatio,
                       competitive_rank         AS CompetitiveRank,
                       headset_usage            AS HeadsetUsage,
                       esports_interest         AS EsportsInterest
                FROM gaming_habits
                WHERE player_id = :PlayerId";

            var sqlHealth = @"
                SELECT player_id            AS PlayerId,
                       sleep_hours          AS SleepHours,
                       caffeine_intake      AS CaffeineIntake,
                       exercise_hours       AS ExerciseHours,
                       stress_level         AS StressLevel,
                       anxiety_score        AS AnxietyScore,
                       depression_score     AS DepressionScore,
                       screen_time_total    AS ScreenTimeTotal,
                       eye_strain_score     AS EyeStrainScore,
                       back_pain_score      AS BackPainScore
                FROM health
                WHERE player_id = :PlayerId";

            var sqlSocial = @"
                SELECT player_id                    AS PlayerId,
                       social_interaction_score     AS SocialInteractionScore,
                       relationship_satisfaction    AS RelationshipSatisfaction,
                       friends_gaming_count         AS FriendsGamingCount,
                       online_friends               AS OnlineFriends,
                       loneliness_score             AS LonelinessScore,
                       toxic_exposure               AS ToxicExposure,
                       aggression_score             AS AggressionScore
                FROM social
                WHERE player_id = :PlayerId";

            var sqlPerformance = @"
                SELECT player_id                AS PlayerId,
                       academic_performance     AS AcademicPerformance,
                       work_productivity        AS WorkProductivity,
                       happiness_score          AS HappinessScore,
                       addiction_level          AS AddictionLevel,
                       parental_supervision     AS ParentalSupervision
                FROM performance
                WHERE player_id = :PlayerId";

            var sqlFinancialTech = @"
                SELECT player_id                    AS PlayerId,
                       microtransactions_spending   AS MicrotransactionsSpending,
                       streaming_hours              AS StreamingHours,
                       internet_quality             AS InternetQuality
                FROM financial_tech
                WHERE player_id = :PlayerId";

            using var connection = _context.CreateConnection();

            var player = await connection.QueryFirstOrDefaultAsync<Player>(sql, new { PlayerId = playerId });

            if (player is null) return null;

            player.GamingHabits = await connection.QueryFirstOrDefaultAsync<GamingHabits>(sqlGamingHabits, new { PlayerId = playerId });
            player.Health = await connection.QueryFirstOrDefaultAsync<Health>(sqlHealth, new { PlayerId = playerId });
            player.Social = await connection.QueryFirstOrDefaultAsync<Social>(sqlSocial, new { PlayerId = playerId });
            player.Performance = await connection.QueryFirstOrDefaultAsync<Performance>(sqlPerformance, new { PlayerId = playerId });
            player.FinancialTech = await connection.QueryFirstOrDefaultAsync<FinancialTech>(sqlFinancialTech, new { PlayerId = playerId });

            return player;
        }

        public async Task<int> GetTotalCountAsync()
        {
            var sql = "SELECT COUNT(*) FROM player";
            using var connection = _context.CreateConnection();
            return await connection.ExecuteScalarAsync<int>(sql);
        }
    }
}