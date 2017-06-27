const mongoose = require('mongoose');

let actorSchema = mongoose.Schema({
    name: { type: mongoose.Schema.Types.String, required: true },
    pictureUrl: { type: mongoose.Schema.Types.String, default: '/public/images/user-default.jpg' },
    about: { type: mongoose.Schema.Types.String }
});

let Actor = mongoose.model('Actor', actorSchema);

module.exports = Actor;