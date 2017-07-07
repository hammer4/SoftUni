import dispatcher from '../dispatcher'

let authorsActions = {
  deleteAuthor: (id) => {
    dispatcher.dispatch({
      type: 'DELETE_AUTHOR',
      id
    })
  }
}

export default authorsActions
