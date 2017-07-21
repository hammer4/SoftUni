import dispatcher from '../dispatcher'

const homeActions = {
  types: {
    GET_STATS: 'GET_STATS'
  },
  getStats () {
    dispatcher.dispatch({
      type: this.types.GET_STATS
    })
  }
}

export default homeActions
