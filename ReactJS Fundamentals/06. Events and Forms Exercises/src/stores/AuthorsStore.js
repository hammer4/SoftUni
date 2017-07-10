import { EventEmitter } from 'events'
import dispatcher from '../dispatcher'
import data from '../Data'

class AuthorsStore extends EventEmitter {
  constructor () {
    super()

    this.authors = data.authors
  }

  getAll () {
    return this.authors
  }

  getAuthorById (id) {
    id = Number(id)
    return this.authors.find(a => a.id === id)
  }

  getAuthorByBook (bookId) {
    bookId = Number(bookId)
    return this.authors.filter(a => a.books.indexOf(bookId) > -1)[0]
  }

  deleteAuthor (id) {
    id = Number(id)
    let index = this.authors.findIndex(i => i.id === id)
    this.authors.splice(index, 1)
  }

  create (author) {
    author.id = data.authors.length + 1
    author.books = []
    data.authors.push(author)

    this.emit('author_created', author)
  }

  edit (author) {
    let authorForEditing = data.authors.find(a => a.id === Number(author.id))
    authorForEditing.name = author.name
    authorForEditing.image = author.image

    this.emit('author_edited', author)
  }

  handleAction (action) {
    switch (action.type) {
      case 'DELETE_AUTHOR': {
        this.deleteAuthor(action.id)
        break
      }
      case 'CREATE_AUTHOR': {
        this.create(action.author)
        break
      }
      case 'EDIT_AUTHOR': {
        this.edit(action.author)
        break
      }
      default: break
    }
  }
}

let authorsStore = new AuthorsStore()
dispatcher.register(authorsStore.handleAction.bind(authorsStore))
export default authorsStore
