import {EventEmitter} from 'events'
import dispatcher from '../dispatcher'
import UserActions from '../actions/UserActions'
import UserData from '../data/UserData'

class UserStore extends EventEmitter {
  register (user) {
    UserData.register(user)
      .then(data => this.emit(this.eventTypes.USER_REGISTERED, data))
  }

  login (user) {
    UserData.login(user)
    .then(data => this.emit(this.eventTypes.USER_LOGGED_IN, data))
  }

  handleAction (action) {
    switch (action.type) {
      case UserActions.types.REGISTER_USER: {
        this.register(action.user)
        break
      }
      case UserActions.types.LOGIN_USER: {
        this.login(action.user)
        break
      }
      default: break
    }
  }
}

let userStore = new UserStore()
userStore.eventTypes = {
  USER_REGISTERED: 'user_registered',
  USER_LOGGED_IN: 'user_logged_in'
}
dispatcher.register(userStore.handleAction.bind(userStore))
export default userStore
