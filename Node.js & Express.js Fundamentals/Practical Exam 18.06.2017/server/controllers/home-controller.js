const Thread = require('../data/Thread')
const User = require('../data/User')

module.exports = {
  index: (req, res) => {
    if (!req.user) {
      res.render('home/index')
      return
    }
    let query = User.find({username: {$ne: req.user.username}})
    let search = req.query.search
    if (search) {
      query = query.where('username').regex(new RegExp(search, 'i'))
    }

    query.then(users => {
      Thread.find({participants: { $in: [req.user._id] }}).populate('participants').sort('-latestMessageDate').then(threads => {
        res.render('home/index', {
          threads: threads,
          users: users
        })
      })
    })
  }
}
