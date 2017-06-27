const User = require('../models/User');
const encryption = require('../utilities/encryption');

module.exports = {
    register: {
        post: (req, res) => {
            let userData = req.body;

            if (userData.password && userData.password !== userData.confirmedPassword) {
                return res.status(400).send({ message: 'Passwords do not match' });
            }

            let salt = encryption.generateSalt();
            userData.salt = salt;

            if (userData.password) {
                userData.password = encryption.generateHashedPassword(salt, userData.password);
            }

            User.create(userData)
                .then(user => {
                    req.logIn(user, (err, user) => {
                        if (err) {
                            return res.status(200).send({ message: 'Wrong credentials!' });
                        }

                        res.status(200);
                    })
                })
                .catch(error => {
                    res.status(500).send({ message: error });
                });
        },
    },
    login: {
        post: (req, res) => {
            let userData = req.body;

            User.findOne({username: userData.username}).then(user => {
                if (!user || !user.authenticate(userData.password)) {
                    return res.status(401).send({ message: 'Wrong credentials!' });
                }

                req.logIn(user, (err, user) => {
                    if (err) {
                        return res.status(401).send({ message: err });
                    }

                    res.status(200).send(req.user._id);
                })
            })
        },
    },
    logout: (req, res) => {
        req.logout();
        res.status(200).end();
    },
    profile: {
        get: (req, res) => {
            let userId = req.params.userId;

            User.findById(userId).then(user => {
                if (!user) { return res.status(404).send({ message: 'User no longer exists' }) }

                res.status(200).send(user);
            })
        }
    }
};