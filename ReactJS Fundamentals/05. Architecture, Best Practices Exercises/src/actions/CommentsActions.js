import dispatcher from '../dispatcher'

let commentsActions = {
  deleteComment: (id) => {
    dispatcher.dispatch({
      type: 'DELETE_COMMENT',
      id
    })
  }
}

export default commentsActions
