using GraphQL.Types;
using Hackathon.Dinocore.Feature.Highscores.Models;
using Sitecore.Configuration;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.SecurityModel;
using Sitecore.Services.GraphQL.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hackathon.Dinocore.Feature.Highscores.Providers
{
    public class DinocoreSchemaProvider : SchemaProviderBase
    {
        public override IEnumerable<FieldType> CreateRootQueries()
        {
            yield return new HighscoreQuery();
        }

        public override IEnumerable<FieldType> CreateRootMutations()
        {
            yield return new HighscoreMutation();
        }

        protected class HighscoreQuery : RootFieldType<HighscoresGraphType, IEnumerable<Highscore>>
        {
            public HighscoreQuery() : base(name: "highscoreQuery", description: "Gets some Highscore data")
            {
                var scoreArgument = new QueryArgument(typeof(IntGraphType))
                {
                    Name = "score", Description = "The current score"
                };
                var amountArgument = new QueryArgument(typeof(IntGraphType))
                {
                    Name = "amount", Description = "The amount of high scores returned"
                };
                this.Arguments = new QueryArguments(new [] { scoreArgument, amountArgument });
            }
            protected override IEnumerable<Highscore> Resolve(ResolveFieldContext context)
            {
                var argumentScore = context.GetArgument<int>("score");
                var argumentAmount = context.GetArgument<int>("amount", 5);

                using (var searchContent = ContentSearchManager.GetIndex("sitecore_master_index").CreateSearchContext())
                {
                    
                    var searchResults = searchContent.GetQueryable<HighscoreSearchResultItem>()
                        .Where(i => i.LatestVersion &&
                                    i.Language == "en" &&
                                    i.TemplateId == Templates.Highscore.ID &&
                                    i.Path.StartsWith("/sitecore/content"));
                    var results = searchResults.GetResults();

                    var highscores = (from doc in results.Hits
                                     select new Highscore()
                                     {
                                         Name = doc.Document.GetField("Name").Value,
                                         Created = doc.Document.CreatedDate,
                                         Score = int.Parse(doc.Document.GetField("Score").Value)
                                     }).ToList();
                    var high = highscores.Where(hs => hs.Score > argumentScore).Take(argumentAmount);
                    var low = highscores.Where(hs => hs.Score < argumentScore).Take(argumentAmount);

                    return high.Concat(low);
                }
            }
        }

        protected class HighscoreMutation : RootFieldType<HighscoreGraphType, Highscore>
        {

            // try to use DI for the factory
            public HighscoreMutation() : base(name: "highscoreMutation", description: "Sets some Highscore data")
            {
                var scoreArgument = new QueryArgument(typeof(IntGraphType))
                {
                    Name = "score", Description = "The current score",
                };
                var nameArgument = new QueryArgument(typeof(StringGraphType))
                {
                    Name = "name", Description = "The player name"
                };
                this.Arguments = new QueryArguments(new [] { scoreArgument, nameArgument });
            }
            protected override Highscore Resolve(ResolveFieldContext context)
            {
               var argumentScore = context.GetArgument<int>("score", -1);
               var argumentName = context.GetArgument<string>("name");

               var master = Factory.GetDatabase("master");
               var parentItem = master.Items["/sitecore/content/Highscores"];
               var template = master.GetTemplate(Templates.Highscore.ID);

               var highscore = new Highscore()
               {
                   Score = argumentScore,
                   Name = argumentName,
                   Created = DateTime.Now
               };
               using (new SecurityDisabler())
               {
                   var item = parentItem.Add(argumentName, template);
                   item.Editing.BeginEdit();
                   item["Score"] = argumentScore.ToString();
                   item["Name"] = argumentName;
                   highscore.Added = item.Editing.EndEdit();
               }

               return highscore;
            }
        }

        protected class HighscoresGraphType : ObjectGraphType<IEnumerable<Highscore>>
        {
            public HighscoresGraphType()
            {
                Name = "Highscores";

                Field<ListGraphType<HighscoreGraphType>>("items", resolve: context => context.Source);

            }
        }

        protected class HighscoreGraphType : ObjectGraphType<Highscore>
        {
            public HighscoreGraphType()
            {
                Name = "Highscore";

                Field<NonNullGraphType<StringGraphType>>("name", resolve: context => context.Source.Name);
                Field<IntGraphType>("score", resolve: context => context.Source.Score);
                Field<DateTimeGraphType>("created", resolve: context => context.Source.Created);
                Field<BooleanGraphType>("added", resolve: context => context.Source.Added);
            }
        }
    }
}