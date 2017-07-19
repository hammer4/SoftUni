import React from 'react'
import queryString from 'query-string'
import HotelActions from '../../actions/HotelActions'
import HotelStore from '../../stores/HotelStore'
import {Link} from 'react-router-dom'

class ListHotelsPage extends React.Component {
  constructor (props) {
    super(props)

    let query = queryString.parse(props.location.search)
    let page = Number(query.page) || 1
    this.state = {
      hotels: [],
      page: page
    }

    this.handleHotelsFetching = this.handleHotelsFetching.bind(this)
    HotelStore.on(HotelStore.eventTypes.HOTELS_FETCHED, this.handleHotelsFetching)
  }

  componentDidMount () {
    HotelActions.all(this.state.page)
  }

  componentWillUnmount () {
    HotelStore.removeListener(HotelStore.eventTypes.HOTELS_FETCHED, this.handleHotelsFetching)
  }

  handleHotelsFetching (data) {
    this.setState({
      hotels: data
    })
  }

  goToNextPage () {
    if (this.state.hotels.length < 10) {
      return
    }

    let page = this.state.page
    page++

    this.setState({
      page
    })

    this.props.history.push(`/?page=${page}`)
    HotelActions.all(page)
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

    this.props.history.push(`/?page=${page}`)
    HotelActions.all(page)
  }
  render () {
    const hotels = this.state.hotels.map(hotel => (
      <div key={hotel.id} className='hotel'>
        <img src={hotel.image} alt='hotel' />
        <Link to={`/hotels/details/${hotel.id}`}>{hotel.name} - {hotel.location}</Link>
      </div>
    ))
    return (
      <div>
        <h1>All hotels</h1>
        {hotels}
        <div>
          <button onClick={this.goToPrevPage.bind(this)}>Prev</button>
          <button onClick={this.goToNextPage.bind(this)}>Next</button>
        </div>
      </div>
    )
  }
}

export default ListHotelsPage
