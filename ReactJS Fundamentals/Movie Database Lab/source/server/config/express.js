const express = require('express');
const logger = require('morgan');
const bodyParser = require('body-parser');
const path = require('path');
const passport = require('passport');
const session = require('express-session');
const swig = require('swig');
const React = require('react');
const ReactDOM = require('react-dom/server');
const Router = require('react-router');

const routes = require('../../client/routes');

module.exports = {
    attachMiddleWares: (app) => {
        app.set('port', process.env.PORT || 3000);
        app.use(logger('dev'));
        app.use(bodyParser.json());
        app.use(bodyParser.urlencoded({extended: false}));
        app.use(express.static(path.normalize(path.join(__dirname, '../../../public'))));
        app.use(session({secret: 'S3cr3t', saveUninitialized: false, resave: false}));
        app.use(passport.initialize());
        app.use(passport.session());
    },
    serveReactRoutes: (app) => {
        app.use(function (req, res) {
            Router.match({routes: routes.default, location: req.url}, function (err, redirectLocation, renderProps) {
                if (err) {
                    res.status(500).send(err.message);
                } else if (redirectLocation) {
                    res.status(302).redirect(redirectLocation.pathname + redirectLocation.search);
                } else if (renderProps) {
                    let html = ReactDOM.renderToString(React.createElement(Router.RoutingContext, renderProps));
                    let page = swig.renderFile('index.html', {html: html});
                    res.status(200).send(page);
                } else {
                    res.status(404).send('Page Not Found')
                }
            });
        });
    }
};