import React from 'react';
import Game from '../Game';
import LeaderBoard from '../LeaderBoard/index';
import { baseAssetPath } from '../../utils/assets';

const options = {
  fps: 60,
  skySpeed: 40,
  groundSpeed: 100
}

const GameComponent = () => {
  return (
    <React.Fragment>
      <div className="content">
        <div className="sitelogo"><img src={baseAssetPath() + '/img/dinocore-logo.png'} alt="Dinocore! Profiling by gaming" /></div>
        <div className="game"><Game options={options} /></div>
        <LeaderBoard />
      </div>
    </React.Fragment>
  );
};

export default GameComponent;
