import dispatcher from '../dispatcher'

const hotelActions = {
  types: {
    CREATE_HOTEL: 'CREATE_HOTEL',
    ALL_HOTELS: 'ALL_HOTELS',
    DETAILS: 'DETAILS'
  },
  create (hotel) {
    dispatcher.dispatch({
      type: this.types.CREATE_HOTEL,
      hotel
    })
  },
  all (page) {
    page = page || 1
    dispatcher.dispatch({
      type: this.types.ALL_HOTELS,
      page
    })
  },
  details (id) {
    dispatcher.dispatch({
      type: this.types.DETAILS,
      id
    })
  }
}

export default hotelActions
