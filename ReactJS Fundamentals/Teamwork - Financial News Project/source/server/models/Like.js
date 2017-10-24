const mongoose = require('mongoose')

let likeSchema = mongoose.Schema({
  article: {type: mongoose.Schema.Types.ObjectId, ref: 'Article', required: true},
  userId: {type: mongoose.Schema.Types.ObjectId, ref: 'User', required: true}
})

let Like = mongoose.model('Like', likeSchema)

module.exports = Like
