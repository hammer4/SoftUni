const Movie = require('../models/Movie');
const Vote = require('../models/Vote');

module.exports = {
    add:  {
        post: (req, res) => {
            let inputData = req.body;
            let movieData = {
                name: inputData.name,
                description: inputData.description,
                genres: inputData.genres
            };

            Movie.create(movieData).then(movie => {
                if (!movie) { return res.status(500).send({ message: 'Cannot write movie in database' }) }

                res.status(200).send({ message: `${movie.name} added!` });
            });
        }
    },
    topTen: {
        get: (req, res) => {
            Movie.find()
                .sort({ score: -1 })
                .limit(10)
                .then(movies => {
                    if (!movies) {
                        return res.status(400).send({ message: 'No movies. Care to add some?' });
                    }

                    res.status(200).send(movies);
                });
        }
    },
    fiveRecent: {
        get: (req, res) => {
            Movie.find()
                .sort({ dateCreated: -1 })
                .limit(5)
                .then(movies => {
                    if (!movies) {
                        return res.status(400).send({ message: 'No movies. Care to add some?' })
                    }

                    res.status(200).send(movies);
                });
        }
    },
    search: {
        get: (req, res) => {
            let query = req.query.query;
            console.log(query);
            Movie
                .find(
                    { $text: { $search: query } },
                    { matchScore: { $meta: 'textScore' } }
                )
                .sort({
                    matchScore: { $meta: 'textScore' },
                    score: -1
                })
                .then(movies => {
                    if (movies.length === 0) { return res.status(404).send({ message: 'Sorry! Movie not found...' }) }

                    res.status(200).send(movies)
                });
        }
    },
    getUserRated: {
        get: (req, res) => {
            let userId = req.params.userId;

            Vote.find({ userId })
                .sort({ score: -1 })
                .populate('movie')
                .then(votes => {
                    console.log('[Movie controller] gerUserRated() votes: ', votes);
                    // Check if necessary.
                    let movies = [];
                    votes.forEach(v => movies.push(v.movie)); // Filter only the movies, since we don't need vote information.

                    res.status(200).send(movies);
                });
        }
    }

};