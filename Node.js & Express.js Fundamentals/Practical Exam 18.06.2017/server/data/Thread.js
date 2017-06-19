const mongoose = require('mongoose')

let threadSchema = new mongoose.Schema({
  participants: [ { type: mongoose.Schema.Types.ObjectId, ref: 'User' } ],
  messages: [ { type: mongoose.Schema.Types.ObjectId, ref: 'Message' } ],
  latestMessageDate: {type: mongoose.Schema.Types.Date}
})

let Thread = mongoose.model('Thread', threadSchema)

module.exports = Thread
