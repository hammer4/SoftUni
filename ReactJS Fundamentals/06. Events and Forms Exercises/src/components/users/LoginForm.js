import React from 'react'
import Input from '../common/Input'

const LoginForm = (props) => (
  <form>
    <div>{props.error}</div>
    <Input
      name='username'
      type='text'
      placeholder='Username'
      value={props.user.username}
      onChange={props.onChange} />

    <Input
      name='password'
      type='password'
      placeholder='Password'
      value={props.user.password}
      onChange={props.onChange} />

    <input type='submit' onClick={props.onSave} />
  </form>
)

export default LoginForm
