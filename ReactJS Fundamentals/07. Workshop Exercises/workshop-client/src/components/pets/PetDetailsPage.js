import React from 'react'
import PetActions from '../../actions/PetActions'
import PetStore from '../../stores/PetStore'
import CommentActions from '../../actions/CommentActions'
import CommentStore from '../../stores/CommentStore'
import toastr from 'toastr'

class PetDetailsPage extends React.Component {
  constructor (props) {
    super(props)

    let id = this.props.match.params.id
    this.state = {
      pet: {
        id
      },
      message: '',
      error: '',
      comments: []
    }

    this.petDetailsFetched = this.petDetailsFetched.bind(this)
    this.handleCommentCreation = this.handleCommentCreation.bind(this)
    this.commentsFetched = this.commentsFetched.bind(this)
    CommentStore.on(CommentStore.eventTypes.COMMENT_CREATED, this.handleCommentCreation)
    PetStore.on(PetStore.eventTypes.PET_DETAILS_FETCHED, this.petDetailsFetched)
    CommentStore.on(CommentStore.eventTypes.COMMENTS_FETCHED, this.commentsFetched)
  }

  componentDidMount () {
    PetActions.details(this.state.pet.id)
    CommentActions.getAll(this.state.pet.id)
  }

  componentWillUnmount () {
    PetStore.removeListener(PetStore.eventTypes.PET_DETAILS_FETCHED, this.petDetailsFetched)
    CommentStore.removeListener(CommentStore.eventTypes.COMMENT_CREATED, this.handleCommentCreation)
    CommentStore.removeListener(CommentStore.eventTypes.COMMENTS_FETCHED, this.commentsFetched)
  }

  petDetailsFetched (data) {
    this.setState({
      pet: data
    })
  }

  commentsFetched (data) {
    this.setState({
      comments: data
    })
  }

  handleCommentChange (ev) {
    let value = ev.target.value
    this.setState({
      message: value
    })
  }

  handleCommentForm (ev) {
    ev.preventDefault()
    CommentActions.create(this.state.message, this.state.pet.id)
  }

  handleCommentCreation (data) {
    if (!data.success) {
      let firstError = data.message

      if (data.errors) {
        firstError = Object.keys(data.errors).map(k => data.errors[k])[0]
      }

      this.setState({
        error: firstError
      })
    } else {
      toastr.success(data.message)
      this.setState({
        message: ''
      })
      CommentActions.getAll(this.state.pet.id)
    }
  }

  render () {
    let comments = this.state.comments.map((c, i) => (
      <div key={i}>{c.message} - {c.user}</div>
    ))

    return (
      <div>
        <img src={this.state.pet.image} alt='pet' />
        <h2>Name: {this.state.pet.name}</h2>
        <p>Age: {this.state.pet.age}</p>
        <p>Type: {this.state.pet.type}</p>
        {this.state.pet.breed ? <p>Breed: {this.state.pet.breed}</p> : null}
        <h3>Add comment: </h3>
        <form>
          <div>{this.state.error}</div>
          <textarea
            name='message'
            value={this.state.message}
            rows='10'
            cols='80'
            onChange={this.handleCommentChange.bind(this)} />
          <input type='submit' onClick={this.handleCommentForm.bind(this)} />
        </form>
        <h3>Comments:</h3>
        {comments}
      </div>
    )
  }
}

export default PetDetailsPage
