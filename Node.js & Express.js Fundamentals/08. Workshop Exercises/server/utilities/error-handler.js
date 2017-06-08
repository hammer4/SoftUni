module.exports = {
  handleMongooseError: (err) => {
    let firstKey = Object.keys(err.errors)[0]
    let message = err.errors[firstKey].message
    return message
  }
}
