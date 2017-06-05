const handlers = require('../handlers');
const multer = require('multer');

let upload = multer({dest: './content/images'});

module.exports = (app) => {
    app.get('/', handlers.home.index);

    app.get('/owner/add', handlers.owner.addGet);
    app.post('/owner/add', upload.single('image'), handlers.owner.addPost);

    app.get('/car/add', handlers.car.addGet);
    app.post('/car/add', upload.single('image'), handlers.car.addPost);

    app.get('/:ownerName/cars', handlers.owner.carsGet);

    app.get('/car/edit/:id', handlers.car.editGet);
    app.post('/car/edit/:id', upload.single('image'), handlers.car.editPost);

    app.get('/car/delete/:id', handlers.car.deleteGet);
    app.post('/car/delete/:id', handlers.car.deletePost);
}
