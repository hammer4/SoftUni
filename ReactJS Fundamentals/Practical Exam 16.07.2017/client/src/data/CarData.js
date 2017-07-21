import Auth from '../components/users/Auth'

const baseUrl = 'http://localhost:5000/cars'
let getOptions = () => ({
  mode: 'cors',
  headers: {
    'Accept': 'application/json',
    'Content-Type': 'application/json'
  }
})

let handleResponseJson = (res) => res.json()

class CarData {
  static create (car) {
    const options = getOptions()
    options.method = 'POST'
    options.headers.Authorization = 'bearer ' + Auth.getToken()
    options.body = JSON.stringify(car)

    return window.fetch(`${baseUrl}/create`, options)
     .then(handleResponseJson)
  }

  static all (page, search) {
    page = page || 1
    const options = getOptions()
    options.method = 'GET'
    return window.fetch(`${baseUrl}/all?page=${page}&search=${search}`, options)
      .then(handleResponseJson)
  }

  static details (id) {
    const options = getOptions()
    options.method = 'GET'
    options.headers.Authorization = `bearer ${Auth.getToken()}`
    return window.fetch(`${baseUrl}/details/${id}`, options)
      .then(handleResponseJson)
  }

  static getUserCars () {
    const options = getOptions()
    options.method = 'GET'
    options.headers.Authorization = `bearer ${Auth.getToken()}`
    return window.fetch(`${baseUrl}/mine`, options)
      .then(handleResponseJson)
  }

  static delete (id) {
    const options = getOptions()
    options.method = 'POST'
    options.headers.Authorization = `bearer ${Auth.getToken()}`
    return window.fetch(`${baseUrl}/delete/${id}`, options)
      .then(handleResponseJson)
  }

  static like (id) {
    const options = getOptions()
    options.method = 'POST'
    options.headers.Authorization = `bearer ${Auth.getToken()}`
    return window.fetch(`${baseUrl}/details/${id}/like`, options)
      .then(handleResponseJson)
  }
}

export default CarData
