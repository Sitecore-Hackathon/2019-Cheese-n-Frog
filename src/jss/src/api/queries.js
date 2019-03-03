import gql from 'graphql-tag';

export const highscoreQuery = gql`
    query highscoreQuery($score: Int!, $amount: Int!) {
        highscoreQuery(score: $score, amount: $amount) {
            items {
            name
            score
            created
                }
            }
        }
`;

export const highscoreMutation = gql`
    mutation AddHighscore ($score: Int!, $name: String!) {
        highscoreMutation(score: $score, name: $name) {
            added
        }
    }
`;
