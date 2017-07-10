import React from 'react'
import CreateBookForm from './CreateBookForm'
import FormHelpers from '../common/FormHelpers'
import BookActions from '../../actions/BooksActions'
import BookStore from '../../stores/BooksStore'
import AuthorStore from '../../stores/AuthorsStore'
import toastr from 'toastr'

class CreateBookPage extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      book: {
        title: 'Eleven Minutes',
        price: 22.50,
        author: '1',
        image: 'http://t2.gstatic.com/images?q=tbn:ANd9GcRY8UMFykPB2BlkdVhnCoFcK0pyExkXCAtbw7j5qgoQr7FfGqWA',
        description: 'Eleven Minutes is a 2003 novel by Brazilian novelist Paulo Coelho that recounts the experiences of a young Brazilian prostitute and her journey to self-realisation through sexual experience.'
      },
      authors: [],
      error: ''
    }

    this.handleBookCreation = this.handleBookCreation.bind(this)
    BookStore.on('book_created', this.handleBookCreation)
  }

  componentDidMount () {
    let authors = AuthorStore.getAll()
    this.setState({
      authors: authors
    })
  }

  componentWillUnmount () {
    BookStore.removeListener('book_created', this.handleBookCreation)
  }

  handleBookChange (ev) {
    FormHelpers.handleFormChange.bind(this)(ev, 'book')
  }

  handleBookForm (ev) {
    ev.preventDefault()
    BookActions.create(this.state.book)
  }

  handleBookCreation (book) {
    toastr.success('Book added')
    this.props.history.push(`/books/${book.id}`)
  }

  render () {
    return (
      <div>
        <h1>Create book</h1>
        <CreateBookForm
          authors={this.state.authors}
          book={this.state.book}
          error={this.state.error}
          onChange={this.handleBookChange.bind(this)}
          onSave={this.handleBookForm.bind(this)} />
      </div>
    )
  }
}

export default CreateBookPage
