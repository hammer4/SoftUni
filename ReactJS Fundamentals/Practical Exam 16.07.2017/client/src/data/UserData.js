const baseUrl = 'http://localhost:5000/auth'
let getOptions = () => ({
  method: 'POST',
  mode: 'cors',
  headers: {
    'Accept': 'application/json',
    'Content-Type': 'application/json'
  }
})

let handleResPonseJson = (res) => res.json()

class UserData {
  static register (user) {
    const options = getOptions()
    options.body = JSON.stringify(user)
    return window.fetch(`${baseUrl}/signup`, options)
     .then(handleResPonseJson)
  }

  static login (user) {
    const options = getOptions()
    options.body = JSON.stringify(user)

    return window.fetch(`${baseUrl}/login`, options)
      .then(handleResPonseJson)
  }
}

export default UserData
