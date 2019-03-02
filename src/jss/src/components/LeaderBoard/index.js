import React from 'react';


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
            <div className="col-xs-1">
                <h4>#</h4>
            </div>
            <div className="col-xs-5">
                <h4>Name</h4>
            </div>
            <div className="col-xs-3 recent">
                <h4 onClick={onClick} >Last 30 days</h4>
            </div>
            <div className="col-xs-3 alltime">
                <h4 onClick={onClickAll} >All time</h4>
            </div>
        </div>
    );

const User = ({ rank, img, username, recent, alltime }) => {
    return (
        <div className="row users  vcenter">
            <div className="col-xs-1 rank">
                <h4>{rank}</h4>
            </div>
            <div className="col-xs-5 name">
                <img src={img} alt='avatar' /> <a href={''} target="_blank">{username}</a>
            </div>
            <div className="col-xs-3">
                <h4>{recent}</h4>
            </div>
            <div className="col-xs-3">
                <h4>{alltime}</h4>
            </div>
        </div>
    )
}

class LeaderBoard extends React.Component<any, any> {
    constructor(props) {
        super(props);
    }

    componentDidMount() {
        const fetchInit = {
            method: 'GET',
            mode: 'cors'
        };

        fetch(`${this.props.apiURL}`, fetchInit)
            .then(response => response.json())
            .then(data => {
                this.setState({
                    list: data
                });
            })
            .catch(err => console.log('fetch error : ', err))
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
                <User username={user.username} rank={i + 1} img={user.img} recent={user.recent} alltime={user.alltime} />) : null;

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
