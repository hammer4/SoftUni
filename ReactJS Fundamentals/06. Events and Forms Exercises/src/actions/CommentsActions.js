import dispatcher from '../dispatcher'

let commentsActions = {
  deleteComment: (id) => {
    dispatcher.dispatch({
      type: 'DELETE_COMMENT',
      id
    })
  },
  add: (message, bookId) => {
    dispatcher.dispatch({
      type: 'ADD_COMMENT',
      message,
      bookId
    })
  },
  edit: (id, message) => {
    dispatcher.dispatch({
      type: 'EDIT_COMMENT',
      id,
      message
    })
  }
}

export default commentsActions
