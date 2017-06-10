const mongoose = require('mongoose');

let commentSchema = mongoose.Schema({
    article: { type: mongoose.Schema.Types.ObjectId, ref: 'Article' },
    content: { type: String, required: true },
    creator: { type: mongoose.Schema.Types.ObjectId, ref: 'User', required:true },
    date: { type: Date, required: true, default: Date.now }
});

let Comment = mongoose.model('Comment', commentSchema);

module.exports = Comment;