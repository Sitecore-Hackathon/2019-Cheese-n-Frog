using System;

namespace Hackathon.Dinocore.Feature.Highscores.Models
{
    public class Highscore
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public DateTime Created { get; set; }
    }
}