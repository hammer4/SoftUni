import Auth from '../components/users/Auth'
const baseUrl = 'http://localhost:5000/hotels'
let getOptions = () => ({
  mode: 'cors',
  headers: {
    'Accept': 'application/json',
    'Content-Type': 'application/json'
  }
})

let handleResponseJson = (res) => res.json()

class HotelData {
  static create (hotel) {
    const options = getOptions()
    options.method = 'POST'
    options.headers.Authorization = 'bearer ' + Auth.getToken()
    options.body = JSON.stringify(hotel)
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

export default HotelData
