import { trackingApi } from '@sitecore-jss/sitecore-jss-tracking';
import { dataFetcher } from "../utils/dataFetcher";
const config = require('../temp/config');

const apiHost = 'http://dinocore.sc';
const trackingApiOptions = {
    host: apiHost,
    querystringParams: {
        sc_apikey: config.sitecoreApiKey,
    },
    fetcher: dataFetcher
};

export const track = (event: string) => {

    console.log(`SEND TRACK ${event}`);
    trackingApi
        // note the events are an array - batching is supported
        .trackEvent([{ eventId: event }], trackingApiOptions)
        .then(() => {
            console.log(`Tracked ${event}`);
        })
        .catch((error: any) => console.error(error))
        .finally(() => {
            fetch(`${apiHost}/sitecore/api/jss/track/flush`, {
                method: "GET",
                mode: "no-cors",
                cache: "no-cache",
            }).then(() => {
                console.log('flushed');
            })
        });
}