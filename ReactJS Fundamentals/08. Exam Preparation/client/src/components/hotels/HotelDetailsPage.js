import React from 'react'
import HotelActions from '../../actions/HotelActions'
import HotelStore from '../../stores/HotelStore'
import ReviewActions from '../../actions/ReviewActions'
import ReviewStore from '../../stores/ReviewStore'
import toastr from 'toastr'

class HotelDetailsPage extends React.Component {
  constructor (props) {
    super(props)

    let id = this.props.match.params.id
    this.state = {
      hotel: {
        id
      },
      rating: 0,
      comment: '',
      error: '',
      reviews: []
    }

    this.hotelDetailsFetched = this.hotelDetailsFetched.bind(this)
    this.handleReviewCreation = this.handleReviewCreation.bind(this)
    this.reviewsFetched = this.reviewsFetched.bind(this)
    ReviewStore.on(ReviewStore.eventTypes.REVIEW_CREATED, this.handleReviewCreation)
    HotelStore.on(HotelStore.eventTypes.HOTEL_DETAILS_FETCHED, this.hotelDetailsFetched)
    ReviewStore.on(ReviewStore.eventTypes.REVIEWS_FETCHED, this.reviewsFetched)
  }

  componentDidMount () {
    HotelActions.details(this.state.hotel.id)
    ReviewActions.getAll(this.state.hotel.id)
  }

  componentWillUnmount () {
    HotelStore.removeListener(HotelStore.eventTypes.HOTEL_DETAILS_FETCHED, this.hotelDetailsFetched)
    ReviewStore.removeListener(ReviewStore.eventTypes.REVIEW_CREATED, this.handleReviewCreation)
    ReviewStore.removeListener(ReviewStore.eventTypes.REVIEWS_FETCHED, this.reviewsFetched)
  }

  hotelDetailsFetched (data) {
    this.setState({
      hotel: data
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
      return
    }
    ReviewActions.create({
      rating: this.state.rating,
      comment: this.state.comment
    },
    this.state.hotel.id)
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
      ReviewActions.getAll(this.state.hotel.id)
    }
  }

  render () {
    let reviews = this.state.reviews.map((r, i) => (
      <div key={i}>
        <p>{r.comment} - {r.rating}</p>
        <p>on: {r.createdOn} by {r.user}</p>
      </div>
    ))

    return (
      <div className='hotel-details'>
        <img src={this.state.hotel.image} alt='hotel' />
        <h2>Name: {this.state.hotel.name}</h2>
        <p>Location: {this.state.hotel.location}</p>
        <p>Description: {this.state.hotel.description}</p>
        <p>Rooms: {this.state.hotel.numberOfRooms}</p>
        {this.state.hotel.parkingSlots ? <p>Parking slots: {this.state.hotel.parkingSlots}</p> : null}
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

export default HotelDetailsPage
