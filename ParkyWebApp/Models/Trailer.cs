using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkyWebApp.Models;

namespace ParkyWebApp.Models
{
    public class Trailer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Double Distance { get; set; }

        public enum DifficultyType
        {
            Easy,
            Moderate,
            Difficult,
            Expert
        }

        public DifficultyType Difficulty { get; set; }
        public int NationalParkId { get; set; }
        public NationalPark NationalPark { get; set; }

    }
}
