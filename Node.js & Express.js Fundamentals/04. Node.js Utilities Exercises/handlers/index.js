let homePageHandler = require('./home-page');
let faviconHandler = require('./favicon');
let staticFilesHandler = require('./static-files');
let imagesHandler = require('./images');
let headerHandler = require('./header');

module.exports = [
    headerHandler,
    homePageHandler,
    faviconHandler,
    imagesHandler,
    staticFilesHandler
]