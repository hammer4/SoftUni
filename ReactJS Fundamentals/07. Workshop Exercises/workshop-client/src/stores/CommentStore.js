import {EventEmitter} from 'events'
import dispatcher from '../dispatcher'
import CommentActions from '../actions/CommentActions'
import CommentData from '../data/CommentData'

class CommentStore extends EventEmitter {
  create (message, id) {
    CommentData.create(message, id)
      .then(data => this.emit(this.eventTypes.COMMENT_CREATED, data))
  }

  getAll (id) {
    CommentData.getAll(id)
      .then(data => this.emit(this.eventTypes.COMMENTS_FETCHED, data))
  }

  handleAction (action) {
    switch (action.type) {
      case CommentActions.types.ADD_COMMENT: {
        this.create(action.message, action.id)
        break
      }
      case CommentActions.types.GET_ALL: {
        this.getAll(action.id)
        break
      }
      default: break
    }
  }
}

let commentStore = new CommentStore()
commentStore.eventTypes = {
  COMMENT_CREATED: 'comment_created',
  COMMENTS_FETCHED: 'comments_fetched'
}
dispatcher.register(commentStore.handleAction.bind(commentStore))
export default commentStore
