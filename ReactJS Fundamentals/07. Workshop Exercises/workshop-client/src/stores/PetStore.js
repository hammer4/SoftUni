import {EventEmitter} from 'events'
import dispatcher from '../dispatcher'
import PetActions from '../actions/PetActions'
import PetData from '../data/PetData'

class PetStore extends EventEmitter {
  create (pet) {
    PetData.create(pet)
      .then(data => this.emit(this.eventTypes.PET_CREATED, data))
  }

  all (page) {
    page = page || 1
    PetData.all(page)
      .then(data => this.emit(this.eventTypes.PETS_FETCHED, data))
  }

  details (id) {
    PetData.details(id)
      .then(data => this.emit(this.eventTypes.PET_DETAILS_FETCHED, data))
  }

  handleAction (action) {
    switch (action.type) {
      case PetActions.types.CREATE_PET: {
        this.create(action.pet)
        break
      }
      case PetActions.types.ALL_PETS: {
        this.all(action.page)
        break
      }
      case PetActions.types.DETAILS: {
        this.details(action.id)
        break
      }
      default: break
    }
  }
}

let petStore = new PetStore()
petStore.eventTypes = {
  PET_CREATED: 'pet_created',
  PETS_FETCHED: 'pets_fetched',
  PET_DETAILS_FETCHED: 'pets_details_fetched'
}
dispatcher.register(petStore.handleAction.bind(petStore))
export default petStore
