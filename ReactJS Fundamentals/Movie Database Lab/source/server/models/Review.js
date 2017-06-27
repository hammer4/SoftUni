const mongoose = require('mongoose');

let reviewSchema = mongoose.Schema({
    author: { type: mongoose.Schema.Types.ObjectId, ref: 'User' },  // Add required on user authentication part.
    score: { type: mongoose.Schema.Types.Number, required: true },
    title: { type: mongoose.Schema.Types.String, required: true },
    content: { type: mongoose.Schema.Types.String, required: true },
    dateCreated: { type: mongoose.Schema.Types.String, default: Date.now }
});

let Review = mongoose.model('Review', reviewSchema);

module.exports =  Review;
