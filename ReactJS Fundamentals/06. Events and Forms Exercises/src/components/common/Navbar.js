import React from 'react'
import {Link} from 'react-router-dom'
import Auth from '../users/Auth'
import UserStore from '../../stores/UserStore'

class Navbar extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      username: Auth.getUser().name
    }
    this.handleUserLoggedIn = this.handleUserLoggedIn.bind(this)

    UserStore.on(UserStore.eventTypes.USER_LOGGED_IN, this.handleUserLoggedIn)
  }

  handleUserLoggedIn (user) {
    if (user) {
      this.setState({
        username: user.name
      })
    }
  }

  render () {
    return (
      <div className='menu'>
        {Auth.isUserAuthenticated() ? (
          <div>
            <Link to='/'>Home</Link>
            <span>{this.state.username}</span>
            <Link to='/authors/all'>All authors</Link>
            <Link to='/books/all'>All books</Link>
            <Link to='/authors/add'>Add author</Link>
            <Link to='/books/add'>Add book</Link>
            <Link to='/users/logout'>Logout</Link>
          </div>
        ) : (
          <div>
            <Link to='/'>Home</Link>
            <Link to='/authors/all'>All authors</Link>
            <Link to='/books/all'>All books</Link>
            <Link to='/users/register'>Register</Link>
            <Link to='/users/login'>Login</Link>
          </div>
        )}
      </div>
    )
  }
}

export default Navbar
