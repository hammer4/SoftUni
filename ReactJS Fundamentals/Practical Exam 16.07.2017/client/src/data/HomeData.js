const baseUrl = 'http://localhost:5000/stats'
let getOptions = () => ({
  method: 'GET',
  mode: 'cors',
  headers: {
    'Accept': 'application/json',
    'Content-Type': 'application/json'
  }
})

let handleResPonseJson = (res) => res.json()

class HomeData {
  static getStats () {
    const options = getOptions()
    return window.fetch(`${baseUrl}`, options)
     .then(handleResPonseJson)
  }
}

export default HomeData
