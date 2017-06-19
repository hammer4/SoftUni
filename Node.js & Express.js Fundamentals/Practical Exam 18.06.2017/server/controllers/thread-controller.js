const Thread = require('../data/Thread')
const User = require('../data/User')
const Message = require('../data/Message')

module.exports = {
  displayThread: (req, res) => {
    let username = req.params.username
    if (username === req.user.username) {
      res.redirect('/')
      return
    }
    User.findOne({username: username}).then(user => {
      Thread.findOne({participants: {$all: [user._id, req.user._id]}}).populate('messages').then(thread => {
        if (!thread) {
          Thread.create({
            participants: [user._id, req.user._id]
          }).then(res.redirect(`/thread/${username}`))
        } else {
          res.render('thread/details', {
            recipient: user,
            messages: thread.messages.sort((a, b) => a.date - b.date)
          })
        }
      })
    })
  },

  addMessage: (req, res) => {
    let username = req.params.username
    if (req.body.message.length > 1000) {
      res.redirect('/')
      return
    }

    User.findOne({username: username}).then(user => {
      if (user.blockedUsers.indexOf(req.user._id.toString()) > -1) {
        res.redirect('/')
        return
      }
      Message.create({
        message: req.body.message,
        author: req.user._id,
        isLink: isLink(req.body.message),
        isImage: isImage(req.body.message)
      }).then(message => {
        Thread.findOne({participants: {$all: [user._id, req.user._id]}}).then(thread => {
          thread.messages.push(message._id)
          thread.latestMessageDate = message.date
          thread.save().then(() => {
            res.redirect(`/thread/${username}`)
          })
        })
      })
    })
  },

  likeMessage: (req, res) => {
    let id = req.params.id
    let username = req.params.username

    User.findByIdAndUpdate(req.user._id, { $addToSet: { likedMessages: id } }).then(() => {
      res.redirect(`/thread/${username}`)
    })
  },

  dislikeMessage: (req, res) => {
    let id = req.params.id
    let username = req.params.username

    User.findByIdAndUpdate(req.user._id, { $pull: { likedMessages: { $in: [id] } } }).then(() => {
      res.redirect(`/thread/${username}`)
    })
  }
}

function isImage (message) {
  return (message.startsWith('http') || message.startsWith('https')) &&
   (message.endsWith('jpg') || message.endsWith('jpeg') || message.endsWith('png'))
}

function isLink (message) {
  return message.startsWith('http') || message.startsWith('https')
}
