const homeHandler = require('./home');
const ownerHandler = require('./owner');
const carHandler = require('./car');

module.exports = {
    home: homeHandler,
    owner: ownerHandler,
    car: carHandler
}