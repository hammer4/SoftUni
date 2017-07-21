import dispatcher from '../dispatcher'

const reviewActions = {
  types: {
    ADD_REVIEW: 'ADD_REVIEW',
    GET_ALL: 'GET_ALL'
  },
  create (review, id) {
    dispatcher.dispatch({
      type: this.types.ADD_REVIEW,
      review,
      id
    })
  },
  getAll (id) {
    dispatcher.dispatch({
      type: this.types.GET_ALL,
      id
    })
  }
}

export default reviewActions
