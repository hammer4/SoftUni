const mongoose = require('mongoose')

let categorySchema = mongoose.Schema({
  name: { type: mongoose.Schema.Types.String, required: true, unique: true },
  threads: [ { type: mongoose.Schema.Types.ObjectId, ref: 'Thread' } ]
})

let Category = mongoose.model('Category', categorySchema)

module.exports = Category
