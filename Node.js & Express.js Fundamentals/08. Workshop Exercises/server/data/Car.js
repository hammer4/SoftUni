const mongoose = require('mongoose')

let carSchema = new mongoose.Schema({
  make: { type: String, required: true },
  model: { type: String, required: true },
  year: { type: Number, required: true },
  pricePerDay: { type: Number, required: true },
  power: { type: Number },
  createdOn: { type: Date, default: Date.now },
  image: { type: String, required: true },
  isRented: { type: Boolean, default: false },
})

let Car = mongoose.model('Car', carSchema)

module.exports = Car
