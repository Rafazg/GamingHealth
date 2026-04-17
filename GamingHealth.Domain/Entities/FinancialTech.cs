using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingHealth.Domain.Entities
{
    public class FinancialTech
    {
        public int PlayerId { get; set; }
        public decimal? MicrotransactionsSpending { get; set; }
        public decimal? StreamingHours { get; set; }
        public int? InternetQuality { get; set; }
    }
}
