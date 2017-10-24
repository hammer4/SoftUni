import React from 'react'
import { Link } from 'react-router'

import { Concealer } from '../../utilities/Authorize'

class VoteToggle extends React.Component {
  render () {
    return (
      <a className='btn btn-primary'
         onClick={ this.props.toggleVotePanel }>
        { this.props.showVotePanel ? 'Hide' : 'Vote' }
      </a>
    )
  }
}

export default class MoviePanelToggles extends React.Component {
  render () {
    return (
      <div className='pull-right btn-group'>
        <a className='btn btn-primary'
          onClick={this.props.toggleCommentsPanel}>
          {this.props.showCommentsPanel ? 'Hide' : 'Comments'}
        </a>
        <Concealer ChildComponent={VoteToggle}
          toggleVotePanel={this.props.toggleVotePanel}
          showVotePanel={this.props.showVotePanel} />
        <Link to={`/movie/${this.props.movieId}/review/add`}
          className='btn btn-warning'>
          Write review
        </Link>
      </div>
    )
  }
}
