const mongoose = require('mongoose')
const Car = mongoose.model('Car')
const Renting = mongoose.model('Renting')
const errorHandler = require('../utilities/error-handler')

module.exports = {
  addGet: (req, res) => {
    res.render('cars/add')
  },
  addPost: (req, res) => {
    let carReq = req.body

    if (carReq.pricePerDay <= 0) {
      res.locals.globalError = 'Price per day cannot be less than 0'
      res.render('cars/add', carReq)
      return
    }

    Car
      .create({
        make: carReq.make,
        model: carReq.model,
        year: carReq.year,
        pricePerDay: carReq.pricePerDay,
        power: carReq.power,
        image: carReq.image
      })
      .then(car => {
        res.redirect('/cars/all')
      })
      .catch(err => {
        let message = errorHandler.handleMongooseError(err)
        res.locals.globalError = message
        res.render('cars/add', carReq)
      })
  },
  all: (req, res) => {
    let pageSize = 2
    let page = parseInt(req.query.page) || 1
    let search = req.query.search

    let query = Car.find({isRented: false})

    if (search) {
      query = query.where('make').regex(new RegExp(search, 'i'))
    }

    query
      .sort('-createdOn')
      .skip((page - 1) * pageSize)
      .limit(pageSize)
      .then(cars => {
        res.render('cars/all', {
          cars: cars,
          hasPrevPage: page > 1,
          hasNextPage: cars.length > 0,
          prevPage: page - 1,
          nextPage: page + 1,
          search: search
        })
      })
  },
  rent: (req, res) => {
    let userId = req.user._id
    let carId = req.params.id
    let days = parseInt(req.body.days)

    Car
      .findById(carId)
      .then(car => {
        if (car.isRented) {
          res.locals.globalError = 'Car is already rented!'
          res.render('cars/all')
          return
        }

        Renting
          .create({
            user: userId,
            car: carId,
            days: days,
            totalPrice: car.pricePerDay * days
          })
          .then(renting => {
            car.isRented = true
            car
              .save()
              .then(car => {
                res.redirect('/users/me')
              })
          })
          .catch(err => {

          })
      })
      .catch(err => {
        let message = errorHandler.handleMongooseError(err)
        res.locals.globalError = message
        res.render('cars/all')
      })
  },

  editGet: (req, res) => {
    let id = req.params.id;

    Car.findById(id).then(car => {
      res.render('cars/edit', car);
    }).catch(err => {
      res.redirect('/cars/all');
    })
  },

  editPost: (req, res) => {
    let id = req.params.id;
    let carReq = req.body;

    Car.findById(id).then(car => {
      car.make = carReq.make;
      car.model = carReq.model;
      car.year = carReq.year;
      car.pricePerDay = carReq.pricePerDay;
      car.power = carReq.power;
      car.image = carReq.image;

      car.save().then(() => {
        res.redirect('/cars/all')
      }).catch(err => {
        res.locals.globalError = errorHandler.handleMongooseError(err);
        res.render('cars/edit', car);
      })
    }).catch(err => {
      res.redirect('/cars/all')
    })
  }
}
