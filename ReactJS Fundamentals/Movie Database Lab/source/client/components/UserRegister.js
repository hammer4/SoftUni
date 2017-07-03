import React from 'react'
import FormActions from '../actions/FormActions'
import UserActions from '../actions/UserActions'
import FormStore from '../stores/FormStore'
import Form from './form/Form'
import TextGroup from './form/TextGroup'
import RadioGroup from './form/RadioGroup'
import RadioElement from './form/RadioElement'
import Submit from './form/Submit'

export default class UserRegister extends React.Component {
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
    let data = {
      username: this.state.username,
      password: this.state.password,
      confirmedPassword: this.state.confirmedPassword,
      firstName: this.state.firstName,
      lastName: this.state.lastName,
      age: this.state.age,
      gender: this.state.gender
    }
    if (!data.username) {
      return FormActions.usernameValidationFail()
    }
    if (!data.password || !data.confirmedPassword || data.password !== data.confirmedPassword) {
      return FormActions.passwordValidationFail()
    }
    UserActions.registerUser(data)
  }

  render () {
    return (
      <Form title='Register'
        handleSubmit={this.handleSubmit.bind(this)}
        submitState={this.state.formSubmitState}
        message={this.state.message}>

        <TextGroup type='text'
          label='Username'
          value={this.state.username}
          autoFocus={true}
          handleChange={FormActions.handleUsernameChange}
          validationState={this.state.usernameValidationState}
          message={this.state.message} />

        <TextGroup type='password'
          label='Password'
          value={this.state.Password}
          handleChange={FormActions.handlePasswordChange}
          validationState={this.state.passwordValidationState}
          message={this.state.message} />

        <TextGroup type='password'
          label='Confirm Password'
          value={this.state.confirmPassword}
          handleChange={FormActions.handleConfirmedPasswordChange}
          validationState={this.state.passwordValidationState}
          message={this.state.message} />

        <TextGroup type='text'
          label='First Name'
          handleChange={FormActions.handleFirstNameChange}
          value={this.state.firstName} />

        <TextGroup type='text'
          label='Last Name'
          handleChange={FormActions.handleLastNameChange}
          value={this.state.lastName} />

        <TextGroup type='number'
          label='Age'
          handleChange={FormActions.handleAgeChange}
          value={this.state.age} />

        <RadioGroup validationState={this.state.genderValidationState}
          message={this.state.message}>
          <RadioElement groupName='gender'
            value='Male'
            selectedValue={this.state.gender}
            handleChange={FormActions.handleGenderChange} />

          <RadioElement groupName='gender'
            value='Female'
            selectedValue={this.state.gender}
            handleChange={FormActions.handleGenderChange} />
        </RadioGroup>

        <Submit type='btn-primary' value='Register' />
      </Form>
    )
  }
}
