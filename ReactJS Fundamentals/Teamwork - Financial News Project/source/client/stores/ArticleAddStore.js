import alt from '../alt'
import ArticleAddActions from '../actions/ArticleAddActions'
import Helpers from '../utilities/Helpers'

class ArticleAddStore {
  constructor () {
    this.bindActions(ArticleAddActions)

    this.name = ''
    this.description = ''
    this.genres = []
    this.articlePosterUrl = ''
    this.genresValidationState = ''
    this.nameValidationState = ''
    this.helpBlock = ''
  }

  onAddArticleSuccess () {
    console.log('Added news!')
  }

  onAddArticleFail (err) {
    console.log('Failed to add news', err)
  }

  onGetArticlePosterSuccess (data) {
    this.articlePosterUrl = data.posterUrl
  }

  onGetArticlePosterFail (err) {
    console.log('Could not get news post', err)
  }

  onHandleNameChange (e) {
    this.name = e.target.value
    this.nameValidationState = ''
    this.helpBlock = ''
  }

  onHandleDescriptionChange (e) {
    this.description = e.target.value
    this.genresValidationState = ''
    this.helpBlock = ''
  }

  onHandleGenresChange (e) {
    console.log(e)
    let genreValue = e.target.value
    if (this.genres.indexOf(genreValue) === -1) {
      this.genres = Helpers.appendToArray(genreValue, this.genres)
    } else {
      this.genres = Helpers.removeFromArray(genreValue, this.genres)
    }
    this.genresValidationState = ''
    this.helpBlock = ''
  }

  onNameValidationFail () {
    this.nameValidationState = 'has-error'
    this.helpBlock = 'Enter news name'
  }

  onGenresValidationFail () {
    this.genresValidationState = 'has-error'
    this.helpBlock = 'Select atleast one news genre'
  }
}

export default alt.createStore(ArticleAddStore)
