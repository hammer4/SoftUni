const mongoose = require('mongoose')

let tweetSchema = mongoose.Schema({
  message: {type: mongoose.Schema.Types.String, maxlength: 140, required: true},
  author: {type: mongoose.Schema.Types.ObjectId, ref: 'User'},
  date: {type: mongoose.Schema.Types.Date, default: Date.now},
  likes: {type: mongoose.Schema.Types.Number, default: 0},
  views: {type: mongoose.Schema.Types.Number, default: 0},
  tags: [{type: mongoose.Schema.Types.String}],
  handles: [{type: mongoose.Schema.Types.String}]
})

let Tweet = mongoose.model('Tweet', tweetSchema)

module.exports = Tweet
