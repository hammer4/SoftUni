import React from 'react'
import CreateHotelForm from './CreateHotelForm'
import FormHelpers from '../common/FormHelpers'
import HotelActions from '../../actions/HotelActions'
import HotelStore from '../../stores/HotelStore'
import toastr from 'toastr'

class CreateHotelPage extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      hotel: {
        name: '',
        location: '',
        description: '',
        numberOfRooms: 0,
        image: ''
      },
      error: ''
    }

    this.handleHotelCreation = this.handleHotelCreation.bind(this)
    HotelStore.on(HotelStore.eventTypes.HOTEL_CREATED, this.handleHotelCreation)
  }

  componentWillUnmount () {
    HotelStore.removeListener(HotelStore.eventTypes.HOTEL_CREATED, this.handleHotelCreation)
  }

  handleFormChange (ev) {
    FormHelpers.handleFormChange.bind(this)(ev, 'hotel')
  }

  handleHotelForm (ev) {
    ev.preventDefault()
    HotelActions.create(this.state.hotel)
  }

  handleHotelCreation (data) {
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
      this.props.history.push(`/pets/details/${data.hotel.id}`)
    }
  }

  render () {
    let hotel = this.state.hotel

    return (
      <div>
        <h2>Add new hotel</h2>
        <CreateHotelForm
          name={hotel.name}
          description={hotel.description}
          location={hotel.location}
          image={hotel.image}
          numberOfRooms={hotel.numberOfRooms}
          parkingSpots={hotel.parkingSpots}
          error={this.state.error}
          onChange={this.handleFormChange.bind(this)}
          onSave={this.handleHotelForm.bind(this)} />
      </div>
    )
  }
}

export default CreateHotelPage
