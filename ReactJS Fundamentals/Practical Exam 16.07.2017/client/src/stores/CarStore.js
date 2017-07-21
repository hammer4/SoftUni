import {EventEmitter} from 'events'
import dispatcher from '../dispatcher'
import CarActions from '../actions/CarActions'
import CarData from '../data/CarData'

class CarStore extends EventEmitter {
  create (car) {
    CarData.create(car).then(data => this.emit(this.eventTypes.CAR_CREATED, data))
  }

  all (page, search) {
    page = page || 1
    CarData.all(page, search)
      .then(data => this.emit(this.eventTypes.CARS_FETCHED, data))
  }

  details (id) {
    CarData.details(id)
      .then(data => this.emit(this.eventTypes.CAR_DETAILS_FETCHED, data))
  }

  getUserCars () {
    CarData.getUserCars()
      .then(data => this.emit(this.eventTypes.USER_CARS_FETCHED, data))
  }

  delete (id) {
    CarData.delete(id)
      .then(data => this.emit(this.eventTypes.CAR_DELETED, data))
  }

  like (id) {
    CarData.like(id)
      .then(data => this.emit(this.eventTypes.CAR_LIKED, data))
  }

  handleAction (action) {
    switch (action.type) {
      case CarActions.types.CREATE_CAR: {
        this.create(action.car)
        break
      }
      case CarActions.types.ALL_CARS: {
        this.all(action.page, action.search)
        break
      }
      case CarActions.types.DETAILS: {
        this.details(action.id)
        break
      }
      case CarActions.types.GET_USER_CARS: {
        this.getUserCars()
        break
      }
      case CarActions.types.DELETE_CAR: {
        this.delete(action.id)
        break
      }
      case CarActions.types.LIKE_CAR: {
        this.like(action.id)
        break
      }
      default: break
    }
  }
}

let carStore = new CarStore()
carStore.eventTypes = {
  CAR_CREATED: 'car_created',
  CARS_FETCHED: 'cars_fetched',
  CAR_DETAILS_FETCHED: 'cars_details_fetched',
  USER_CARS_FETCHED: 'user_cars_fetched',
  CAR_DELETED: 'car_deleted',
  CAR_LIKED: 'car_liked'
}
dispatcher.register(carStore.handleAction.bind(carStore))
export default carStore
