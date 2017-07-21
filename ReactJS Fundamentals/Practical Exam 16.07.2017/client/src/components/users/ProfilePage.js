import React from 'react'
import CarActions from '../../actions/CarActions'
import CarStore from '../../stores/CarStore'
import {Link} from 'react-router-dom'
import toastr from 'toastr'

class ListCarsPage extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      cars: []
    }

    this.handleCarsFetching = this.handleCarsFetching.bind(this)
    CarStore.on(CarStore.eventTypes.USER_CARS_FETCHED, this.handleCarsFetching)
    this.handleCarDeleting = this.handleCarDeleting.bind(this)
    CarStore.on(CarStore.eventTypes.CAR_DELETED, this.handleCarDeleting)
  }

  componentDidMount () {
    CarActions.getUserCars()
  }

  componentWillUnmount () {
    CarStore.removeListener(CarStore.eventTypes.USER_CARS_FETCHED, this.handleCarsFetching)
    CarStore.removeListener(CarStore.eventTypes.CAR_DELETED, this.handleCarDeleting)
  }

  handleCarsFetching (data) {
    this.setState({
      cars: data
    })
  }

  deleteCar (ev) {
    let id = ev.target.id
    CarActions.delete(id)
  }

  handleCarDeleting (data) {
    toastr.success(data.message)
    CarActions.getUserCars()
  }

  render () {
    const cars = this.state.cars.map(car => (
      <div key={car.id} className='car'>
        <img src={car.image} alt={car.make} />
        <Link to={`/cars/details/${car.id}`}>{`${car.make} - ${car.engine} - ${car.year} year`}</Link>
        <button onClick={this.deleteCar} id={car.id}>Delete</button>
      </div>
    ))
    return (
      <div>
        <h1>My cars:</h1>
        {cars}
      </div>
    )
  }
}

export default ListCarsPage
