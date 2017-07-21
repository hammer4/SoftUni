import {EventEmitter} from 'events'
import dispatcher from '../dispatcher'
import HomeActions from '../actions/HomeActions'
import HomeData from '../data/HomeData'

class HomeStore extends EventEmitter {
  getStats () {
    HomeData.getStats().then(data => this.emit(this.eventTypes.STATS_FETCHED, data))
  }

  handleAction (action) {
    switch (action.type) {
      case HomeActions.types.GET_STATS: {
        this.getStats()
        break
      }
      default: break
    }
  }
}

let homeStore = new HomeStore()
homeStore.eventTypes = {
  STATS_FETCHED: 'stats_fetched'
}
dispatcher.register(homeStore.handleAction.bind(homeStore))
export default homeStore
