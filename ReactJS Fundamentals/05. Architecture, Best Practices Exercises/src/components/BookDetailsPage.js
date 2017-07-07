import React from 'react'
import {Link} from 'react-router-dom'
import BooksStore from '../stores/BooksStore'
import AuthorsStore from '../stores/AuthorsStore'
import CommentsStore from '../stores/CommentsStore'
import BooksActions from '../actions/BooksActions'

export default class BooksDetailsPage extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      book: {
        id: this.props.match.params.id
      },
      author: {},
      comments: []
    }

    BooksStore.on('change', () => {
      this.getBook()
    })
  }

  componentWillMount () {
    this.getBook()
  }

  getBook () {
    let book = BooksStore.getBookById(this.state.book.id)
    let author = AuthorsStore.getAuthorByBook(this.state.book.id)
    let comments = CommentsStore.getCommentsByBook(this.state.book.id)

    this.setState({
      book: book,
      author: author,
      comments: comments
    })
  }

  deleteBook () {
    BooksActions.deleteBook(Number(this.state.book.id))
    this.props.history.push('/books/all')
  }

  deleteComment (event) {
    let id = event.target.parentElement.id
    CommentsStore.deleteComment(id)
    let comments = CommentsStore.getCommentsByBook(this.state.book.id)
    this.setState({
      comments: comments
    })
  }

  render () {
    let comments = this.state.comments.map(c => {
      return (
        <p className='comment' key={c.id} id={c.id}>{c.message} <button onClick={this.deleteComment.bind(this)}>Delete</button></p>
      )
    })

    return (
      <div className='book-info'>
        <img src={this.state.book.image} alt='book' />
        <h2>{this.state.book.title}</h2>
        <p>{this.state.book.description}</p>
        <p>Price: ${this.state.book.price}</p>
        <p>Author: <Link to={`/authors/${this.state.author.id}`}>{this.state.author.name}</Link></p>
        <button onClick={this.deleteBook.bind(this)}>Delete</button>
        <h4>Comments for this book:</h4>
        {comments}
      </div>
    )
  }
}
