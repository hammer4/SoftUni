import Auth from '../components/users/Auth'
const baseUrl = 'http://localhost:5000/pets'
let getOptions = () => ({
  method: 'POST',
  mode: 'cors',
  headers: {
    'Accept': 'application/json',
    'Content-Type': 'application/json'
  }
})

let handleResponseJson = (res) => res.json()

class PetData {
  static create (pet) {
    const options = getOptions()
    options.headers.Authorization = `bearer ${Auth.getToken()}`
    options.body = JSON.stringify(pet)
    return window.fetch(`${baseUrl}/create`, options)
     .then(handleResponseJson)
  }

  static all (page) {
    page = page || 1
    const options = getOptions()
    options.method = 'GET'
    return window.fetch(`${baseUrl}/all?page=${page}`, options)
      .then(handleResponseJson)
  }

  static details (id) {
    const options = getOptions()
    options.method = 'GET'
    options.headers.Authorization = `bearer ${Auth.getToken()}`
    return window.fetch(`${baseUrl}/details/${id}`, options)
      .then(handleResponseJson)
  }
}

export default PetData
