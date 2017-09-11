const jwt = require('jsonwebtoken')
const usersData = require('../data/users')

module.exports = (req, res, next) => {
  if (!req.headers.authorization) {
    return res.status(401).end()
  }

  // get the last part from a authorization header string like "bearer token-value"
  const token = req.headers.authorization.split(' ')[1]

  // decode the token using a secret key-phrase
  return jwt.verify(token, 's0m3 r4nd0m str1ng', (err, decoded) => {
    // the 401 code is for unauthorized status
    if (err) { return res.status(401).end() }

    const userId = decoded.sub

    const user = usersData.findById(userId)
    if (!user) {
      return res.status(401).end()
    }

    req.user = user

    return next()
  })
}
