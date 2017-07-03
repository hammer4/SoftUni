import React from 'react'
import UserActions from '../actions/UserActions'
import FormActions from '../actions/FormActions'
import FormStore from '../stores/FormStore'
import Form from './form/Form'
import TextGroup from './form/TextGroup'
import Submit from './form/Submit'

export default class UserLogin extends React.Component {
  constructor (props) {
    super(props)
    this.state = FormStore.getState()
    this.onChange = this.onChange.bind(this)
  }

  onChange (state) {
    this.setState(state)
  }

  componentDidMount () {
    FormStore.listen(this.onChange)
  }

  componentWillUnmount () {
    FormStore.unlisten(this.onChange)
  }

  handleSubmit (e) {
    e.preventDefault()

    let username = this.state.username
    let password = this.state.password
    if (!username) {
      FormActions.usernameValidationFail()
      return
    }
    if (!password) {
      FormActions.passwordValidationFail()
      return
    }

    UserActions.loginUser({username, password})
  }

  render () {
    return (
      <Form title='Login'
        handleSubmit={this.handleSubmit.bind(this)}
        submitState={this.state.formSubmitState}
        message={this.state.message}>

        <TextGroup type='text'
          value={this.state.username}
          label='Username'
          handleChange={FormActions.handleUsernameChange}
          validationState={this.state.usernameValidationState} />

        <TextGroup type='password'
          value={this.state.password}
          label='Password'
          handleChange={FormActions.handlePasswordChange}
          validationState={this.state.passwordValidationState}
          message={this.state.message} />

        <Submit type='btn-primary'
          value='Login' />

      </Form>
    )
  }
}
