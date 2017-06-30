import alt from '../alt'
import TMDB from '../utilities/RequesterTMDB'

class HomeActions {
  constructor () {
    this.generateActions(
      'getTopTenMoviesSuccess',
      'getTopTenMoviesFail'
    )
  }

  getTopTenMovies () {
    let request = {
      url: '/api/movies/top-ten',
      method: 'get'
    }

    $.ajax(request)
      .done(payload => {
        let tmdbPromises = []
        for (let movie of payload) {
          tmdbPromises.push(TMDB.getMoviePoster(movie.name))
        }
        Promise.all(tmdbPromises).then((promises) => {
          let movies = []
          for (let i = 0; i < payload.length; i++) {
            let movieData = {
              _id: payload[i]._id,
              name: payload[i].name,
              description: payload[i].description,
              genres: payload[i].genres,
              moviePosterUrl: promises[i].posterUrl
            }
            movies.push(movieData)
          }

          this.getTopTenMoviesSuccess(movies)
        })
      })
      .fail(err => this.getTopTenMoviesFail(err))

    return true
  }
}

export default alt.createActions(HomeActions)
