const mongoose = require('mongoose')

let threadSchema = mongoose.Schema({
  title: { type: mongoose.Schema.Types.String, required: true },
  description: { type: mongoose.Schema.Types.String, required: true },
  date: { type: mongoose.Schema.Types.Date, required: true, default: Date.now },
  answers: [ {type: mongoose.Schema.Types.ObjectId, ref: 'Answer'} ],
  lastAnswerDate: { type: mongoose.Schema.Types.Date, default: Date.now },
  likes: { type: mongoose.Schema.Types.Number, default: 0 },
  views: { type: mongoose.Schema.Types.Number, default: 0 },
  category: { type: mongoose.Schema.Types.ObjectId, ref: 'Category' },
  author: { type: mongoose.Schema.Types.ObjectId, ref: 'User' }
})

let Thread = mongoose.model('Thread', threadSchema)

module.exports = Thread
