const homeHandler = require('./home');
const productHandler = require('./product');
const categoryHandler = require('./category');

module.exports = {
    home: homeHandler,
    product: productHandler,
    category: categoryHandler
}