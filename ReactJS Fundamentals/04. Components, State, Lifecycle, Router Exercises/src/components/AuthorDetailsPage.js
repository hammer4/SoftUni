import data from '../Data'
import React from 'react'
import {Link} from 'react-router-dom'

export default class AuthorDetailsPage extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      id: this.props.match.params.id,
      name: '',
      image: '',
      books: []
    }
  }

  componentDidMount () {
    data.getAuthorById(this.state.id)
      .then(author => {
        data.getBooksByAuthor(this.state.id).then(books => {
          this.setState({
            name: author.name,
            image: author.image,
            books: books
          })
        })
      })
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
        <h3>Books by this author:</h3>
        {booksElements}
      </div>
    )
  }
}
