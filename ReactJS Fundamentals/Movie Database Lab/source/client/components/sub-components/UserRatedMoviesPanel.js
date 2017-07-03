import React from 'react';

import MovieCard from './MovieCard';

export default class UserVotedMoviesPanel extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div className="list-group">
                Hello from UserRatedMoviesPanel
            </div>
        )
    }
}