import dispatcher from '../dispatcher'

let booksActions = {
  deleteBook: (id) => {
    dispatcher.dispatch({
      type: 'DELETE_BOOK',
      id
    })
  }
}

export default booksActions
