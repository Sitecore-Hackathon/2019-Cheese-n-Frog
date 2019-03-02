using System;
using System.Collections.Generic;
using GraphQL.Types;
using Hackathon.Dinocore.Feature.Highscores.Models;
using Sitecore.Services.GraphQL.Schemas;

namespace Hackathon.Dinocore.Feature.Highscores.Providers
{
    public class DinocoreSchemaProvider : SchemaProviderBase
    {
        public override IEnumerable<FieldType> CreateRootQueries()
        {
            return new FieldType[]
            {
                new HighscoreQuery(),
                new HighscoreMutation()
            };
        }

        protected class HighscoreQuery : RootFieldType<HighscoreGraphType, Highscore>
        {
            public HighscoreQuery() : base(name: "highscoreQuery", description: "Gets some Highscore data")
            {
                var scoreArgument = new QueryArgument(typeof(IntGraphType))
                {
                    Name = "score", Description = "The current score"
                };
                this.Arguments = new QueryArguments(new [] { scoreArgument });
            }
            protected override Highscore Resolve(ResolveFieldContext context)
            {

                var highscore = new Highscore()
                {
                    Created = DateTime.Now,
                    Name = "GOGOGO",
                    Score = 87434
                };
                return highscore;
            }
        }

        protected class HighscoreMutation : RootFieldType<HighscoreGraphType, Highscore>
        {
            public HighscoreMutation() : base(name: "highscoreMutation", description: "Sets some Highscore data")
            {
                var scoreArgument = new QueryArgument(typeof(IntGraphType))
                {
                    Name = "score", Description = "The current score"
                };
                this.Arguments = new QueryArguments(new [] { scoreArgument });
            }
            protected override Highscore Resolve(ResolveFieldContext context)
            {

                var highscore = new Highscore()
                {
                    Created = DateTime.Now,
                    Name = "GOGOGO",
                    Score = 87434
                };
                return highscore;
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
            }
        }
    }
}