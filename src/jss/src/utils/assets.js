import { isCodeFirstMode } from './applicationMode';
import * as config from '../temp/config';

export function baseAssetPath() {
  // Load the assets from a different path when served by Sitecore or disconnected mode.
  return isCodeFirstMode() ? '' : config.distPath;
}