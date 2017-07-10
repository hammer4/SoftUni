import React from 'react'
import EditBookForm from './EditBookForm'
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
        id: this.props.match.params.id,
        title: '',
        price: '',
        author: '',
        image: '',
        description: ''
      },
      authors: [],
      error: ''
    }

    this.handleBookEditing = this.handleBookEditing.bind(this)
    BookStore.on('book_edited', this.handleBookEditing)
  }

  componentDidMount () {
    let authors = AuthorStore.getAll()
    let book = JSON.parse(JSON.stringify(BookStore.getBookById(this.state.book.id)))
    this.setState({
      book: book,
      authors: authors
    })
  }

  componentWillUnmount () {
    BookStore.removeListener('book_edited', this.handleBookEditing)
  }

  handleBookChange (ev) {
    FormHelpers.handleFormChange.bind(this)(ev, 'book')
  }

  handleBookForm (ev) {
    ev.preventDefault()
    BookActions.edit(this.state.book)
  }

  handleBookEditing (book) {
    toastr.success('Book edited')
    this.props.history.push(`/books/${book.id}`)
  }

  render () {
    return (
      <div>
        <h1>Edit book</h1>
        <EditBookForm
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
