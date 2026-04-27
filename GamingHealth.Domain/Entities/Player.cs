using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingHealth.Domain.Entities
{
    public class Player
    {
        public int PlayerId { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public decimal Income { get; private set; }
        public decimal? Bmi { get; set; }

        // Navegação para as outras tabelas
        public GamingHabits? GamingHabits { get; set; }
        public Health? Health { get; set; }
        public Social? Social { get; set; }
        public Performance? Performance { get; set; }
        public FinancialTech? FinancialTech { get; set; }


        //Construtor vazio
        public Player()
        {

        }

        //Construtor para Classe Player
        public Player(int playerID, int? age, string? gender)
        {
            Console.WriteLine($"PlayerID: {playerID}, Age: {age}, Gender: {gender}");
        }

        public void UpdateIncome(decimal newIncome)
        {
            if (newIncome < 0)
                throw new ArgumentException("Income cannot be negative.");
            Income = newIncome;
        }

        public bool IsAdult() 
        {
            return (Age.HasValue && Age.Value >= 18);
        }
    }
}
