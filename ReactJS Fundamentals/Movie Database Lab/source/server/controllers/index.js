const movieController = require('./movie');
const commentController = require('./comment');
const userController = require('./user');
const voteController = require('./vote');

module.exports = {
    movie: movieController,
    comment: commentController,
    user: userController,
    vote: voteController
};