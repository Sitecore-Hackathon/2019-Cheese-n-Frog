using System;
using System.Linq;
using GraphQL.Types;
using Sitecore.SecurityModel;
using Sitecore.Configuration;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using System.Collections.Generic;
using Sitecore.Services.GraphQL.Schemas;
using Hackathon.Dinocore.Feature.Highscores.Models;

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
            public HighscoreQuery() : base(name: Templates.Highscore.HighscoreQuery, description: Templates.Highscore.HighscoreQueryDescription)
            {
                var scoreArgument = new QueryArgument(typeof(IntGraphType))
                {
                    Name = Templates.Highscore.Score, Description = Templates.Highscore.ScoreDescription
                };
                var amountArgument = new QueryArgument(typeof(IntGraphType))
                {
                    Name = Templates.Highscore.Amount, Description = Templates.Highscore.AmountDescription
                };
                this.Arguments = new QueryArguments(new [] { scoreArgument, amountArgument });
            }

            protected override IEnumerable<Highscore> Resolve(ResolveFieldContext context)
            {
                var argumentScore = context.GetArgument<int> (Templates.Highscore.Score);
                var argumentAmount = context.GetArgument<int>( Templates.Highscore.Amount, 5);

                using (var searchContent = ContentSearchManager.GetIndex(Templates.Highscore.MasterDbName).CreateSearchContext())
                {
                    
                    var searchResults = searchContent.GetQueryable<HighscoreSearchResultItem>()
                        .Where(i => i.LatestVersion &&
                                    i.Language == Templates.Highscore.DbLanguage &&
                                    i.TemplateId == Templates.Highscore.ID &&
                                    i.Path.StartsWith(Templates.Highscore.ContentPath));
                    var results = searchResults.GetResults();

                    var highscores = (from doc in results.Hits
                                     select new Highscore()
                                     {
                                         Name = doc.Document.GetField(Templates.Highscore.Name).Value,
                                         Created = doc.Document.CreatedDate,
                                         Score = int.Parse(doc.Document.GetField(Templates.Highscore.Score).Value)
                                     }).ToList();
                    var high = highscores.Where(hs => hs.Score > argumentScore).Take(argumentAmount);
                    var low = highscores.Where(hs => hs.Score < argumentScore).Take(argumentAmount);

                    return high.Concat(low);
                }
            }
        }

        protected class HighscoreMutation : RootFieldType<HighscoreGraphType, Highscore>
        {
            public HighscoreMutation() : base(name: Templates.Highscore.HiscoreMutation, description: Templates.Highscore.HiscoreMutationDescription)
            {
                var scoreArgument = new QueryArgument(typeof(IntGraphType))
                {
                    Name =Templates.Highscore.Score, Description = Templates.Highscore.ScoreDescription,
                };
                var nameArgument = new QueryArgument(typeof(StringGraphType))
                {
                    Name = Templates.Highscore.NameLowercase, Description = Templates.Highscore.PlayerName
                };
                this.Arguments = new QueryArguments(new [] { scoreArgument, nameArgument });
            }

            protected override Highscore Resolve(ResolveFieldContext context)
            {
               var argumentScore = context.GetArgument<int>(Templates.Highscore.Score, -1);
               var argumentName = context.GetArgument<string>(Templates.Highscore.NameLowercase);

               var master = Factory.GetDatabase(Templates.Highscore.Master);
               var parentItem = master.Items[Templates.Highscore.HighscoresPath];
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
                   item[Templates.Highscore.Score] = argumentScore.ToString();
                   item[Templates.Highscore.Name] = argumentName;
                   highscore.Added = item.Editing.EndEdit();
               }

               return highscore;
            }
        }

        protected class HighscoresGraphType : ObjectGraphType<IEnumerable<Highscore>>
        {
            public HighscoresGraphType()
            {
                Name = Templates.Highscore.HighscoresName;

                Field<ListGraphType<HighscoreGraphType>>(Templates.Highscore.Items, resolve: context => context.Source);
            }
        }

        protected class HighscoreGraphType : ObjectGraphType<Highscore>
        {
            public HighscoreGraphType()
            {
                Name = Templates.Highscore.HighscoreName;

                Field<NonNullGraphType<StringGraphType>>(Templates.Highscore.NameLowercase, resolve: context => context.Source.Name);
                Field<IntGraphType>(Templates.Highscore.Score, resolve: context => context.Source.Score);
                Field<DateTimeGraphType>(Templates.Highscore.Created, resolve: context => context.Source.Created);
                Field<BooleanGraphType>(Templates.Highscore.Added, resolve: context => context.Source.Added);
            }
        }
    }
}