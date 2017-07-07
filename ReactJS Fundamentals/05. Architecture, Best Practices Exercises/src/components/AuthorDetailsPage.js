import React from 'react'
import {Link} from 'react-router-dom'
import BooksStore from '../stores/BooksStore'
import AuthorsStore from '../stores/AuthorsStore'
import AuthorsActions from '../actions/AuthorsActions'

export default class AuthorDetailsPage extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      id: this.props.match.params.id,
      name: '',
      image: '',
      books: []
    }

    AuthorsStore.on('change', () => {
      this.getAuthor()
    })
  }

  getAuthor () {
    let author = AuthorsStore.getAuthorById(this.state.id)
    let books = BooksStore.getBooksByAuthor(this.state.id)
    this.setState({
      name: author.name,
      image: author.image,
      books: books
    })
  }

  componentWillMount () {
    this.getAuthor()
  }

  deleteAuthor () {
    AuthorsActions.deleteAuthor(this.state.id)
    this.props.history.push('/authors/all')
  }

  render () {
    let booksElements = this.state.books.map((book, index) => {
      return (
        <div key={index} className='book'>
          <Link to={`/books/${book.id}`} >
            <h3>{book.title}</h3>
            <img src={book.image} alt='book' />
          </Link>
          <p>{book.description}</p>
        </div>
      )
    })

    return (
      <div className='authorDetails'>
        <div className='authorInfo'>
          <img src={this.state.image} alt='author' />
          <h2>{this.state.name}</h2>
        </div>
        <button onClick={this.deleteAuthor.bind(this)}>Delete</button>
        <h3>Books by this author:</h3>
        {booksElements}
      </div>
    )
  }
}
