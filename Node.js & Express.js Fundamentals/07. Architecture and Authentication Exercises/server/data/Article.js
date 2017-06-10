const mongoose = require('mongoose');

let articleSchema = mongoose.Schema({
    title: { type: String, required: true },
    content: { type: String, required: true },
    creator: { type: mongoose.Schema.Types.ObjectId, ref: 'User', required:true },
    date: { type: Date, required: true, default: Date.now },
    comments : [ { type: mongoose.Schema.Types.ObjectId , ref: 'Comment'} ]
});

let Article = mongoose.model('Article', articleSchema);

module.exports = Article;