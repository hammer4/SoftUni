import data from '../Data'
import React from 'react'
import {Link} from 'react-router-dom'

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
  }

  componentDidMount () {
    data.getBookById(this.state.book.id).then(book => {
      data.getAuthorById(book.author).then(author => {
        data.getCommentsByBook(book.id).then(comments => {
          this.setState({
            book: book,
            author: author,
            comments: comments
          })
        })
      })
    })
  }

  render () {
    let comments = this.state.comments.map(c => {
      return (
        <p className='comment' key={c.id}>{c.message}</p>
      )
    })

    return (
      <div className='book-info'>
        <img src={this.state.book.image} alt='book' />
        <h2>{this.state.book.title}</h2>
        <p>{this.state.book.description}</p>
        <p>Price: ${this.state.book.price}</p>
        <p>Author: <Link to={`/authors/${this.state.author.id}`}>{this.state.author.name}</Link></p>
        <h4>Comments for this book:</h4>
        {comments}
      </div>
    )
  }
}
