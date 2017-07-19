import {EventEmitter} from 'events'
import dispatcher from '../dispatcher'
import HotelActions from '../actions/HotelActions'
import HotelData from '../data/HotelData'

class HotelStore extends EventEmitter {
  create (hotel) {
    HotelData.create(hotel).then(data => this.emit(this.eventTypes.HOTEL_CREATED, data))
  }

  all (page) {
    page = page || 1
    HotelData.all(page)
      .then(data => this.emit(this.eventTypes.HOTELS_FETCHED, data))
  }

  details (id) {
    HotelData.details(id)
      .then(data => this.emit(this.eventTypes.HOTEL_DETAILS_FETCHED, data))
  }

  handleAction (action) {
    switch (action.type) {
      case HotelActions.types.CREATE_HOTEL: {
        this.create(action.hotel)
        break
      }
      case HotelActions.types.ALL_HOTELS: {
        this.all(action.page)
        break
      }
      case HotelActions.types.DETAILS: {
        this.details(action.id)
        break
      }
      default: break
    }
  }
}

let hotelStore = new HotelStore()
hotelStore.eventTypes = {
  HOTEL_CREATED: 'hotel_created',
  HOTELS_FETCHED: 'hotels_fetched',
  HOTEL_DETAILS_FETCHED: 'hotel_details_fetched'
}
dispatcher.register(hotelStore.handleAction.bind(hotelStore))
export default hotelStore
