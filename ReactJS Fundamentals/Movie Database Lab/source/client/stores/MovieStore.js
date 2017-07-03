import alt from '../alt'
import MovieActions from '../actions/MovieActions'

class MovieStore {
  constructor () {
    this.bindActions(MovieActions)
    this.topTenMovies = []
    this.mostRecentMovies = []
  }

  onAddMovieToTopTen (movie) {
    this.topTenMovies.push(movie)
  }

  onEmptyTopTenMovies () {
    this.topTenMovies = []
  }

  onGetTopTenMoviesSuccess (movies) {
    this.topTenMovies = movies
  }

  onGetTopTenMoviesFail (err) {
    console.log('Could connect to DB', err)
  }

  onGetFiveRecentMoviesSuccess (data) {
    this.mostRecentMovies = data
  }

  onGetFiveRecentMoviesFail () {
    console.log('Could not connext to DB')
  }

  onAddCommentSuccess (data) {
    let comment = data.comment
    let movieId = data.comment.movie
    for (let i = 0, n = this.topTenMovies.length; i < n; i++ ) {
      if (this.topTenMovies[i]._id === movieId) {
        this.topTenMovies[i].comments.unshift(comment)
      }
    }
  }

  onAddVoteSuccess (data) {
    let movieId = data.movieId
    let loggedInUserScore = data.voteScore
    let movieScore = data.movieScore
    let movieVotes = data.movieVotes

    for (let movie of this.topTenMovies) {
      if (movie._id === movieId) {
        movie.loggedInUserScore = loggedInUserScore
        movie.score = movieScore
        movie.votes = movieVotes
        break
      }
    }
  }
}

export default alt.createStore(MovieStore)
