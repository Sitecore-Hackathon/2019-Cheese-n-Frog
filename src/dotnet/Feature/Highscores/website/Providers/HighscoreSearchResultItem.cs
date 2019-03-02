using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;

namespace Hackathon.Dinocore.Feature.Highscores.Providers
{
    internal class HighscoreSearchResultItem : SearchResultItem
    {
        [IndexField("_latestversion")]
        public bool LatestVersion { get; set; }
    }
}