import alt from '../alt'
import UserActions from '../actions/UserActions'
import Auth from '../components/user/Auth'

class AppStore {
  constructor () {
    this.bindActions(UserActions)
    this.loggedInUserId = ''
    this.username = ''
    this.roles = []
    this.picture = ''
    this.firstName = ''
    this.lastName = ''
    this.age = ''
    this.gender = ''

    
    this.on('init', (data) => {
      //console.log('test')
      if (Auth.isUserAuthenticated() && !this.loggedInUserId) {
        //console.log('auth me')
        //maybe serialize the whole state?
        this.loggedInUserId = Auth.getToken()
        this.username = Auth.getData('username') || ''
        this.roles = Auth.getDataArray('roles') || []
        this.picture = Auth.getData('picture')
        this.firstName = Auth.getData('firstName')
        this.lastName = Auth.getData('lastName')
        this.age = Auth.getData('age')
        this.gender = Auth.getData('gender')
        //this.emitChange();
      }
    });
  }

  onLoginUserSuccess (user) {
    console.log(user)
    this.loggedInUserId = user._id
    this.username = user.username
    this.roles = user.roles
    this.picture = user.picture
    this.firstName = user.firstName
    this.lastName = user.lastName
    this.age = user.age
    this.gender = user.gender
    Auth.setData('username', this.username)
    Auth.setData('roles', this.roles)
    Auth.setData('picture', this.picture)
    Auth.setData('firstName',this.firstName)
    Auth.setData('lastName',this.lastName)
    Auth.setData('age',this.age)
    Auth.setData('gender',this.gender)

    Auth.authenticateUser(this.loggedInUserId)

  }

  onLoginUserFail () {
    console.log('Failed login attempt')
  }

  onLogoutUserSuccess () { // Redirect on part 3
    this.loggedInUserId = ''
    this.username = ''
    this.roles = []
    Auth.deauthenticateUser()
  }
}

export default alt.createStore(AppStore)