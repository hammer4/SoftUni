const mongoose = require('mongoose');

let voteSchema = mongoose.Schema({
    movie: { type: mongoose.Schema.Types.ObjectId, ref: 'Movie', required: true },
    userId: { type: mongoose.Schema.Types.ObjectId, required: true },
    score: {
        type: mongoose.Schema.Types.Number,
        required: true,
        validate: {
            validator: (score) => {
                return score > 0 && score <= 10;
            },
            message: '[MongoDB] Validation error: score must be between 1 and 10 inclusively.'
        }
    },
    isReviewScore: { type: mongoose.Schema.Types.Boolean, default: false }
});

let Vote = mongoose.model('Vote', voteSchema);

module.exports = Vote;