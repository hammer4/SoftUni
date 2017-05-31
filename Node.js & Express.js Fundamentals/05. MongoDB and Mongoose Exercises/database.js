let mongoose = require('mongoose');
let dbName = 'mongoose-exercises';
let connection = `mongodb://localhost:27017/${dbName}`;

module.exports = () => {
    return new Promise((resolve, reject) => {
        mongoose.Promise = global.Promise;
        mongoose.connect(connection);
        let database = mongoose.connection;

        database.once('open', (err) => {
            if(err) {
                console.log(err);
                return;
            }

            console.log('Connected to Mongo!');
            resolve();
        });

        database.on('error', (err) => {
            console.log(err);
            reject();
        });
    });
}