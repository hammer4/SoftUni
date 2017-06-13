const mongoose = require('mongoose')

let answerSchema = mongoose.Schema({
  thread: { type: mongoose.Schema.Types.ObjectId, ref: 'Thread' },
  author: { type: mongoose.Schema.Types.ObjectId, ref: 'User' },
  date: { type: mongoose.Schema.Types.Date, default: Date.now },
  content: { type: mongoose.Schema.Types.String, required: true }
})

let Answer = mongoose.model('Answer', answerSchema)

module.exports = Answer
