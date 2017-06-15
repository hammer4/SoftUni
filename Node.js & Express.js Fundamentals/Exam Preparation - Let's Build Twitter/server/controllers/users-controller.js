const encryption = require('../utilities/encryption')
const User = require('mongoose').model('User')
const Tweet = require('../data/Tweet')

module.exports = {
  registerGet: (req, res) => {
    res.render('users/register')
  },
  registerPost: (req, res) => {
    let reqUser = req.body
    // Add validations!

    let salt = encryption.generateSalt()
    let hashedPassword = encryption.generateHashedPassword(salt, reqUser.password)

    User.create({
      username: reqUser.username,
      firstName: reqUser.firstName,
      lastName: reqUser.lastName,
      salt: salt,
      hashedPass: hashedPassword
    }).then(user => {
      req.logIn(user, (err, user) => {
        if (err) {
          res.locals.globalError = err
          res.render('users/register', user)
        }

        res.redirect('/')
      })
    })
  },
  loginGet: (req, res) => {
    res.render('users/login')
  },
  loginPost: (req, res) => {
    let reqUser = req.body
    User
      .findOne({ username: reqUser.username }).then(user => {
        if (!user) {
          res.locals.globalError = 'Invalid user data'
          res.render('users/login')
          return
        }

        if (!user.authenticate(reqUser.password)) {
          res.locals.globalError = 'Invalid user data'
          res.render('users/login')
          return
        }

        req.logIn(user, (err, user) => {
          if (err) {
            res.locals.globalError = err
            res.render('users/login')
          }

          res.redirect('/')
        })
      })
  },
  logout: (req, res) => {
    req.logout()
    res.redirect('/')
  },
  addAdminGet: (req, res) => {
    User.find({roles: {$ne: 'Admin'}}).then(users => {
      res.render('users/admin-add', {
        users: users
      })
    })
  },
  addAdminPost: (req, res) => {
    let userId = req.body.user

    User.findByIdAndUpdate(userId, {$addToSet: {roles: 'Admin'}}).then(() => {
      res.redirect('/admins/all')
    })
  },
  all: (req, res) => {
    User.find({roles: {$in: ['Admin']}}).then(admins => {
      res.render('users/admin-all', {
        admins: admins
      })
    })
  },
  profile: (req, res) => {
    let username = req.params.username
    User.findOne({username: username}).then(user => {
      if (!user) {
        res.redirect('/')
        return
      }
      Tweet.find({$or: [{author: user._id}, {handles: user.username}]}).populate('author').sort('-date').limit(100).then(tweets => {
        for (let tweet of tweets) {
          tweet.views++
          tweet.save()
        }
        res.render('users/profile', {
          user: user,
          tweets: tweets
        })
      })
    })
  }
}
