import {EventEmitter} from 'events'
import dispatcher from '../dispatcher'
import ReviewActions from '../actions/ReviewActions'
import ReviewData from '../data/ReviewData'

class ReviewStore extends EventEmitter {
  create (review, id) {
    ReviewData.create(review, id)
      .then(data => this.emit(this.eventTypes.REVIEW_CREATED, data))
  }

  getAll (id) {
    ReviewData.getAll(id)
      .then(data => this.emit(this.eventTypes.REVIEWS_FETCHED, data))
  }

  handleAction (action) {
    switch (action.type) {
      case ReviewActions.types.ADD_REVIEW: {
        this.create(action.review, action.id)
        break
      }
      case ReviewActions.types.GET_ALL: {
        this.getAll(action.id)
        break
      }
      default: break
    }
  }
}

let reviewStore = new ReviewStore()
reviewStore.eventTypes = {
  REVIEW_CREATED: 'review_created',
  REVIEWS_FETCHED: 'reviews_fetched'
}
dispatcher.register(reviewStore.handleAction.bind(reviewStore))
export default reviewStore
