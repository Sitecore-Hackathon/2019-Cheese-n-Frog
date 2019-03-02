import React from 'react';
import Game from '../Game';

const options = {
  fps: 60,
  skySpeed: 40,
  groundSpeed: 100
}

const ContentBlock = ({ fields }) => (
  <React.Fragment>
    <div className="content">
      <div className="sitelogo"><img src={'/img/dinocore-logo.png'} /></div>
      <div className="game"><Game options={options} /></div>
    </div>
  </React.Fragment>
);

export default ContentBlock;
