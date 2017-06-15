const Tweet = require('../data/Tweet')

module.exports = {
  index: (req, res) => {
    Tweet.find().populate('author').sort('-date').limit(100).then(tweets => {
      for (let tweet of tweets) {
        tweet.views++
        tweet.save()
      }
      res.render('home/index', {
        tweets: tweets
      })
    })
  }
}
