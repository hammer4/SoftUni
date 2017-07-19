import React from 'react'
import Input from '../common/Input'

let CreateHotelForm = (props) => (
  <form>
    <Input
      name='name'
      placeholder='Name'
      value={props.name}
      onChange={props.onChange}
      minLength='4'
      required='required' />

    <Input
      name='location'
      placeholder='Location'
      value={props.location}
      onChange={props.onChange} />

    <div>
      <label htmlFor='description'>Description</label>
      <textarea
        name='description'
        placeholder='Description'
        value={props.description}
        onChange={props.onChange}
        rows='8' cols='70'
        required
        minLength='11' />
    </div>

    <Input
      name='numberOfRooms'
      placeholder='Number Of Rooms'
      value={props.numberOfRooms}
      onChange={props.onChange}
      type='number'
      min='0' />

    <Input
      name='image'
      placeholder='Image'
      value={props.image}
      onChange={props.onChange}
      type='url'
      required='true' />

    <Input
      name='parkingSlots'
      placeholder='Parking slots'
      value={props.parkingSlots}
      onChange={props.onChange}
      type='number' />

    <input type='submit' onClick={props.onSave} />
  </form>
)

export default CreateHotelForm
