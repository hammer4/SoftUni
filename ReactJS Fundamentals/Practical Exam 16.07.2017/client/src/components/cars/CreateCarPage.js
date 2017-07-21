import React from 'react'
import CreateCarForm from './CreateCarForm'
import FormHelpers from '../common/FormHelpers'
import CarActions from '../../actions/CarActions'
import CarStore from '../../stores/CarStore'
import toastr from 'toastr'

class CreateCarPage extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      car: {
        make: 'Audi',
        model: 'A6',
        year: 2001,
        engine: '2.5 TDI',
        price: 5000,
        image: 'https://preview.netcarshow.com/Audi-A6-2002-1600-02.jpg',
        mileage: 180000
      },
      error: ''
    }

    this.handleCarCreation = this.handleCarCreation.bind(this)

    CarStore.on(CarStore.eventTypes.CAR_CREATED, this.handleCarCreation)
  }

  componentWillUnmount () {
    CarStore.removeListener(CarStore.eventTypes.CAR_CREATED, this.handleCarCreation)
  }

  handleCarChange (ev) {
    FormHelpers.handleFormChange.bind(this)(ev, 'car')
  }

  handleCarForm (ev) {
    let car = this.state.car
    ev.preventDefault()
    let err = ''
    if (car.make.length < 3) {
      err = 'Make must be more than 3 symbols.'
    }
    if (car.model.length < 3) {
      err = 'Model must be more than 3 symbols.'
    }
    if (Number(car.year) < 1950 || Number(car.year) > 2050) {
      err = 'Year must be between 1950 and 2050.'
    }
    if (car.engine.length <= 1) {
      err = 'Engine must be more than 1 symbol.'
    }
    if (Number(car.price) < 0) {
      err = 'Price must be a positive number.'
    }
    if (!car.image) {
      err = 'Image URL is required.'
    }

    if (err) {
      this.setState({
        error: err
      })

      return
    }

    CarActions.create(this.state.car)
  }

  handleCarCreation (data) {
    if (!data.success) {
      let err = FormHelpers.message
      this.setState({
        error: err
      })
    } else {
      toastr.success(data.message)
      this.props.history.push('/')
    }
  }

  render () {
    let car = this.state.car

    return (
      <div>
        <h2>Create Car</h2>
        <CreateCarForm
          make={car.make}
          model={car.model}
          image={car.image}
          price={car.price}
          engine={car.engine}
          mileage={car.mileage}
          year={car.year}
          error={this.state.error}
          onChange={this.handleCarChange.bind(this)}
          onSave={this.handleCarForm.bind(this)} />
      </div>
    )
  }
}
export default CreateCarPage
