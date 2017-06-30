const API_KEY = '71aabd79c7082bcacabc96877ac7238b'
const SEARCH_BASE_URL = 'https://api.themoviedb.org/3/search/movie'
const POSTER_BASE_URL = 'https://image.tmdb.org/t/p/w500'
const UNVERIFIED_MOVIE_POSTER_URL = '/images/movie-unverified.png'
const MISSING_DATA_POSTER_URL = '/images/movie-missing-data.jpg'

export default class RequesterTMDB {
  static getMoviePoster (movieName) {
    return new Promise((resolve, reject) => {
      let request = {
        method: 'get',
        url: `${SEARCH_BASE_URL}?api_key=${API_KEY}&query=${movieName}`
      }

      $.ajax(request)
        .done(tmdbResponse => {
          console.log('TMDB response', tmdbResponse)
          if (tmdbResponse.total_results === 0) {
            resolve({posterUrl: UNVERIFIED_MOVIE_POSTER_URL})
            return
          }

          let posterPath = tmdbResponse.results[0].poster_path
          if (posterPath === null) {
            resolve({posterUrl: MISSING_DATA_POSTER_URL})
            return
          }
          resolve({posterUrl: `${POSTER_BASE_URL}/${posterPath}`})
        })
        .fail(err => {
          reject({
            clientMessage: 'Request failed',
            error: err
          })
        })
    })
  }
}
