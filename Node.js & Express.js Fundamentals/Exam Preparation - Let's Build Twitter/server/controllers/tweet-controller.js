const Tweet = require('../data/Tweet')
const User = require('../data/User')

module.exports = {
  addGet: (req, res) => {
    res.render('tweet/add')
  },

  addPost: (req, res) => {
    let message = req.body.message
    if (message.length > 140) {
      res.redirect('/')
      return
    }

    let tagRegex = /(^|[ .,!?])#([-_0-9A-Za-z]+)(?=$|[ .,!?])/gim
    let tags = []

    let match = tagRegex.exec(message)
    while (match) {
      tags.push(match[2].toLowerCase())
      match = tagRegex.exec(message)
    }

    let handleRegex = /(^|[ .,!?])@([-_0-9A-Za-z]+)(?=$|[ .,!?])/gim
    let handles = []

    match = handleRegex.exec(message)
    while (match) {
      handles.push(match[2])
      match = handleRegex.exec(message)
    }

    Tweet.create({
      message: message,
      author: req.user._id,
      tags: tags,
      handles: handles
    }).then(() => {
      res.redirect('/')
    })
  },

  showByTag: (req, res) => {
    let tag = req.params.tagName.toLowerCase()

    Tweet.find({tags: {$in: [tag]}}).populate('author').sort('-date').limit(100).then(tweets => {
      for (let tweet of tweets) {
        tweet.views++
        tweet.save()
      }
      res.render('tweet/tag', {
        tag: tag,
        tweets: tweets
      })
    })
  },

  like: (req, res) => {
    let id = req.params.id
    Tweet.findById(id).then(tweet => {
      tweet.likes = tweet.likes + 1
      tweet.save().then(tweet => {
        User.findByIdAndUpdate(req.user._id, {$addToSet: {likedTweets: tweet._id}}).then((user) => {
          res.redirect(`/`)
        })
      })
    })
  },

  dislike: (req, res) => {
    let id = req.params.id
    Tweet.findById(id).then(tweet => {
      tweet.likes = tweet.likes - 1
      tweet.save().then(tweet => {
        User.findByIdAndUpdate(req.user._id, {$pull: {likedTweets: {$in: [tweet._id]}}}).then((user) => {
          res.redirect(`/`)
        })
      })
    })
  },

  editGet: (req, res) => {
    let id = req.params.id

    Tweet.findById(id).then(tweet => {
      res.render('tweet/edit', {
        tweet: tweet
      })
    })
  },

  editPost: (req, res) => {
    let id = req.params.id
    let message = req.body.message

    let tagRegex = /(^|[ .,!?])#([-_0-9A-Za-z]+)(?=$|[ .,!?])/gim
    let tags = []

    let match = tagRegex.exec(message)
    while (match) {
      tags.push(match[2].toLowerCase())
      match = tagRegex.exec(message)
    }

    let handleRegex = /(^|[ .,!?])@([-_0-9A-Za-z]+)(?=$|[ .,!?])/gim
    let handles = []

    match = handleRegex.exec(message)
    while (match) {
      handles.push(match[2])
      match = handleRegex.exec(message)
    }

    Tweet.findById(id).then(tweet => {
      tweet.message = message
      tweet.tags = tags
      tweet.handles = handles
      tweet.save().then(() => {
        res.redirect('/')
      })
    })
  },

  deleteGet: (req, res) => {
    let id = req.params.id

    Tweet.findById(id).then(tweet => {
      res.render('tweet/delete', {
        tweet: tweet
      })
    })
  },

  deletePost: (req, res) => {
    let id = req.params.id

    Tweet.findByIdAndRemove(id).then(() => {
      res.redirect('/')
    })
  }
}
