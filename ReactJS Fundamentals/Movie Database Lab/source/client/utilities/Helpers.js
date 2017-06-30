import React from 'react'
import {Link} from 'react-router'

import MovieVotePanel from '../components/sub-components/MovieVotePanel'
import MovieCommentsPanel from '../components/sub-components/MovieCommentsPanel'

export default class Helpers {
  static appendToArray (value, array) {
    array.push(value)

    return array
  }

  static prependToArray (value, array) {
    array.unshift(value)

    return array
  }

  static removeFromArray (value, array) {
    let index = array.indexOf(value)

    if (index !== -1) {
      array.splice(index, 1)
    }

    return array
  }

  static nodesMovieCard (state, props, toggleCommentsPanel, toggleVotePanel) {
    let nodes = {}

    if (state.showCommentsPanel) {
      nodes.commentsPanel = <MovieCommentsPanel movieId={props.movie._id} />
    }

    if (state.showVotePanel) {
      nodes.votePanel = <MovieVotePanel movieId={props.movie._id} />
    }

    nodes.panelToggles = (
      <div className='pull-right btn-group'>
        <a className='btn btn-primary'
          onClick={toggleCommentsPanel}>{state.showCommentsPanel ? 'Hide' : 'Comments'}</a>
        <a className='btn btn-primary'
          onClick={toggleVotePanel}>{state.showVotePanel ? 'Hide' : 'Vote'}</a>
        <Link to={`/movie/${props.movie._id}/review/add`} className='btn btn-warning'>Write review</Link>
      </div>
    )

    nodes.genres = props.movie.genres.map(genre => {
      return (
        <strong key={props.movie._id + genre}>{genre}</strong>
      )
    })

    if (props.movie.moviePosterUrl) {
      nodes.poster = (
        <img className='media-object' src={props.movie.moviePosterUrl} />
      )
    }

    return nodes
  }
}
