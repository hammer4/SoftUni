const PassportLocalStrategy = require('passport-local').Strategy
const usersData = require('../data/users')

module.exports = new PassportLocalStrategy({
  usernameField: 'email',
  passwordField: 'password',
  session: false,
  passReqToCallback: true
}, (req, email, password, done) => {
  const user = {
    email: email.trim(),
    password: password.trim(),
    name: req.body.name.trim()
  }

  const existingUser = usersData.findByEmail(email)
  if (existingUser) {
    return done('E-mail already exists!')
  }

  usersData.save(user)

  return done(null)
})
