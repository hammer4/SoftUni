import React from 'react'

import UserRatedMoviesPanel from './UserRatedMoviesPanel'

export default class UserVotedMovies extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      showRatedMoviesPanel: false
    }
  }

  toggleRatedMovies () {
    this.setState(prevState => ({
      showRatedMoviesPanel: !prevState.showRatedMoviesPanel
    }))
  }

  render () {
    return (
      <div className='container profile-container'>
        <div className='profile-stats clearfix'>
          <ul>
            <li>
              <span className='stats-number'>{this.props.votes
                ? this.props.votes.length
                : 0 }</span>Votes
            </li>
          </ul>
        </div>
        <div className='pull-right btn-group'>
          <a className='btn btn-primary'
            onClick={this.toggleRatedMovies.bind(this)}>
            { this.state.showRatedMoviesPanel ? 'Hide' : 'Rated News' }
          </a>
        </div>
        { this.state.showRatedMoviessPanel
        ? <UserRatedMoviesPanel movies={this.props.votes} /> : null }
      </div>
    )
  }
}
