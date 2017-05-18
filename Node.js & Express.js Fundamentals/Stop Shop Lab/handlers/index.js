const homeHandler = require('./home');
const fileHandler = require('./static-files');
const productHandler = require('./product');

module.exports = [ homeHandler, fileHandler, productHandler ];