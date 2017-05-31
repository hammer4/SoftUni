let mongoose = require('mongoose');

let imageSchema = mongoose.Schema({
    url: {type: mongoose.Schema.Types.String, required: true},
    creationDate: {type: mongoose.Schema.Types.Date, default: Date.now()},
    description: {type: mongoose.Schema.Types.String},
    tags: [{type: mongoose.Schema.Types.ObjectId, ref: 'Tag'}]
});

let Image = mongoose.model('Image', imageSchema);

module.exports = Image;