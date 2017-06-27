const mongoose = require('mongoose');

const User = require('../models/User');
const encryption = require('../utilities/encryption');

function seedAdmin() {
    User.find({username: 'admin'}).then(users => {
        if (users.length === 0) {
            let pwd = 'admin';
            let salt = encryption.generateSalt();
            let hashedPwd = encryption.generateHashedPassword(salt, pwd);

            let adminData = {
                username: 'admin',
                firstName: 'Alex',
                lastName: 'Chobanov',
                salt: salt,
                password: hashedPwd,
                age: 33,
                gender: 'Male',
                roles: ['Admin', 'Critic']
            };

            User.create(adminData).then(admin => {
                console.log(`Seeded admin: ${admin.username}`);
            });
        }
    });
}

module.exports = (envConfig) => {
    mongoose.Promise = global.Promise;
    mongoose.connect(envConfig.database);

    mongoose.connection.once('open', () => {
        console.log('Connected to MongoDB.');
    });

    mongoose.connection.on('error', () => {
        console.log('Error: Could not connect to MongoDB. Did you forget to run `mongod`?');
    });

    seedAdmin();
};


