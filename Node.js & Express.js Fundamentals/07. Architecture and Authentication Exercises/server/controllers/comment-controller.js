const Comment = require('../data/Comment');
const Article = require('../data/Article')

module.exports = {
    addPost: (req, res) => {
        let articleId = req.params.id;
        let userId = req.user._id;
        let commentReq = req.body;

        Comment.create({
            content: commentReq.content,
            article: articleId,
            creator: userId
        }).then(comment => {
            Article.findById(articleId).then(article => {
                article.comments.push(comment._id);
                article.save().then(() => {
                    res.redirect(`/article/details/${articleId}`);
                })
            })
        })
    },

    editGet: (req, res) => {
        let id = req.params.id;
        
        Comment.findById(id).populate('creator').populate('article').then(comment => {
            if(comment.creator._id.toString() === req.user._id.toString() || req.user.roles.indexOf('Admin') >= 0) {
                res.render('comment/edit', {
                    comment: comment
                })
            } else {
                res.redirect(`/article/details/${comment.article._id}`);
            }
        })
    },

    editPost: (req, res) => {
        let id = req.params.id;
        let commentReq = req.body;

        Comment.findById(id).populate('creator').then((comment) => {
            if(comment.creator._id.toString() === req.user._id.toString() || req.user.roles.indexOf('Admin') >= 0) {
                comment.content = commentReq.content;
                comment.save().then(() =>{
                    res.redirect(`/article/details/${comment.article}`);
                })
            } else {
                res.redirect('/users/login');
            }
        })
    },

    deleteGet: (req, res) => {
        let id = req.params.id;
        
        Comment.findById(id).populate('creator').populate('article').then(comment => {
            res.render('comment/delete', {
                comment: comment
            })
        })
    },

    deletePost: (req, res) => {
        let id = req.params.id;

        Comment.findByIdAndRemove(id).then(comment => {
            Article.findByIdAndUpdate(comment.article, {
                $pull: { 'comments' :{ $in: [comment._id] } }
            }).then((article) => {
                res.redirect(`/article/details/${article._id}`);
            })
        })
    }
}