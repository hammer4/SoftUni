import React from 'react'
import queryString from 'query-string'
import CarActions from '../../actions/CarActions'
import CarStore from '../../stores/CarStore'
import HomeActions from '../../actions/HomeActions'
import HomeStore from '../../stores/HomeStore'
import {Link} from 'react-router-dom'

class ListCarsPage extends React.Component {
  constructor (props) {
    super(props)

    let query = queryString.parse(props.location.search)
    let page = Number(query.page) || 1
    let search = query.search || ''
    this.state = {
      cars: [],
      page: page,
      search: search,
      carsCount: 0,
      usersCount: 0
    }

    this.handleCarsFetching = this.handleCarsFetching.bind(this)
    CarStore.on(CarStore.eventTypes.CARS_FETCHED, this.handleCarsFetching)
    this.handleStatsReceived = this.handleStatsReceived.bind(this)
    HomeStore.on(HomeStore.eventTypes.STATS_FETCHED, this.handleStatsReceived)
  }

  componentDidMount () {
    CarActions.all(this.state.page, this.state.search)
    HomeActions.getStats()
  }

  componentWillUnmount () {
    CarStore.removeListener(CarStore.eventTypes.CARS_FETCHED, this.handleCarsFetching)
    HomeStore.removeListener(HomeStore.eventTypes.STATS_FETCHED, this.handleStatsReceived)
  }

  handleCarsFetching (data) {
    this.setState({
      cars: data
    })
  }

  handleStatsReceived (data) {
    this.setState({
      carsCount: data.cars,
      usersCount: data.users
    })
  }

  goToNextPage () {
    if (this.state.cars.length < 10) {
      return
    }

    let page = this.state.page
    page++

    this.setState({
      page
    })

    let search = this.state.search
    this.props.history.push(`/?page=${page}&search=${search}`)
    CarActions.all(page, search)
  }

  goToPrevPage () {
    if (this.state.page === 1) {
      return
    }

    let page = this.state.page
    page--

    this.setState({
      page
    })

    let search = this.state.search

    this.props.history.push(`/?page=${page}&search=${search}`)
    CarActions.all(page, search)
  }

  handleSearchChange (ev) {
    let value = ev.target.value
    this.setState({
      search: value
    })
  }

  handleSearchSubmit (ev) {
    ev.preventDefault()
    CarActions.all(this.state.page, this.state.search)
  }

  render () {
    const cars = this.state.cars.map(car => (
      <div key={car.id} className='car'>
        <img src={car.image} alt={car.make} />
        <Link to={`/cars/details/${car.id}`}>{`${car.make} - ${car.engine} - ${car.year} year`}</Link>
      </div>
    ))
    return (
      <div>
        <div>
          <h3>Stats:</h3>
          <p>Users count: {this.state.usersCount}</p>
          <p>Cars count: {this.state.carsCount}</p>
        </div>
        <form>
          <label htmlFor='search'>Search</label>
          <input
            type='text'
            name='search'
            value={this.state.search}
            onChange={this.handleSearchChange.bind(this)} />
          <input type='submit' onClick={this.handleSearchSubmit.bind(this)} />
        </form>
        <h1>All cars</h1>
        {cars}
        <div>
          <button onClick={this.goToPrevPage.bind(this)}>Prev</button>
          <button onClick={this.goToNextPage.bind(this)}>Next</button>
        </div>
      </div>
    )
  }
}

export default ListCarsPage
