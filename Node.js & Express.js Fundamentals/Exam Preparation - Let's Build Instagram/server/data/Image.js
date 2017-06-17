const mongoose = require('mongoose')

let tweetSchema = new mongoose.Schema({
  description: {type: mongoose.Schema.Types.String, maxlength: 140, required: true},
  url: {type: mongoose.Schema.Types.String, required: true},
  owner: {type: mongoose.Schema.Types.ObjectId, ref: 'User'},
  date: {type: mongoose.Schema.Types.Date, default: Date.now},
  likes: {type: mongoose.Schema.Types.Number, default: 0},
  views: {type: mongoose.Schema.Types.Number, default: 0},
  tags: [{type: mongoose.Schema.Types.String}],
  handles: [{type: mongoose.Schema.Types.String}]
})

let Image = mongoose.model('Image', tweetSchema)

module.exports = Image
