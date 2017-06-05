let Car = require('../models/Car');
let Owner = require('../models/Owner');
let fs = require('fs');
const path = require('path');

module.exports.addGet = (req, res) => {
    Owner.find().then((owners) => {
        res.render('car/add', {owners: owners});
    })
}

module.exports.addPost = (req, res) => {
    let carObj = req.body;
    carObj.image = '\\' + req.file.path;

    Car.create(carObj).then((car) =>{
        Owner.findById(car.owner).then((owner) => {
            owner.cars.push(car._id);
            owner.save()
        });

        res.redirect('/');
    })

}

module.exports.editGet = (req, res) => {
    let id = req.params.id;

    Car.findById(id).then(car => {
        Owner.find().then(owners => {
            res.render('car/edit', {
                car: car,
                owners: owners
            })
        })
    })
}

module.exports.editPost = (req, res) => {
    let id = req.params.id;
    let editedCar = req.body;

    Car.findById(id).then((car) => {
        car.brand = editedCar.brand;
        car.model = editedCar.model;
        car.price = editedCar.price;

        if(req.file) {
            car.image = '\\' + req.file.path;
        }

        if(car.owner.toString() !== editedCar.owner) {
            Owner.findById(car.owner).then((currentOwner) => {
                Owner.findById(editedCar.owner).then((nextOwner) => {
                    let index = currentOwner.cars.indexOf(car._id);

                    if(index >= 0) {
                        currentOwner.cars.splice(index, 1);
                    }
                    currentOwner.save();
                    
                    nextOwner.cars.push(car._id);
                    nextOwner.save();

                    car.owner = editedCar.owner;

                    car.save().then(() => {
                        res.redirect('/');
                    })
                })
            })
        } else {
            car.save().then(() => {
                res.redirect('/');
            })
        }
    })
}

module.exports.deleteGet = (req, res) => {
    let id = req.params.id;
    Car.findById(id).then(car => {
        res.render('car/delete', {car: car});
    })
}

module.exports.deletePost = (req, res) => {
    let id = req.params.id;

    Car.findById(id).then((car) => {
        Owner.findById(car.owner).then((owner) => {
            let index = owner.cars.indexOf(id);
            if(index >= 0) {
                owner.cars.splice(index, 1);                
            }
            owner.save();
            
            Car.remove({_id: id}).then(() => {
                fs.unlink(path.normalize(path.join('.', car.image)), () => {
                    res.redirect('/');             
                })
            })
        })
    })
}
