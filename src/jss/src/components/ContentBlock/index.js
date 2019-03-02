import React from 'react';
import Game from '../Game';
import { isServer } from '@sitecore-jss/sitecore-jss';

const options = {
  fps: 60,
  skySpeed: 40,
  groundSpeed: 100
}

const ContentBlock = ({ fields }) => {
  // Load the assets from a different path when served by Sitecore or disconnected mode.
  const baseAssetPath = !isServer() && window.location.hostname === 'localhost' ? '' : '/dist/dinocore';

  return (
    <React.Fragment>
      <div className="content">
        <div className="sitelogo"><img src={baseAssetPath + '/img/dinocore-logo.png'} alt={ 'Dinocore! Profiling by gaming' } /></div>
        <div className="game"><Game options={options} /></div>
      </div>
    </React.Fragment>
  )
};

export default ContentBlock;
