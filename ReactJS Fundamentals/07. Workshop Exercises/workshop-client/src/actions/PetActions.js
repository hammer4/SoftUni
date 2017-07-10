import dispatcher from '../dispatcher'

const petActions = {
  types: {
    CREATE_PET: 'CREATE_PET',
    ALL_PETS: 'ALL_PETS',
    DETAILS: 'DETAILS'
  },
  create (pet) {
    dispatcher.dispatch({
      type: this.types.CREATE_PET,
      pet
    })
  },
  all (page) {
    page = page || 1
    dispatcher.dispatch({
      type: this.types.ALL_PETS,
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

export default petActions
