import dispatcher from '../dispatcher'

const carActions = {
  types: {
    CREATE_CAR: 'CREATE_CAR',
    ALL_CARS: 'ALL_CARS',
    DETAILS: 'DETAILS',
    GET_USER_CARS: 'GET_USER_CARS',
    DELETE_CAR: 'DELETE_CAR',
    LIKE_CAR: 'LIKE_CAR'
  },
  create (car) {
    dispatcher.dispatch({
      type: this.types.CREATE_CAR,
      car
    })
  },
  all (page, search) {
    page = page || 1
    search = search || ''
    dispatcher.dispatch({
      type: this.types.ALL_CARS,
      page,
      search
    })
  },
  details (id) {
    dispatcher.dispatch({
      type: this.types.DETAILS,
      id
    })
  },
  getUserCars () {
    dispatcher.dispatch({
      type: this.types.GET_USER_CARS
    })
  },
  delete (id) {
    dispatcher.dispatch({
      type: this.types.DELETE_CAR,
      id
    })
  },
  like (id) {
    dispatcher.dispatch({
      type: this.types.LIKE_CAR,
      id
    })
  }
}

export default carActions
