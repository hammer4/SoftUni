const http = require('http');
const port = 3001;
const url = require('url');
const handlers = require('./handlers');
http
    .createServer((req, res) => {
        req.path = url.parse(req.url).pathname;

        for(let handler of handlers) {
            let next = handler(req, res);
            if(!next) {
                break;
            }
        }
    })
    .listen(port);

console.log(`Server listening on port ${port}`);