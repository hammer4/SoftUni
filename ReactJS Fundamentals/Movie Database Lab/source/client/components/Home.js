import React from 'react';

import MovieActions from '../actions/MovieActions';
import MovieStore from '../stores/MovieStore';

import MovieCard from './sub-components/MovieCard';

export default class Home extends React.Component {
    constructor(props) {
        super(props);

        this.state = MovieStore.getState();

        this.onChange = this.onChange.bind(this);
    }

    onChange(state) {
        this.setState(state);
    }

    componentDidMount() {
        MovieStore.listen(this.onChange);

        MovieActions.getTopTenMovies();
    }

    componentWillUnmount() {
        MovieStore.unlisten(this.onChange);
    }

    render() {
        let movies = this.state.topTenMovies.map((movie, index) => {
            return (
                <MovieCard key={ movie._id }
                           movie={ movie }
                           index={ index } />
            );
        });

        return (
            <div className='container'>
                <h3 className='text-center'>Welcome to
                    <strong> Movie Database</strong>
                </h3>
                <div className="list-group">
                    { movies }
                </div>
            </div>
        );
    }
}
