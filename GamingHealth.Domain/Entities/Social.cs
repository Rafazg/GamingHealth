using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingHealth.Domain.Entities
{
    public class Social
    {
        public int PlayerId { get; set; }
        public decimal? SocialInteractionScore { get; set; }
        public decimal? RelationshipSatisfaction { get; set; }
        public int? FriendsGamingCount { get; set; }
        public int? OnlineFriends { get; set; }
        public decimal? LonelinessScore { get; set; }
        public decimal? ToxicExposure { get; set; }
        public decimal? AggressionScore { get; set; }
    }
}
