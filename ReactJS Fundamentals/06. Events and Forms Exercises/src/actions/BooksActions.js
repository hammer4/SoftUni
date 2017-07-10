import dispatcher from '../dispatcher'

let booksActions = {
  deleteBook: (id) => {
    dispatcher.dispatch({
      type: 'DELETE_BOOK',
      id
    })
  },
  create: (book) => {
    dispatcher.dispatch({
      type: 'CREATE_BOOK',
      book
    })
  },
  edit: (book) => {
    dispatcher.dispatch({
      type: 'EDIT_BOOK',
      book
    })
  }
}

export default booksActions
