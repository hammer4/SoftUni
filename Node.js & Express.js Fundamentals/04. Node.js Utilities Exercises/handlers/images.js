let path = require('path');
let fs = require('fs');
let qs = require('querystring');
let database = require('../config/database');
let formidable = require('formidable');
let shortid = require('shortid');

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
        let form = new formidable.IncomingForm();

        form.parse(req, (err, fields, files) => {
            if(err) {
                console.log(err);
                return;
            }

            let uploadFile = files['upload'];
            if(uploadFile.type === 'image/jpeg') {
                let folderNumber = database.images.getAll().length % 1000;
                let imagePath = `/content/images/${folderNumber}`
                if(!fs.existsSync('.' + imagePath)) {
                    fs.mkdirSync('.' + imagePath);
                }
                let imgFileExtension = uploadFile.name.split('.').pop();
                let uniqueId = shortid.generate();
                uploadFile.name = `${uniqueId}.${imgFileExtension}`;

                fs.rename(uploadFile.path, `.${imagePath}/` + uploadFile.name, err => {
                    if(err) {
                        console.log(err);
                        return;
                    }
                    console.log('Saved!');

                    database.images.add({
                        private: fields.private,
                        name: fields.name,
                        url: `${imagePath}/` + uploadFile.name 
                    })

                    res.writeHead(302, {
                        Location: '/images/all'
                    })
                    res.end();
                });
            } else {
                res.write('Only .jpg files accepted');
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
                if(!image.hasOwnProperty('private')) {
                    content += `<div class="image">
                    <img class="img" src="${image.url}" />
                    <h2>${image.name}</h2>
                    <a href=/images/details/${image.id}>View Details</a>
                    </div>`
                }
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

            if (!image.hasOwnProperty('private')) {
                content = `<div class="img-full">
                <h2>${image.name}</h2>
                <a href="${image.url}">Download</a>
                <img src="${image.url}">
                </div>`;

                let html = data.toString().replace('{content}', content).replace('{img.id}', image.id);

                res.write(html);
                res.end();
            } else {
                res.write("This image is private!");
                res.end();
            }
        })
    } else {
        return true;
    }
}