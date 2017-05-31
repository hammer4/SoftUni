let mongoose = require('mongoose');

let tagSchema = mongoose.Schema({
    name: {type: mongoose.Schema.Types.String, required: true},
    creationDate: {type: mongoose.Schema.Types.Date, default: Date.now()},
    images: [{type: mongoose.Schema.Types.ObjectId, ref: 'Image'}]
});

let Tag = mongoose.model('Tag', tagSchema);

module.exports = Tag;