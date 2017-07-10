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

  getCommentById (id) {
    id = Number(id)
    return data.comments.find(c => c.id === id)
  }

  deleteComment (id) {
    id = Number(id)
    let index = this.comments.findIndex(i => i.id === id)
    this.comments.splice(index, 1)

    this.emit('change')
  }

  add (message, bookId) {
    let id = data.comments.length
    data.comments.push({
      id: id,
      message: message,
      book: Number(bookId)
    })
    data.books.find(b => b.id === Number(bookId)).comments.push(id)

    this.emit('comment_added')
  }

  edit (id, message) {
    id = Number(id)
    let comment = data.comments.find(c => c.id === id)
    comment.message = message

    this.emit('comment_edited')
  }

  handleAction (action) {
    switch (action.type) {
      case 'DELETE_COMMENT': {
        this.deleteComment(action.id)
        break
      }
      case 'ADD_COMMENT': {
        this.add(action.message, action.bookId)
        break
      }
      case 'EDIT_COMMENT': {
        this.edit(action.id, action.message)
        break
      }
      default: break
    }
  }
}

let commentsStore = new CommentsStore()
dispatcher.register(commentsStore.handleAction.bind(commentsStore))
export default commentsStore
