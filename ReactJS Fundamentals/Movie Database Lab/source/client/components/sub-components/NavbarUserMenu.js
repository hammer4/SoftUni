import React from 'react'
import { Link } from 'react-router'

import UserActions from '../../actions/UserActions'
import UserStore from '../../stores/UserStore'

export default class NavbarUserMenu extends React.Component {
  constructor (props) {
    super(props)

    this.state = UserStore.getState()

    this.onChange = this.onChange.bind(this)
  }

  onChange (state) {
    this.setState(state)
  }

  componentDidMount () {
    UserStore.listen(this.onChange)
  }

  componentWillUnmount () {
    UserStore.unlisten(this.onChange)
  }

  render () {
    let userData = this.state
    let userMenu 
    if (!this.state.loggedInUserId) {
      userMenu = (
        <ul className='nav navbar-nav pull-right'>
          <li>
            <a href='#' onClick={UserActions.loginUser}>Login</a>
          </li>
          <li>
            <Link to='/user/register'>Register</Link>
          </li>
        </ul>
      )
    } else {
      userMenu = (
        <ul className='nav navbar-nav pull-right'>
          <li>
            <Link to={`/user/profile/${this.state.loggedInUserId}`}>Profile</Link>
          </li>
          <li>
            <a href='#' onClick={UserActions.logoutUser}>Logout</a>
          </li>
        </ul>
      )
    }

    return (
      <div>
        {userMenu}
      </div>
    )
  }
}
