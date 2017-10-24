const mongoose = require('mongoose')

let categorySchema = mongoose.Schema({
  articles: [{type: mongoose.Schema.Types.ObjectId, ref: 'Article'}],
  name: {type: mongoose.Schema.Types.String, required: true}
})

let Category = mongoose.model('Category', categorySchema)

module.exports = Category
