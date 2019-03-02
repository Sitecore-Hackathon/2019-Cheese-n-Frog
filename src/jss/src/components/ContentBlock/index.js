import React, { Component } from 'react';
import Game from '../Game';
import { RouteRenderFunctionContext } from '../RouteRenderFunctionContext';

class ContentBlock extends Component {
  static contextType = RouteRenderFunctionContext;

  render() {
    const _this = this;

    const options = {
      getObstacles: (score, highScore) => {
        _this.context(score, highScore);
        // TODO: Read and return obstacles from the new Layout Service response
      }
    };

    return (
      <React.Fragment>
        <Game options={options} />
      </React.Fragment>
    )
  }
}

export default ContentBlock;
