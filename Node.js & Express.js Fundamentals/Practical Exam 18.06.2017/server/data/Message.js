const mongoose = require('mongoose')

let messageSchema = new mongoose.Schema({
  date: { type: mongoose.Schema.Types.Date, default: Date.now },
  message: { type: mongoose.Schema.Types.String, maxlength: 1000, required: true },
  author: { type: mongoose.Schema.Types.ObjectId, ref: 'User' },
  isLink: { type: mongoose.Schema.Types.Boolean },
  isImage: { type: mongoose.Schema.Types.Boolean }
})

let Message = mongoose.model('Message', messageSchema)

module.exports = Message
