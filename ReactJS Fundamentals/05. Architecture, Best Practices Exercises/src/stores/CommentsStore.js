import { EventEmitter } from 'events'
import dispatcher from '../dispatcher'
import data from '../Data'

class CommentsStore extends EventEmitter {
  constructor () {
    super()

    this.comments = data.comments
  }

  getCommentsByBook (bookId) {
    bookId = Number(bookId)
    return this.comments.filter(c => c.book === bookId)
  }

  deleteComment (id) {
    id = Number(id)
    let index = this.comments.findIndex(i => i.id === id)
    this.comments.splice(index, 1)

    this.emit('change')
  }

  handleAction (action) {
    switch (action.type) {
      case 'DELETE_COMMENT': {
        this.deleteComment(action.id)
        break
      }
      default: break
    }
  }
}

let commentsStore = new CommentsStore()
dispatcher.register(commentsStore.handleAction.bind(commentsStore))
export default commentsStore
