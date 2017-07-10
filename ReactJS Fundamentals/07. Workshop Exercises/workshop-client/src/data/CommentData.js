import Auth from '../components/users/Auth'
const baseUrl = 'http://localhost:5000/pets/details'
let getOptions = () => ({
  method: 'POST',
  mode: 'cors',
  headers: {
    'Accept': 'application/json',
    'Content-Type': 'application/json'
  }
})

let handleResponseJson = (res) => res.json()

class CommentData {
  static create (message, id) {
    const options = getOptions()
    options.headers.Authorization = `bearer ${Auth.getToken()}`
    options.body = JSON.stringify({message})
    return window.fetch(`${baseUrl}/${id}/comments/create`, options)
     .then(handleResponseJson)
  }
  static getAll (id) {
    const options = getOptions()
    options.headers.Authorization = `bearer ${Auth.getToken()}`
    options.method = 'GET'
    return window.fetch(`${baseUrl}/${id}/comments`, options)
     .then(handleResponseJson)
  }
}

export default CommentData
