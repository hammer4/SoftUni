let path = require('path');
let fs = require('fs');
let qs = require('querystring');
let database = require('../config/database');

module.exports = (req, res) => {
    if(req.path === '/images/add' && req.method === 'GET') {
        let filePath = path.normalize(path.join(__dirname, '../content/add.html'));

        fs.readFile(filePath, (err, data) => {
            if(err) {
                console.log(err);
            }

            res.writeHead(200, {
                'Content-Type' : 'text/html'
            });
            res.write(data);
            res.end();
        })
    } else if(req.path === '/images/add' && req.method === 'POST'){
        let body = '';

        req.on('data', (data) => {
            body += data;
        });

        req.on('end', () => {
            let image = qs.parse(body);

            if(!image.name || !image.url){
                res.writeHead(200);
                res.write('Some of the fields are not filled.');
                res.end();
            } else {
                database.images.add(image)
                res.writeHead(302, {
                    Location: '/'
                });
                res.end();
            }
        })
    } else if (req.path === '/images/all' && req.method === 'GET') {
        let filePath = path.normalize(path.join(__dirname, '../content/all.html'));

        fs.readFile(filePath, (err, data) => {
            if(err) {
                console.log(err);
                res.writeHead(404, {
                    'Content-Type': 'text/plain'
                });
                res.write('404 Not Found!');
                res.end();
                return;
            }

            res.writeHead(200, {
                'Content-Type': 'text/html'
            });
            
            let images = database.images.getAll();
            let content = '';

            for(let image of images) {
                content += `<div class="image">
                <img class="img" src="${image.url}" />
                <h2>${image.name}</h2>
                <a href=/images/details/${image.id}>View Details</a>
                </div>`
            }

            let html = data.toString().replace('{content}', content);

            res.write(html);
            res.end();
        })
    } else if (req.path.startsWith('/images/details/') && req.method === 'GET'){
        let id = Number(req.path.split('/').pop());

        let filePath = path.normalize(path.join(__dirname, '../content/details.html'));
        fs.readFile(filePath, (err, data) => {
            if(err) {
                console.log(err);
                res.writeHead(404, {
                    'Content-Type': 'text/plain'
                });
                res.write('404 Not Found!');
                res.end();
                return;
            }

            res.writeHead(200, {
                'Content-Type': 'text/html'
            });

            let image = database.images.getById(id);

            content = `<div class="img-full">
            <h2>${image.name}</h2>
            <img src="${image.url}">
            </div>`;

            let html = data.toString().replace('{content}', content).replace('{img.id}', image.id);

            res.write(html);
            res.end();
        })
    } else {
        return true;
    }
}