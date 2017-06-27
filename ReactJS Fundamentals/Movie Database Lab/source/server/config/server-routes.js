const controllers = require('../controllers');

module.exports = (app) => {

    // User routes
    app.post('/user/register', controllers.user.register.post);
    app.post('/user/login', controllers.user.login.post);
    app.post('/user/logout', controllers.user.logout);
    app.get('/api/user/:userId', controllers.user.profile.get);
    app.get('/api/user/:userId/rated', controllers.movie.getUserRated.get);

    // Movie routes
    app.post('/api/movies/add', controllers.movie.add.post);
    app.get('/api/movies/top-ten', controllers.movie.topTen.get);
    app.get('/api/movies/five-recent', controllers.movie.fiveRecent.get);
    app.get('/api/movies/:movieId/comments', controllers.comment.getMovieComments.get);
    app.post('/api/movies/:movieId/comments', controllers.comment.getMovieComments.post);
    app.get('/api/movies', controllers.movie.search.get);

    // Vote routs
    app.get('/api/movies/:movieId/vote', controllers.vote.getVote.get);
    app.post('/api/movies/:movieId/vote', controllers.vote.add.post);

    // Movie voting
    // app.post('/api/movies/:movieId/vote', controllers.movie.vote.post);
};