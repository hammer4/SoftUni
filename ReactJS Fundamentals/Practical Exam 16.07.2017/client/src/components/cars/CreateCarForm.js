import React from 'react'
import Input from '../common/Input'

const CreateCarForm = (props) => (
  <form>
    <div>{props.error}</div>
    <Input
      name='make'
      placeholder='Make'
      value={props.make}
      onChange={props.onChange} />

    <Input
      name='model'
      placeholder='Model'
      value={props.model}
      onChange={props.onChange} />

    <Input
      name='year'
      placeholder='Year'
      value={props.year}
      onChange={props.onChange}
      type='number' />

    <Input
      name='engine'
      placeholder='Engine'
      value={props.engine}
      onChange={props.onChange} />

    <Input
      name='price'
      placeholder='Price'
      value={props.price}
      onChange={props.onChange}
      type='number' />

    <Input
      name='image'
      placeholder='Image'
      value={props.image}
      onChange={props.onChange}
      type='url' />

    <Input
      name='mileage'
      placeholder='Mileage'
      value={props.mileage}
      onChange={props.onChange}
      type='number' />

    <input
      type='submit'
      onClick={props.onSave} />

  </form>
)

export default CreateCarForm
