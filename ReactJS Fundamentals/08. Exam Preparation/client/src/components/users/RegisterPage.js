import React from 'react'
import RegisterForm from './RegisterForm'
import UserActions from '../../actions/UserActions'
import UserStore from '../../stores/UserStore'
import FormHelpers from '../common/FormHelpers'
import toastr from 'toastr'

class RegisterPage extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      user: {
        email: 'test@test.com',
        password: '123456',
        confirmPassword: '123456',
        name: 'Test'
      },
      error: ''
    }

    this.handleUserRegistration = this.handleUserRegistration.bind(this)

    UserStore.on(UserStore.eventTypes.USER_REGISTERED, this.handleUserRegistration)
  }

  componentWillUnmount () {
    UserStore.removeListener(UserStore.eventTypes.USER_REGISTERED, this.handleUserRegistration)
  }

  handleUserChange (ev) {
    FormHelpers.handleFormChange.bind(this)(ev, 'user')
  }

  handleUserForm (ev) {
    ev.preventDefault()
    if (!this.validateUser()) {
      return
    }
    UserActions.register(this.state.user)
  }

  handleUserRegistration (data) {
    if (!data.success) {
      let firstError = data.message

      if (data.errors) {
        firstError = Object.keys(data.errors).map(k => data.errors[k])[0]
      }

      this.setState({
        error: firstError
      })
    } else {
      toastr.success(data.message)
      this.props.history.push('/users/login')
    }
  }

  validateUser () {
    let user = this.state.user
    let formIsValid = true
    let error = ''

    if (user.password !== user.confirmPassword) {
      formIsValid = false
      error = 'Password and confirmation password do not match'
    }

    if (error) {
      this.setState({error})
    }

    return formIsValid
  }

  render () {
    return (
      <div>
        <h1>Register User</h1>
        <RegisterForm user={this.state.user}
          onChange={this.handleUserChange.bind(this)}
          error={this.state.error}
          onSave={this.handleUserForm.bind(this)} />
      </div>
    )
  }
}

export default RegisterPage
