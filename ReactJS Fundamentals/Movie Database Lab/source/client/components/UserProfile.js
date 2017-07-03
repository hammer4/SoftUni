import React from 'react';

import UserStore from '../stores/UserStore';
import UserInfo from './sub-components/UserInfo';
import UserVotedMovies from './sub-components/UserRatedMovies';
import UserReviews from './sub-components/UserReviews';

export default class UserProfile extends React.Component {
    constructor(props) {
        super(props);

        this.state = UserStore.getState();

        this.onChange = this.onChange.bind(this);
    }

    onChange(state) {
        this.setState(state);
    }

    componentDidMount() {
        UserStore.listen(this.onChange);
    }

    componentWillUnmount() {
        UserStore.unlisten(this.onChange);
    }

    render() {
        let nodes = {};
        nodes.roles = this.state.roles.map((role, index) => {
            return (
                <h4 key={ index } className='lead'>
                    <strong>{ role }</strong>
                </h4>
            );
        });

        return (
            <div>
                <UserInfo name={ this.state.name }
                          roles={ this.state.roles }
                          information={ this.state.information } />
                <UserVotedMovies votes={ this.state.votes } />
                <UserReviews reviews={ this.props.reviews } />
            </div>
        );
    }
}

