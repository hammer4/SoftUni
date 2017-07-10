import React from 'react'
import queryString from 'query-string'
import PetActions from '../../actions/PetActions'
import PetStore from '../../stores/PetStore'
import {Link} from 'react-router-dom'

class ListPetsPage extends React.Component {
  constructor (props) {
    super(props)

    let query = queryString.parse(props.location.search)
    let page = Number(query.page) || 1
    this.state = {
      pets: [],
      page: page
    }

    this.handlePetsFetching = this.handlePetsFetching.bind(this)
    PetStore.on(PetStore.eventTypes.PETS_FETCHED, this.handlePetsFetching)
  }

  componentDidMount () {
    PetActions.all(this.state.page)
  }

  componentWillUnmount () {
    PetStore.removeListener(PetStore.eventTypes.PETS_FETCHED, this.handlePetsFetching)
  }

  handlePetsFetching (data) {
    this.setState({
      pets: data
    })
  }

  goToNextPage () {
    if (this.state.pets.length < 10) {
      return
    }

    let page = this.state.page
    page++

    this.setState({
      page
    })

    this.props.history.push(`/?page=${page}`)
    PetActions.all(page)
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
    PetActions.all(page)
  }
  render () {
    const pets = this.state.pets.map(pet => (
      <div key={pet.id} className='pet'>
        <img src={pet.image} alt='pet' />
        <Link to={`/pets/details/${pet.id}`}>{pet.name}</Link>
      </div>
    ))
    return (
      <div>
        <h1>All pets</h1>
        {pets}
        <div>
          <button onClick={this.goToPrevPage.bind(this)}>Prev</button>
          <button onClick={this.goToNextPage.bind(this)}>Next</button>
        </div>
      </div>
    )
  }
}

export default ListPetsPage
