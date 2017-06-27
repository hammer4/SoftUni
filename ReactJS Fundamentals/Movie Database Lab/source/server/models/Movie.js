let mongoose = require('mongoose');

let movieSchema = mongoose.Schema({
    name: { type: mongoose.Schema.Types.String, required: true },
    description: { type: mongoose.Schema.Types.String },
    genres: [{ type: mongoose.Schema.Types.String, required: true }],
    // topBilledCast: [{ type: mongoose.Schema.Types.ObjectId, ref: 'Actor', default: [] }],
    score: { type: mongoose.Schema.Types.Number, default: 0 },
    votes: { type: mongoose.Schema.Types.Number, default: 0 },
    dateCreated: { type: mongoose.Schema.Types.Date, default: Date.now }
});

let indexFields = {
    name: 'text',
    description: 'text',
    genres: 'text'
};

movieSchema.index(indexFields);

let Movie = mongoose.model('Movie', movieSchema);

module.exports = Movie;