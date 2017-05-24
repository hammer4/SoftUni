const fs = require('fs');

module.exports = (req, res) => {
    if(req.path === '/favicon.ico') {
        fs.readFile('./favicon.ico', (err, data) => {
            if(err) {
                console.log(err);
                return;
            }

            res.writeHead(200, {
                'Content-Type': 'image/x-icon'
            });
            res.write(data);
            res.end();
        })
    } else {
        return true;
    }
}