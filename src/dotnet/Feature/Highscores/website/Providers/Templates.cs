using Sitecore.Data;

namespace Hackathon.Dinocore.Feature.Highscores.Providers
{
    internal class Templates
    {
        public struct Highscore
        {
            public static readonly ID ID = new ID("ecb54f65-92bd-4ed4-aaf7-3c3dd565c1b0");

            public struct Fields
            {
                public static readonly ID Score = new ID("a39cb1a7-a175-4272-8d6d-0106dae669b1");
                public const string ScoreFieldName = "Score";

            }
        }
    }
}