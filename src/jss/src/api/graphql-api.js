import { ApolloClient } from 'apollo-client';
import { createHttpLink } from 'apollo-link-http';
import { InMemoryCache } from 'apollo-cache-inmemory';
import { highscoreQuery, highscoreMutation } from './queries';
import * as config from '../temp/config';

const link = createHttpLink({
    uri: config.graphQLEndpoint,
    //credentials: 'include',
    fetchOptions: {
        //mode: 'no-cors',
      },
});

const client = new ApolloClient({
    cache: new InMemoryCache(),
    link,
});

const getHighscores = (score: number, amount: number = 5) => {
    var variables = { score: score,  amount: amount };
    return client.query({ query: highscoreQuery, variables: variables }).then(function (response) {
        return response.data;
    }).catch(function (error) {
        return error;
    })
}

const addHighscores = (score: number, name: string) => {
    var variables = { score: score,  name: name };
    return client.mutate({ mutation: highscoreMutation, variables: variables }).then(function (response) {
        return response.data;
    }).catch(function (error) {
        return error;
    })
}

export default {
    getHighscores,
    addHighscores
}
