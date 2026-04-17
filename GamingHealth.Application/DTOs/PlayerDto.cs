using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingHealth.Application.DTOs
{
    public class PlayerDto
    {
        public int PlayerId { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public decimal? Income { get; set; }
        public decimal? Bmi { get; set; }
    }
}