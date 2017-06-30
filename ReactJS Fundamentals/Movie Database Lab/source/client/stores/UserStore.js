import alt from '../alt'
import UserActions from '../actions/UserActions'

class UserStore {
  constructor () {
    this.bindActions(UserActions) // AppActions ?

    this.loggedInUserId = ''
    this.username = ''
    this.roles = []
  }

  onLoginUserSuccess (user) {
    this.loggedInUserId = user._id
    this.username = user.username
    this.roles = user.roles
  }

  onLoginUserFail () {
    console.log('Failed login attempt')
  }

  onLogoutUserSuccess () {
    this.loggedInUserId = ''
    this.username = ''
    this.roles = []
  }
}

export default alt.createStore(UserStore)
