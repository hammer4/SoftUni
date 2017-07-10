import React from 'react'
import CommentStore from '../../stores/CommentsStore'
import CommentsActions from '../../actions/CommentsActions'
import toastr from 'toastr'

class EditCommentPage extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      id: this.props.match.params.id,
      message: ''
    }

    this.handleCommentEdit = this.handleCommentEdit.bind(this)
    CommentStore.on('comment_edited', this.handleCommentEdit)
  }

  componentDidMount () {
    let message = CommentStore.getCommentById(this.state.id).message
    this.setState({
      message: message
    })
  }

  handleFormChange (ev) {
    let message = ev.target.value
    this.setState({
      message: message
    })
  }

  handleFormSubmit (ev) {
    ev.preventDefault()
    CommentsActions.edit(this.state.id, this.state.message)
  }

  handleCommentEdit () {
    toastr.success('CommentEdited')
    this.props.history.push('/books/all')
  }

  render () {
    return (
      <form>
        <textarea
          onChange={this.handleFormChange.bind(this)}
          name='message'
          value={this.state.message}
          rows='5' cols='80' />
        <input type='submit' onClick={this.handleFormSubmit.bind(this)} />
      </form>
    )
  }
}

export default EditCommentPage
