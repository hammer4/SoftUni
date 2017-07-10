import dispatcher from '../dispatcher'

const commentActions = {
  types: {
    ADD_COMMENT: 'ADD_COMMENT',
    GET_ALL: 'GET_ALL'
  },
  create (message, id) {
    dispatcher.dispatch({
      type: this.types.ADD_COMMENT,
      message,
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

export default commentActions
