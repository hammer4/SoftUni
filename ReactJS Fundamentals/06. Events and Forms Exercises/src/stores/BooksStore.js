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

  create (book) {
    book.id = data.books.length + 1
    book.author = Number(book.author)
    data.books.push(book)
    data.authors.find(a => a.id === Number(book.author)).books.push(Number(book.id))

    this.emit('book_created', book)
  }

  edit (book) {
    let bookToEdit = data.books.find(b => b.id === Number(book.id))
    if (bookToEdit.author !== Number(book.author)) {
      let oldAuthor = data.authors.find(a => a.id === Number(bookToEdit.author))
      let index = oldAuthor.books.indexOf(bookToEdit.id)
      oldAuthor.books.splice(index, 1)
      let newAuthor = data.authors.find(a => a.id === Number(book.author))
      newAuthor.books.push(Number(book.id))
    }

    bookToEdit.title = book.title
    bookToEdit.description = book.description
    bookToEdit.image = book.image
    bookToEdit.price = Number(book.price)
    bookToEdit.author = Number(book.author)

    this.emit('book_edited', bookToEdit)
  }

  handleAction (action) {
    switch (action.type) {
      case 'DELETE_BOOK': {
        this.deleteBook(action.id)
        break
      }
      case 'CREATE_BOOK': {
        this.create(action.book)
        break
      }
      case 'EDIT_BOOK': {
        this.edit(action.book)
        break
      }
      default: break
    }
  }
}

let booksStore = new BooksStore()
dispatcher.register(booksStore.handleAction.bind(booksStore))
export default booksStore
