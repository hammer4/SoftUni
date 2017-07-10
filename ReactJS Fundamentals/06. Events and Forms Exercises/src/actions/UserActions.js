import dispatcher from '../dispatcher'

const userActions = {
  types: {
    REGISTER_USER: 'REGISTER_USER',
    LOGIN_USER: 'LOGIN_USER'
  },
  register (user) {
    dispatcher.dispatch({
      type: this.types.REGISTER_USER,
      user
    })
  },
  login (user) {
    dispatcher.dispatch({
      type: this.types.LOGIN_USER,
      user
    })
  }
}

export default userActions
