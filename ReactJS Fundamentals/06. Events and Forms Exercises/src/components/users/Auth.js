class Auth {
  static saveUser (user) {
    window.localStorage.setItem('user', JSON.stringify(user))
  }
  static getUser () {
    const userJSON = window.localStorage.getItem('user')
    if (userJSON) {
      return JSON.parse(userJSON)
    }
    console.log('nqma user')
    return {}
  }
  static removeUser () {
    window.localStorage.removeItem('user')
  }
  static authenticateUser (token) {
    window.localStorage.setItem('token', token)
  }
  static isUserAuthenticated () {
    return window.localStorage.getItem('token') !== null
  }
  static deauthenticateUser () {
    window.localStorage.removeItem('token')
  }
  static getToken () {
    return window.localStorage.getItem('token')
  }
}

export default Auth
