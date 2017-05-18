const url = require('url');
const fs = require('fs');
const path = require('path');
const database = require('../config/database');
const qs = require('querystring');

module.exports = (req, res) => {
    req.pathname = req.pathname || url.parse(req.url).pathname;

    if(req.pathname === '/' && req.method === 'GET') {
        let filePath = path.normalize(path.join(__dirname, '../views/home/index.html'));

        fs.readFile(filePath, (err, data) => {
            if(err) {
                console.log(err);
                res.writeHead(404, {
                    'Content-Type': 'text/plain'
                })

                res.write('404 not found!');
                res.end();
                return;
            }

            res.writeHead(200, {
                'Content-Type': 'text/html'
            })

            let queryData = qs.parse(url.parse(req.url).query)
            let products = database.products.getAll();
            
            if(queryData.query) {
                products = products.filter(p => p.name.toLowerCase().indexOf(queryData.query.toLowerCase()) != -1)
            }

            let content = '';
            for (let product of products) {
                content += `<div class="product-card">
                <img class="product-img" src="${product.image}">
                <h2>${product.name}</h2>
                <p>${product.description}</p>
                </div>`
            }

            let html = data.toString().replace('{content}', content)

            res.write(html);
            res.end();
        })
    } else {
        return true;
    }
}