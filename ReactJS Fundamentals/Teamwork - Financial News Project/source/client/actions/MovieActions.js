import alt from '../alt'
import TMDB from '../utilities/RequesterTMDB'

class MovieActions {
  constructor () {
    this.generateActions(
      'getTopTenMoviesSuccess',
      'getTopTenMoviesFail',
      'getFiveRecentMoviesSuccess',
      'getFiveRecentMoviesFail',
      'emptyTopTenMovies',
      'addMovieToTopTen',
      'addCommentSuccess',
      'addCommentFail',
      'addVoteSuccess',
      'addVoteFail'
    )
  }

  getFiveRecentMovies () {
    let request = {
      method: 'get',
      url: '/api/movies/five-recent'
    }
    $.ajax(request).done(data => this.getFiveRecentMoviesSuccess(data))

    return true
  }

  getTopTenMovies () {
    let request = {
      url: '/api/movies/top-ten',
      method: 'get'
    }

    $.ajax(request).done(payload => {
      this.emptyTopTenMovies()
      for (let movie of payload) {
        let movieData = {
          _id: movie._id,
          name: movie.name,
          description: movie.description,
          genres: movie.genres,
          votes: movie.votes,
          score: movie.score
        }

        TMDB.getMoviePoster(movie.name).then(tmdbResponse => {
          movieData.moviePosterUrl = tmdbResponse.posterUrl

          getComments(movie._id).then(comments => {
            movieData.comments = comments

            getLoggedInUserVote(movie._id).then(vote => {
              movieData.loggedInUserScore = vote.voteScore

              this.addMovieToTopTen(movieData)
            })
          })
        })
      }
    }).fail(err => this.getTopTenMoviesFail(err))

    return true
  }

  addComment (movieId, comment) {
    let request = {
      url: `/api/movies/${movieId}/comments`,
      method: 'post',
      contentType: 'application/json',
      data: JSON.stringify({content: comment})
    }

    $.ajax(request).done(data => {
      this.addCommentSuccess(data)
    }).fail(err => {
      this.addCommentFail(err.responseJSON)
    })

    return true
  }

  addVote (movieId, score) {
    let request = {
      url: `/api/movies/${movieId}/vote`,
      method: 'post',
      contentType: 'application/json',
      data: JSON.stringify({score})
    }

    $.ajax(request).then(data => {
      data.movieId = movieId
      this.addVoteSuccess(data)
    }).fail(err => this.addVoteFail(err.responseJSON))

    return true
  }
}

export default alt.createActions(MovieActions)

function getComments (movieId) {
  return new Promise((resolve, reject) => {
    let request = {
      url: `/api/movies/${movieId}/comments`,
      method: 'get'
    }

    $.ajax(request).done(data => resolve(data)).fail(err => reject(err))
  })
}

function getLoggedInUserVote (movieId, userId) {
  return new Promise(resolve => {
    let request = {
      method: 'get'
    }

    if (userId) {
      request.url = `/api/movies/${movieId}/vote?userId=${userId}`
    } else {
      request.url = `/api/movies/${movieId}/vote?user=loggedInUser`
    }

    $.ajax(request).done(data => resolve(data))
  })
}
