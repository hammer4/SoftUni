import React from 'react'
import Input from '../common/Input'

const EditAuthorForm = (props) => (
  <form>
    <div>{props.error}</div>
    <Input
      name='name'
      placeholder='Name'
      value={props.author.name}
      onChange={props.onChange} />

    <Input
      name='image'
      type='url'
      placeholder='Image'
      value={props.author.image}
      onChange={props.onChange} />

    <input type='submit' onClick={props.onSave} />
  </form>
)

export default EditAuthorForm
