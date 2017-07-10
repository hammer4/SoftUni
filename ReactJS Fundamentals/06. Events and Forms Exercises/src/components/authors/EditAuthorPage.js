import React from 'react'
import EditAuthorForm from './EditAuthorForm'
import FormHelpers from '../common/FormHelpers'
import AuthorActions from '../../actions/AuthorsActions'
import AuthorStore from '../../stores/AuthorsStore'
import toastr from 'toastr'

class EditAuthorPage extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      author: {
        id: this.props.match.params.id,
        name: '',
        image: ''
      },
      error: ''
    }
    this.handleAuthorEditing = this.handleAuthorEditing.bind(this)
    AuthorStore.on('author_edited', this.handleAuthorEditing)
  }

  componentWillUnmount () {
    AuthorStore.removeListener('author_edited', this.handleAuthorEditing)
  }

  componentDidMount () {
    let author = AuthorStore.getAuthorById(this.state.author.id)
    this.setState({
      author: author
    })
  }

  handleAuthorChange (ev) {
    FormHelpers.handleFormChange.bind(this)(ev, 'author')
  }

  handleAuthorForm (ev) {
    ev.preventDefault()
    AuthorActions.edit(this.state.author)
  }

  handleAuthorEditing (author) {
    toastr.success('Author edited')
    this.props.history.push(`/authors/${author.id}`)
  }

  render () {
    return (
      <div>
        <h1>Edit author</h1>
        <EditAuthorForm
          author={this.state.author}
          error={this.state.error}
          onChange={this.handleAuthorChange.bind(this)}
          onSave={this.handleAuthorForm.bind(this)} />
      </div>
    )
  }
}

export default EditAuthorPage
