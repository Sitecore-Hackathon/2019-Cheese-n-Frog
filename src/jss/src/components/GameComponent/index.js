import React from 'react';
import Game from '../Game';
import LeaderBoard from '../LeaderBoard/index';

const options = {
  fps: 60,
  skySpeed: 40,
  groundSpeed: 100
}

const GameComponent = ({ fields }) => (
  <React.Fragment>
    <div className="content">
      <div className="sitelogo"><img src={'/img/dinocore-logo.png'} alt={ 'Dinocore! Profiling by gaming' } /></div>
      <div className="game"><Game options={options} /></div>
      <LeaderBoard />
    </div>
  </React.Fragment>
);

export default GameComponent;
