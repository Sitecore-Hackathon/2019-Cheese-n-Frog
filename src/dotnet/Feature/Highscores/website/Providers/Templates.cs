using Sitecore.Data;

namespace Hackathon.Dinocore.Feature.Highscores.Providers
{
    internal class Templates
    {
        public struct Highscore
        {
            public const string HighscoreName = "Highscore";
            public const string HighscoresName = "Highscores";
            public const string HighscoreQuery = "highscoreQuery";
            public const string HighscoreQueryDescription = "Gets some Highscore data";
            public const string Score = "score";
            public const string ScoreDescription = "The current score";
            public const string Amount = "amount";
            public const string AmountDescription = "The amount of high scores returned";
            public const string MasterDbName = "sitecore_master_index";
            public const string DbLanguage = "en";
            public const string ContentPath = "/sitecore/content";
            public const string HighscoresPath = "/sitecore/content/Highscores";
            public const string Name = "Name";
            public const string NameLowercase = "name";
            public const string Items = "items";
            public const string Created = "created";
            public const string Added = "added";
            public const string Master = "master";
            public const string HiscoreMutation = "highscoreMutation";
            public const string HiscoreMutationDescription = "highscoreMutation";
            public const string PlayerName = "The player name";

            public static readonly ID ID = new ID("ecb54f65-92bd-4ed4-aaf7-3c3dd565c1b0");
        }
    }
}