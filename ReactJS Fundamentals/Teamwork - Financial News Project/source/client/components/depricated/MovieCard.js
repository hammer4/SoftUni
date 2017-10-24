import React from  'react'

import MoviePoster from './MoviePoster'
import MovieInfo from './MovieInfo'
import MoviePanelsToggle from './MoviePanelsToggle'
import MovieVotePanel from './MovieVotePanel'
import MovieCommentsPanel from './MovieCommentsPanel'

export default class MovieCard extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      showVotePanel: false,
      showCommentsPanel: false,
    }
  }

  toggleCommentsPanel () {
    this.setState(prevState => ({
      showCommentsPanel: !prevState.showCommentsPanel,
      showVotePanel: false,
    }))
  }

  toggleVotePanel () {
    this.setState(prevState => ({
      showVotePanel: !prevState.showVotePanel,
      showCommentsPanel: false,
    }))
  }

  render () {
    return (
      <div className='animated fadeIn'>
        <div className='media movie'>
          <span className='position pull-left'>{ this.props.index + 1 }</span>
          <MoviePoster posterUrl={this.props.movie.moviePosterUrl} />
          <MovieInfo movie={this.props.movie} />
          <MoviePanelsToggle
            toggleCommentsPanel={this.toggleCommentsPanel.bind(this)}
            toggleVotePanel={this.toggleVotePanel.bind(this)}
            showCommentsPanel={this.state.showCommentsPanel}
            showVotePanel={this.state.showVotePanel}
            movieId={this.props.movie._id} />
        </div>
        {this.state.showVotePanel
        ? <MovieVotePanel movieId={this.props.movie._id} /> : null}
        {this.state.showCommentsPanel
        ? <MovieCommentsPanel comments={this.props.movie.comments}
          movieId={this.props.movie._id} /> : null}
        <div id='clear' />
      </div>
    )
  }
}
