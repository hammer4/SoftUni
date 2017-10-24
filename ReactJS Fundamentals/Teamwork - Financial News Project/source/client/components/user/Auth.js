import localStorage from 'localStorage'



class Auth {
  static setData (key, data) {
    localStorage.setItem(key, data)
  }

  static getData (key) {
    const data = localStorage.getItem(key)
    if (data) {
      return data
    }
    return false
  }
  static getDataArray (key) {
    const data = localStorage.getItem(key)
    if (data) {
      return data.split(',')
    }
    return false
  }
  static authenticateUser (token) {
    this.setData('token', token)
  }

  static isUserAuthenticated () {
    return this.getData('token') || ''
  }

  static deauthenticateUser () {
    localStorage.clear()
  }

  static getToken () {
    return this.getData('token') || ''
  }
}

export default Auth
