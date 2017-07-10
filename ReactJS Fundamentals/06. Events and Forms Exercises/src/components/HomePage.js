import React from 'react'
import {Link} from 'react-router-dom'
import BooksStore from '../stores/BooksStore'
import AuthorsStore from '../stores/AuthorsStore'

export default class HomePage extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      books: []
    }

    BooksStore.on('change', () => {
      this.getBooks()
    })
  }

  getBooks () {
    let books = BooksStore.getAll()
    books = books.sort((a, b) => new Date(a.date) - new Date(b.date))
    for (let book of books) {
      book.authorName = AuthorsStore.getAuthorByBook(book.id).name
    }
    this.setState({
      books: books
    })
  }

  componentDidMount () {
    this.getBooks()
  }

  render () {
    let bookNodes = this.state.books.map(b => {
      return (
        <div className='book' key={b.id}>
          <Link to={`/books/${b.id}`}>
            <img src={b.image} alt='cover' />
            <h3>{b.title}</h3>
          </Link>
          <p>Author: <Link to={`/authors/${b.author}`}>{b.authorName}</Link></p>
        </div>
      )
    })

    return (
      <div>
        {bookNodes}
      </div>
    )
  }
}
