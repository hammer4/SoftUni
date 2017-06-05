const mongoose = require('mongoose');

let carSchema = mongoose.Schema({
    brand: {type: mongoose.Schema.Types.String, required: true},
    model: {type: mongoose.Schema.Types.String, required: true},
    price: {type: mongoose.Schema.Types.Number, min: 0, max: Number.MAX_VALUE, default:0},
    image: {type: mongoose.Schema.Types.String},
    owner: {type: mongoose.Schema.Types.ObjectId, ref: 'Owner'}
});

let Car = mongoose.model('Car', carSchema);

module.exports = Car;