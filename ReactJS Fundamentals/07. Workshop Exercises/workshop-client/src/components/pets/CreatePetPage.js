import React from 'react'
import CreatePetForm from './CreatePetForm'
import FormHelpers from '../common/FormHelpers'
import PetActions from '../../actions/PetActions'
import PetStore from '../../stores/PetStore'
import toastr from 'toastr'

class CreatePetPage extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      pet: {
        name: 'Pesho',
        age: 2,
        type: 'Cat',
        image: 'https://www.petfinder.com/wp-content/uploads/2012/11/91615172-find-a-lump-on-cats-skin-632x475.jpg',
        breed: 'Street'
      },
      error: ''
    }

    this.handlePetCreation = this.handlePetCreation.bind(this)
    PetStore.on(PetStore.eventTypes.PET_CREATED, this.handlePetCreation)
  }

  componentWillUnmount () {
    PetStore.removeListener(PetStore.eventTypes.PET_CREATED, this.handlePetCreation)
  }

  handlePetChange (ev) {
    FormHelpers.handleFormChange.bind(this)(ev, 'pet')
  }

  handlePetForm (ev) {
    ev.preventDefault()
    PetActions.create(this.state.pet)
  }

  handlePetCreation (data) {
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
      this.props.history.push(`/pets/details/${data.pet.id}`)
    }
  }

  render () {
    return (
      <div>
        <h1>Create pet</h1>
        <CreatePetForm
          pet={this.state.pet}
          error={this.state.error}
          onChange={this.handlePetChange.bind(this)}
          onSave={this.handlePetForm.bind(this)} />
      </div>
    )
  }
}

export default CreatePetPage
