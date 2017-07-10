import React from 'react'
import Input from '../common/Input'

const CreatePetForm = (props) => (
  <form>
    <div>{props.error}</div>
    <Input
      name='name'
      placeholder='Name'
      value={props.pet.name}
      onChange={props.onChange} />
    
    <Input
      name='image'
      type='url'
      placeholder='Image'
      value={props.pet.image}
      onChange={props.onChange} />

    <Input
      name='age'
      type='number'
      placeholder='Age'
      value={props.pet.age}
      onChange={props.onChange} />

    <label htmlFor='type'>Type</label>
    <select
      value={props.pet.type}
      name='type'
      onChange={props.onChange}>
      <option value='Cat'>Cat</option>
      <option value='Dog'>Dog</option>
      <option value='Other'>Other</option>
    </select>

    <Input
      name='breed'
      placeholder='Breed'
      value={props.pet.breed}
      onChange={props.onChange} />

    <input type='submit' onClick={props.onSave} />
  </form>
)

export default CreatePetForm
