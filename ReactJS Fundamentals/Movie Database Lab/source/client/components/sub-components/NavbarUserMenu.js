import React from 'react'
import { Link } from 'react-router'

export default class NavbarUserMenu extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      loggedInUserId: this.props.userData.loggedInUserId
    }
  }

  componentWillReceiveProps (nextProps) {
    this.setState({
      loggedInUserId: nextProps.userData.loggedInUserId
    })
  }

  render () {
    let userData = this.props.userData
    let userMenu 
    if (!this.state.loggedInUserId) {
      userMenu = (
        <ul className='nav navbar-nav pull-right'>
          <li>
            <a href='#' onClick={userData.loginUser}>Login</a>
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
            <a href='#' onClick={userData.logoutUser}>Logout</a>
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
