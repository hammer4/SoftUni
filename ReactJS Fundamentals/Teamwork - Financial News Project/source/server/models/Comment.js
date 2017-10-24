const mongoose = require('mongoose')

let commentSchema = mongoose.Schema({
  author: { type: mongoose.Schema.Types.ObjectId, ref: 'User' },
  content: {type: mongoose.Schema.Types.String, required: true},
  article: {type: mongoose.Schema.Types.ObjectId, ref: 'Article'},
  dateCreated: {type: mongoose.Schema.Types.Date, default: Date.now}
})

let Comment = mongoose.model('Comment', commentSchema)

module.exports = Comment
