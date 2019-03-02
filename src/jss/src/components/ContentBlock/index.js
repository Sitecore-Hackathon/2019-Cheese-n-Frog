import React from 'react';
import Game from '../Game';

const options = {
  fps: 60,
  skySpeed: 40,
  groundSpeed: 100
}

const ContentBlock = ({ fields }) => (
  <React.Fragment>
    <Game {...options} />
  </React.Fragment>
);

export default ContentBlock;
