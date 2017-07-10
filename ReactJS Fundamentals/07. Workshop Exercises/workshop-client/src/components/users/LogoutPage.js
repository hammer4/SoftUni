import React from 'react'
import Auth from './Auth'

class LogoutPage extends React.Component {
  componentWillMount () {
    Auth.deauthenticateUser()
    Auth.removeUser()
    this.props.history.push('/')
  }

  render () {
    return null
  }
}

export default LogoutPage
