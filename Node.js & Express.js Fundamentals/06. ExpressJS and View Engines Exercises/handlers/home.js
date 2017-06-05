let Owner = require('../models/Owner');

module.exports.index = (req, res) => {
    Owner.find().then((owners) => {
        res.render('home/index', {owners: owners});
    })
}