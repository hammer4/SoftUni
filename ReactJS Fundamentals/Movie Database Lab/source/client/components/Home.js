import React from 'react'
import MovieCard from './sub-components/MovieCard'

export default class Home extends React.Component {
  constructor (props) {
    super(props)
    this.state = {
      topTenMovies: [],
      error: ''
    }
  }

  componentDidMount () {
    let request = {
      url: '/api/movies/top-ten',
      method: 'get'
    }

    $.ajax(request)
      .done(data => this.setState({topTenMovies: data}))
      .fail(error => this.setState({error: error.responseJSON.message}))
  }

  render () {
    let movies = this.state.topTenMovies.map((movie, index) => {
      return (
        <MovieCard key={movie._id} movie={movie} index={index} />
      )
    })

    return (
      <div className='container'>
        <h3 className='text-center'>Welcome to
          <strong> Movie Database</strong>
        </h3>
        <div className='list-group'>
          {movies}
        </div>
      </div>
    )
  }
}
