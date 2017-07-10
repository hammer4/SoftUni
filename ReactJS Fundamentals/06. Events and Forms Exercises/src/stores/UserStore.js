import {EventEmitter} from 'events'
import dispatcher from '../dispatcher'
import UserActions from '../actions/UserActions'
import Data from '../Data'

class UserStore extends EventEmitter {
  register (user) {
    Data.users.push(user)

    this.emit(this.eventTypes.USER_REGISTERED, user)
  }

  login (user) {
    let existingUser = Data.users.find(u => u.username === user.username && u.password === user.password)

    this.emit(this.eventTypes.USER_LOGGED_IN, existingUser)
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
