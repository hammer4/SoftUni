import alt from '../alt'

class FooterActions {
  constructor () {
    this.generateActions(
      'getFiveRecentMoviesSuccess'
    )
  }

  getFiveRecentMovies () {
    let request = {
      method: 'get',
      url: '/api/movies/five-recent'
    }

    $.ajax(request)
      .done(data => this.getFiveRecentMoviesSuccess(data))

    return true
  }
}

export default alt.createActions(FooterActions)
