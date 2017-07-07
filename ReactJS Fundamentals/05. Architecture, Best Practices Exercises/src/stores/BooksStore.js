import { EventEmitter } from 'events'
import dispatcher from '../dispatcher'
import data from '../Data'

class BooksStore extends EventEmitter {
  constructor () {
    super()

    this.books = data.books
  }

  getAll () {
    return this.books
  }

  getBookById (bookId) {
    bookId = Number(bookId)
    return this.books.filter(b => b.id === bookId)[0]
  }

  getBooksByAuthor (authorId) {
    authorId = Number(authorId)
    return this.books.filter(b => b.author === authorId)
  }

  deleteBook (id) {
    id = Number(id)
    let index = this.books.findIndex(i => i.id === id)
    this.books.splice(index, 1)

    this.emit('change')
  }

  handleAction (action) {
    console.log(action)
    switch (action.type) {
      case 'DELETE_BOOK': {
        this.deleteBook(action.id)
        break
      }
      default: break
    }
  }
}

let booksStore = new BooksStore()
dispatcher.register(booksStore.handleAction.bind(booksStore))
export default booksStore
