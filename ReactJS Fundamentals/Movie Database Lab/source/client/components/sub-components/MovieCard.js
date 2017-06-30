import React from 'react'
import { Link } from 'react-router'
import Helpers from '../../utilities/Helpers'

export default class MovieCard extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      showVotePanel: false,
      showCommentsPanel: false
    }
  }

  toggleCommentsPanel () {
    this.setState(prevState => ({
      showCommentsPanel: !prevState.showCommentsPanel,
      showVotePanel: false
    }))
  }

  toggleVotePanel () {
    this.setState(prevState => ({
      showVotePanel: !prevState.showVotePanel,
      showCommentsPanel: false
    }))
  }

  render () {
    let nodes = Helpers.nodesMovieCard(
      this.state,
      this.props,
      this.toggleCommentsPanel.bind(this),
      this.toggleVotePanel.bind(this)
    )

    return (
      <div className='animated fadeIn'>
        <div className='media movie'>
          <span className='position pull-left'>{this.props.index + 1}</span>
          <div className='pull-left thumb-lg' >
            {nodes.poster}
          </div>
          <div className='media-body'>
            <h4 className='media-heading'>
              <Link to={`/movie/${this.props.movie._id}/${this.props.movie.name}`}>
                {this.props.movie.name}
              </Link>
            </h4>
            <small>Genres: {nodes.genres}</small>
            <br />
            <p>{this.props.movie.description}</p>
            <span className='votes'>Votes: 
              {/*<strong>{this.state.movieVotes}</strong>*/}
            </span>
            {/*{nodes.rating}*/}
          </div>
          {nodes.panelToggles}
        </div>
        {nodes.votePanel}
        {nodes.commentsPanel}
        <div id='clear' />
      </div>
    )
  }
}
