import React from 'react';
import GraphQLApi from '../../api/graphql-api';

const compare = (a,b) =>{
    if (a.score < b.score)
      return 1;
    if (a.score > b.score)
      return -1;
    return 0;
  }

const LeaderboardHeader = () => {
    return (
        <div className="leadheader">
            <h2>Leaderboard</h2>
        </div>
    )
}

const ColumnHeader = ({
    onClick,
    onClickAll
}) => (
        <div className="row colheader">
            <div className="col-md-2">
                <h4>#</h4>
            </div>
            <div className="col-md-5">
                <h4>Name</h4>
            </div>
            <div className="col-md-5 recent">
                <h4 onClick={onClick} >Score</h4>
            </div>
        </div>
    );

const User = ({ rank, username, recent, alltime }) => {
    return (
        <div className="row users  vcenter">
            <div className="col-md-2 rank cgafont">
                <h4>{rank}</h4>
            </div>
            <div className="col-md-5 name cgafont">
                <img src={`https://avatars.dicebear.com/v2/male/${username}.svg`} alt='avatar' /> <a href="/">{username}</a>
            </div>
            <div className="col-md-5 cgafont">
                <h4>{recent}</h4>
            </div>
        </div>
    )
}

class LeaderBoard extends React.Component<any, any> {

    

    componentDidMount() {
        let score = window.localStorage['score'] || 0;
        setInterval(() => {
            GraphQLApi.getHighscores(Math.round(score), 10)
            .then(response => {
                let list = response.highscoreQuery.items.sort(compare);
                this.setState({
                    list: list
                });
            })
            .catch(err => console.log('fetch error : ', err))
        }, 1000);
    }

    _clickAllTime(e) {
        let sorted = this.state.list.sort((a, b) => b.alltime - a.alltime);
        this.setState(sorted);
    }

    _clickRecent(e) {
        let sorted = this.state.list.sort((a, b) => b.recent - a.recent);
        this.setState(sorted);
    }

    render() {
        let userlist = (this.state && this.state.list) ? this.state.list.map(
            (user, i) => 
                <User key={ i } username={user.name} rank={i + 1} img={user.img} recent={user.score} alltime={user.alltime} />) : null;

        return (
            <div className="container">
                <LeaderboardHeader />
                <ColumnHeader onClickAll={this._clickAllTime} onClick={this._clickRecent} />
                {userlist}
            </div>
        )
    }
}

export default LeaderBoard;
