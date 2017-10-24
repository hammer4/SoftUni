import alt from '../alt'

class CategoryActions {
  constructor () {
    this.generateActions(
      'createCategorySuccess',
      'handleNameChange'
    )
  }

  createCategory (name) {
    let request = {
      url: `/api/categories/add`,
      method: 'post',
      contentType: 'application/json',
      data: JSON.stringify({name: name})
    }

    $.ajax(request).done(data => {
      this.createCategorySuccess(data)
    })

    return true
  }
}

export default alt.createActions(CategoryActions)
