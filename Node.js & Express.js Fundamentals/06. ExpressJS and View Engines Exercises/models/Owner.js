const mongoose = require('mongoose');

let ownerSchema = mongoose.Schema({
    name: {type: mongoose.Schema.Types.String, required: true},
    age: {type: mongoose.Schema.Types.Number, required: true},
    image: {type: mongoose.Schema.Types.String},
    cars: [{type: mongoose.Schema.Types.ObjectId, ref: 'Car'}]
});

let Owner = mongoose.model('Owner', ownerSchema);

module.exports = Owner;