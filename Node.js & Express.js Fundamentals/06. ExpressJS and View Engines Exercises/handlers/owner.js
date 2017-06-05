const Owner = require('../models/Owner');

module.exports.addGet = (req, res) => {
    res.render('owner/add');
}

module.exports.addPost = (req, res) => {
    let ownerObj = req.body;
    ownerObj.image = '\\' + req.file.path;

    Owner.create(ownerObj).then(() => {
        res.redirect('/');
    })
}

module.exports.carsGet = (req, res) => {
    ownerName = req.params.ownerName.split('-').join(' ');

    Owner.findOne({name: ownerName})
        .populate('cars')
        .then((owner) => {
            res.render('owner/cars', {owner: owner});
    })
}