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

    let userMenu
    if (!this.state.loggedInUserId) {
      userMenu = (
        <ul className="nav navbar-nav pull-right">
          <li>
            <Link to='/user/login'>Login</Link>
          </li>
          <li>
            <Link to="/user/register">Register</Link>
          </li>
        </ul>
      )
    } else {
      userMenu = (
        <ul className="nav navbar-nav pull-right">
          <li>
            <Link to='/category/add'>Add Category</Link>
          </li>
          <li>
            <Link to='/article/add'>Add Article</Link>
          </li>
          <li>
            <Link to={ `/user/profile` } > Profile </Link>
          </li>
          <li>
            <Link to="/user/logout" >Logout</Link>
          </li>
        </ul>
      )
    }
    return (
      <div>
        { userMenu }
      </div>
    )
  }
}