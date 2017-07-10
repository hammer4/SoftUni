import dispatcher from '../dispatcher'

let authorsActions = {
  deleteAuthor: (id) => {
    dispatcher.dispatch({
      type: 'DELETE_AUTHOR',
      id
    })
  },
  create: (author) => {
    dispatcher.dispatch({
      type: 'CREATE_AUTHOR',
      author
    })
  },
  edit: (author) => {
    dispatcher.dispatch({
      type: 'EDIT_AUTHOR',
      author
    })
  }
}

export default authorsActions
