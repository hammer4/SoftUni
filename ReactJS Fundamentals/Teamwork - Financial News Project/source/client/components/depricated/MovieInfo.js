import React from 'react'
import { Link } from 'react-router'
import Helpers from '../../utilities/Helpers'

export default class MovieInfo extends React.Component {
  render () {
    let genres = this.props.movie.genres.map(genre => {
      return (
        <strong key={this.props.movie._id + genre}>{ genre } </strong>
      )
    })
    let rating = Helpers.formatMovieRating(this.props.movie.score,
      this.props.movie.votes)

    return (
      <div className='media-body'>
        <h4 className='media-heading'>
          <Link
            to={`/movie/${this.props.movie._id}/${this.props.movie.name}`}>
            { this.props.movie.name }
          </Link>
        </h4>
        <small>Genres: { genres }</small>
        <br />
        <p>{ this.props.movie.description }</p>
        <span className='votes'>Votes:
                    <strong> { this.props.movie.votes }</strong>
        </span>
        <span className='rating position pull-right'>
          {rating }
          <span
            className='badge badge-up'>{ this.props.movie.loggedInUserScore }</span>
        </span>
      </div>
    )
  }
}
