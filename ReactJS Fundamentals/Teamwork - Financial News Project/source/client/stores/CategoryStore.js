import alt from '../alt'
import CategoryActions from '../actions/CategoryActions'

class CategoryStore {
  constructor () {
    this.bindActions(CategoryActions)

    this.name = ''
    this.categoryCreated = false
    this.categories = ''
  }

  onCreateCategorySuccess (category) {
    this.categoryCreated = true
  }

  onHandleNameChange (ev) {
    this.name = ev.target.value
  }

  onGetAllCategoriesSuccess (categories) {
    th
  }
}

export default alt.createStore(CategoryStore)
