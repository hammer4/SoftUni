const Article = require('../data/Article');
const Comment = require('../data/Comment')

module.exports = {
    addGet: (req, res) => {
        res.render('article/add');
    },

    addPost: (req, res) => {
        let articleReq = req.body
        articleReq.creator = req.user._id;

        Article.create({
            title: articleReq.title,
            content: articleReq.content,
            creator: articleReq.creator
        }).then(() => {
            res.redirect('/article/list');
        }).catch((err) => {
            res.locals.globalError = err;
            res.render('article/add', articleReq)
        })
    },

    list: (req, res) => {
        let pageSize = 3;
        let page = Number(req.query.page) || 1;
        let search = req.query.search;

        let query = Article.find();

        if(search) {
            query = query.where('title').regex(new RegExp(search, 'i'));
        }

        query.populate('creator').sort('date').skip((page - 1) * pageSize).limit(pageSize).then(articles => {
            res.render('article/list', {
                articles: articles,
                hasPrevPage: page > 1,
                hasNextPage: articles.length ==  pageSize,
                prevPage: page - 1,
                nextPage: page + 1,
                search: search
            });
        })
    },

    details: (req, res) => {
        let id = req.params.id;

        if(req.user) {
            Article.findById(id).populate('creator').then(article => {
                Comment.find({article: article._id}).populate('creator').sort('date').then(comments => {
                    res.render('article/details', {
                        article: article,
                        comments: comments
                    })
                })
            }).catch(err => {
                res.redirect('/article/list'); 
            })
        } else {
            res.redirect('/users/login');
        }
    },

    editGet: (req, res) => {
        let id = req.params.id;

        Article.findById(id).populate('creator').then(article => {
            if(req.user._id.toString() === article.creator._id.toString() || req.user.roles.indexOf('Admin') >= 0) {
                res.render('article/edit', {
                    article: {
                        title: article.title,
                        content: article.content
                    }
                })
            } else {
                res.redirect('/users/login');
            }
        }).catch(err => {
            res.redirect('/article/list'); 
        })
    },

    editPost: (req, res) => {
        let id = req.params.id;
        let articleReq = req.body;

        Article.findById(id).populate('creator').then(article => {
            if(req.user._id.toString() === article.creator._id.toString() || req.user.roles.indexOf('Admin') >= 0) {
                article.title = articleReq.title;
                article.content = articleReq.content;
                article.save().then(() => {
                    res.redirect(`/article/details/${article._id}`);
                })
            } else {
                res.redirect('/users/login');
            }
        }).catch(err => {
            res.redirect('/article/list');
        })
    },

    deleteGet: (req, res) => {
        let id = req.params.id;
        
        Article.findById(id).then(article => {
            res.render('article/delete', {
                article: article
            });
        })
    },

    deletePost: (req, res) => {
        let id = req.params.id;

        Article.findByIdAndRemove(id).then((article) => {
            Comment.remove({article: article._id}).then(() => {
                res.redirect('/article/list');
            })
        }).catch(err => {
            res.redirect(`/article/details/${id}`);
        })
    }
}