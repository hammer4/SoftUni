import React from 'react'
import {Link} from 'react-router-dom'
import BooksStore from '../../stores/BooksStore'
import AuthorsStore from '../../stores/AuthorsStore'
import CommentsStore from '../../stores/CommentsStore'
import BooksActions from '../../actions/BooksActions'
import CommentActions from '../../actions/CommentsActions'
import Auth from '../users/Auth'
import toastr from 'toastr'

export default class BooksDetailsPage extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      book: {
        id: this.props.match.params.id
      },
      author: {},
      comments: [],
      message: ''
    }

    BooksStore.on('change', () => {
      this.getBook()
    })

    this.handleCommentCreation = this.handleCommentCreation.bind(this)
    CommentsStore.on('comment_added', this.handleCommentCreation)
  }

  componentWillMount () {
    this.getBook()
  }

  componentWillUnmount () {
    CommentsStore.removeListener('comment_added', this.handleCommentCreation)
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
    CommentActions.deleteComment(id)
    let comments = CommentsStore.getCommentsByBook(this.state.book.id)
    this.setState({
      comments: comments
    })
  }

  onCommentChange (ev) {
    let message = ev.target.value
    this.setState({
      message: message
    })
  }

  handleCommentCreation () {
    toastr.success('Comment added')
    let comments = CommentsStore.getCommentsByBook(this.state.book.id)
    this.setState({
      comments: comments
    })
  }

  handleCommentForm (ev) {
    ev.preventDefault()
    CommentActions.add(this.state.message, this.state.book.id)
    this.setState({
      message: ''
    })
  }

  render () {
    let comments = this.state.comments.map(c => {
      return (
        <p className='comment' key={c.id} id={c.id}>{c.message}
          <button onClick={this.deleteComment.bind(this)}>Delete</button>
          {Auth.isUserAuthenticated() ? <button><Link to={`/comments/edit/${c.id}`}>Edit</Link></button>
          : null}</p>
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
        {Auth.isUserAuthenticated() ?
          <button><Link to={`/books/edit/${this.state.book.id}`}>Edit</Link></button> : null}
        {Auth.isUserAuthenticated() ?
          <form>
            <h4>Add comment</h4>
            <textarea name='message'
              rows='3' cols='80'
              value={this.state.message}
              onChange={this.onCommentChange.bind(this)} />
            <input type='submit' onClick={this.handleCommentForm.bind(this)} />
          </form>
          : null }
        <h4>Comments for this book:</h4>
        {comments}
      </div>
    )
  }
}
