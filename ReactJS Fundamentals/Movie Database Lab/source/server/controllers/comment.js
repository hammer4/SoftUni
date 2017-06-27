const Comment = require('../models/Comment');

module.exports = {
    getMovieComments: {
        get: (req, res) => {
            let movieId = req.params.movieId;

            Comment.find({ movie: movieId })
                .sort({ dateCreated: -1 })
                .populate('author', '_id username')
                .then(comments => {
                    res.status(200).send(comments);
                })
        },
        post: (req, res) => {
            let movieId = req.params.movieId;
            let commentData = {
                movie: movieId,
                content: req.body.content
            };

            Comment.create(commentData).then(comment => {
                res.status(200).send({ comment });
            })

        }
    }
};