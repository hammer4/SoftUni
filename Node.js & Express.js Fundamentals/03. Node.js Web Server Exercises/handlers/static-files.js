const fs = require('fs');

let getContentType = (url) => {
    let contentType = 'text/plain';
    if(url.endsWith('.css')) {
        contentType = 'text/css';
    } else if (url.endsWith('.js')){
        contentType = 'application/javascript';
    } else if (url.endsWith('.html')) {
        contentType = 'text/html';
    } else if (url.endsWith('.jpg')) {
        contentType = 'image/jpeg';
    }

    return contentType;
}

module.exports = (req, res) => {
    fs.readFile('.' + req.path, (err, data) => {
        if(err || !req.path.startsWith('/content/')) {
            res.writeHead(404);
            res.write('404 Not Found!');
            res.end();
            return;
        } 
       
        let url = req.path;
        if (url.endsWith('.css') || url.endsWith('.js') || url.endsWith('.html') || url.endsWith('.jpg')) {
            res.writeHead(200, {
                'Content-Type' : getContentType(url)
            });
            res.write(data);
            res.end();
        } else {
            res.writeHead(403);
            res.write('403 Forbidden!');
            res.end();
        }
    });
}