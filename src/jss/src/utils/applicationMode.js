import { isServer } from '@sitecore-jss/sitecore-jss';
import * as config from '../temp/config';

const LOCALHOST_HOST_NAME = 'localhost';

export function isCodeFirstMode() {
  return !isServer() && window.location.hostname === LOCALHOST_HOST_NAME;
}

export function isDisconnectedMode() {
  return config.sitecoreApiHost.indexOf(LOCALHOST_HOST_NAME) >= 0;
}