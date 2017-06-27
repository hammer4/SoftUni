const Vote = require('../models/Vote');
const Movie = require('../models/Movie');

module.exports = {
    add: {
        post: (req, res) => {
            let movie = req.params.movieId;
            let userId = req.user._id;
            let voteData = {
                movie: movie,
                userId: userId,
                score: Number(req.body.score)
            };

            if (req.body.isReviewScore) {
                voteData.isReviewScore = true;
            }
            Vote.findOne({ movie, userId }).then(existingVote => {
                if (!existingVote) {
                    Vote.create(voteData).then(vote => {
                        if (!vote) { return res.status(500).send({ message: 'Internal server error. No connection to database' }); }

                        req.user.votes += 1;
                        req.user.save();

                        Movie.findById(movie).then(movie => {
                            if (!movie) { return res.status(404).send({ message: 'Move no longer exists' }); }

                            movie.score += vote.score;
                            movie.votes += 1;
                            movie.save();

                            let data = {
                                hasUserVoted: true,
                                voteScore: vote.score,
                                movieScore: movie.score,
                                movieVotes: movie.votes
                            };
                            res.status(200).send(data);
                        });
                    });

                    return;
                }

                let oldVoteScore = existingVote.score;
                existingVote.score = voteData.score;
                existingVote.save();

                Movie.findById(movie).then(movie => {
                    if (!movie) { return res.status(404).send({ message: 'Move no longer exists' }); }

                    movie.score += (existingVote.score - oldVoteScore);
                    movie.save();

                    let data = {
                        hasUserVoted: true,
                        voteScore: existingVote.score,
                        movieScore: movie.score,
                        movieVotes: movie.votes
                    };
                    res.status(200).send(data);
                })

            });

        }
    },
    getVote:  {
        get: (req, res) => {
            let userId;
            if (req.query.user === 'loggedInUser') {
                userId = req.user._id;
            } else {
                userId = req.query.userId;
            }
            let movie = req.params.movieId;

            Vote.findOne({ userId, movie }).then(vote => {
                let data = {};
                if (!vote) {
                    data.hasUserVoted = false;
                    data.voteScore = '';
                    return res.status(200).send(data);
                }

                data.hasUserVoted = true;
                data.voteScore = vote.score;
                res.status(200).send(data);
            });
        }
    }
};