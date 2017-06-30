import React from 'react'
import MovieCard from './sub-components/MovieCard'
import HomeActions from '../actions/HomeActions'
import HomeStore from '../stores/HomeStore'

export default class Home extends React.Component {
  constructor (props) {
    super(props)
    this.state = HomeStore.getState()

    this.onChange = this.onChange.bind(this)
  }

  onChange (state) {
    this.setState(state)
  }

  componentDidMount () {
    HomeStore.listen(this.onChange)

    HomeActions.getTopTenMovies()
  }

  componentWillUnmount () {
    HomeStore.unlisten(this.onChange)
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
