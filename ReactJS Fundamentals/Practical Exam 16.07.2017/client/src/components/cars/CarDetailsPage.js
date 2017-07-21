import React from 'react'
import CarActions from '../../actions/CarActions'
import CarStore from '../../stores/CarStore'
import ReviewActions from '../../actions/ReviewActions'
import ReviewStore from '../../stores/ReviewStore'
import toastr from 'toastr'

class PetDetailsPage extends React.Component {
  constructor (props) {
    super(props)

    let id = this.props.match.params.id
    this.state = {
      car: {
        id
      },
      rating: 0,
      comment: '',
      error: '',
      reviews: []
    }

    this.carDetailsFetched = this.carDetailsFetched.bind(this)
    this.handleReviewCreation = this.handleReviewCreation.bind(this)
    this.reviewsFetched = this.reviewsFetched.bind(this)
    this.handleCarLike = this.handleCarLike.bind(this)
    ReviewStore.on(ReviewStore.eventTypes.REVIEW_CREATED, this.handleReviewCreation)
    CarStore.on(CarStore.eventTypes.CAR_DETAILS_FETCHED, this.carDetailsFetched)
    ReviewStore.on(ReviewStore.eventTypes.REVIEWS_FETCHED, this.reviewsFetched)
    CarStore.on(CarStore.eventTypes.CAR_LIKED, this.handleCarLike)
  }

  componentDidMount () {
    CarActions.details(this.state.car.id)
    ReviewActions.getAll(this.state.car.id)
  }

  componentWillUnmount () {
    CarStore.removeListener(CarStore.eventTypes.CAR_DETAILS_FETCHED, this.carDetailsFetched)
    ReviewStore.removeListener(ReviewStore.eventTypes.REVIEW_CREATED, this.handleReviewCreation)
    ReviewStore.removeListener(ReviewStore.eventTypes.REVIEWS_FETCHED, this.reviewsFetched)
    CarStore.removeListener(CarStore.eventTypes.CAR_LIKED, this.handleCarLike)
  }

  carDetailsFetched (data) {
    this.setState({
      car: data
    })
  }

  reviewsFetched (data) {
    this.setState({
      reviews: data
    })
  }

  handleRatingChange (ev) {
    let value = ev.target.value
    this.setState({
      rating: value
    })
  }

  handleCommentChange (ev) {
    let value = ev.target.value
    this.setState({
      comment: value
    })
  }

  handleReviewForm (ev) {
    ev.preventDefault()
    if (this.state.rating < 1 || this.state.rating > 5) {
      this.setState({
        error: 'Rating must be between 1 and 5'
      })
    }
    ReviewActions.create({
      rating: this.state.rating,
      comment: this.state.comment
    },
    this.state.car.id)
  }

  handleReviewCreation (data) {
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
        comment: '',
        rating: 0,
        error: ''
      })
      ReviewActions.getAll(this.state.car.id)
    }
  }

  like () {
    CarActions.like(this.state.car.id)
  }

  handleCarLike (data) {
    toastr.success(data.message)
    CarActions.details(this.state.car.id)
  }

  render () {
    let reviews = this.state.reviews.map((r, i) => (
      <div key={i}>
        <p>{r.comment} - {r.rating}</p>
        <p>on: {r.createdOn} by {r.user}</p>
      </div>
    ))

    return (
      <div className='car-details'>
        <img src={this.state.car.image} alt='car' />
        <h2>Make: {this.state.car.make}</h2>
        <p>Model: {this.state.car.model}</p>
        <p>Engine: {this.state.car.engine}</p>
        <p>Year: {this.state.car.year}</p>
        <p>Price: {this.state.car.price}</p>
        {this.state.car.mileage ? <p>Mileage: {this.state.car.mileage}</p> : null}
        <button onClick={this.like.bind(this)}>{this.state.car.likes} Like</button>
        <h3>Add review: </h3>
        <form>
          <div>{this.state.error}</div>
          <div>
            <label htmlFor='rating'>Rating</label>
            <input
              type='number'
              name='rating'
              value={this.state.rating}
              onChange={this.handleRatingChange.bind(this)} />
          </div>
          <div>
            <label htmlFor='comment'>Your comment</label>
            <textarea
              name='comment'
              rows='10'
              cols='80'
              value={this.state.comment}
              onChange={this.handleCommentChange.bind(this)} />
          </div>
          <input type='submit' onClick={this.handleReviewForm.bind(this)} />
        </form>
        <h3>Reviews:</h3>
        {reviews}
      </div>
    )
  }
}

export default PetDetailsPage
