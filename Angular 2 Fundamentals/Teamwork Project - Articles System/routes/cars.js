const express = require('express')
const authCheck = require('../middleware/auth-check')
const carsData = require('../data/cars')

const router = new express.Router()

function validateCarForm (payload) {
  const errors = {}
  let isFormValid = true
  let message = ''

  payload.year = parseInt(payload.year)
  payload.price = parseInt(payload.price)

  if (payload.mileage) {
    payload.mileage = parseInt(payload.mileage)
  }

  if (!payload || typeof payload.make !== 'string' || payload.make.length < 3) {
    isFormValid = false
    errors.make = 'Make must be more than 3 symbols.'
  }

  if (!payload || typeof payload.model !== 'string' || payload.model.length < 3) {
    isFormValid = false
    errors.model = 'Model must be more than 3 symbols.'
  }

  if (!payload || !payload.year || payload.year < 1950 || payload.year > 2050) {
    isFormValid = false
    errors.year = 'Year must be between 1950 and 2050.'
  }

  if (!payload || typeof payload.engine !== 'string' || payload.engine.length < 1) {
    isFormValid = false
    errors.engine = 'Engine must be more than 1 symbol.'
  }

  if (!payload || !payload.price || payload.price < 0) {
    isFormValid = false
    errors.price = 'Price must be a positive number.'
  }

  if (!payload || typeof payload.image !== 'string' || payload.image === 0) {
    isFormValid = false
    errors.image = 'Image URL is required.'
  }

  if (payload.mileage) {
    if (payload.mileage < 0) {
      isFormValid = false
      errors.mileage = 'Mileage must be a positive number.'
    }
  }

  if (!isFormValid) {
    message = 'Check the form for errors.'
  }

  return {
    success: isFormValid,
    message,
    errors
  }
}

router.post('/create', authCheck, (req, res) => {
  const car = req.body
  car.createdBy = req.user.email

  const validationResult = validateCarForm(car)
  if (!validationResult.success) {
    return res.status(200).json({
      success: false,
      message: validationResult.message,
      errors: validationResult.errors
    })
  }

  carsData.save(car)

  res.status(200).json({
    success: true,
    message: 'Car added successfuly.',
    car
  })
})

router.get('/all', (req, res) => {
  const page = parseInt(req.query.page) || 1
  const search = req.query.search

  const cars = carsData.all(page, search)

  res.status(200).json(cars)
})

router.get('/details/:id', authCheck, (req, res) => {
  const id = req.params.id

  const car = carsData.findById(id)

  if (!car) {
    return res.status(200).json({
      success: false,
      message: 'Car does not exists!'
    })
  }

  let response = {
    id,
    make: car.make,
    model: car.model,
    year: car.year,
    engine: car.engine,
    price: car.price,
    image: car.image,
    createdOn: car.createdOn,
    likes: car.likes.length
  }

  if (car.mileage) {
    response.mileage = car.mileage
  }

  res.status(200).json(response)
})

router.post('/details/:id/reviews/create', authCheck, (req, res) => {
  const id = req.params.id
  const user = req.user.name

  const car = carsData.findById(id)

  if (!car) {
    return res.status(200).json({
      success: false,
      message: 'Car does not exists!'
    })
  }

  let rating = req.body.rating
  const comment = req.body.comment

  if (rating) {
    rating = parseInt(rating)
  }

  if (!rating || rating < 1 || rating > 5) {
    return res.status(200).json({
      success: false,
      message: 'Rating must be between 1 and 5.'
    })
  }

  carsData.addReview(id, rating, comment, user)

  res.status(200).json({
    success: true,
    message: 'Review added successfuly.',
    review: {
      id,
      rating,
      comment,
      user
    }
  })
})

router.post('/details/:id/like', authCheck, (req, res) => {
  const id = req.params.id
  const user = req.user.email

  const car = carsData.findById(id)

  if (!car) {
    return res.status(200).json({
      success: false,
      message: 'Car does not exists!'
    })
  }

  const result = carsData.like(id, user)

  if (!result) {
    return res.status(200).json({
      success: false,
      message: 'This user has already liked this car!'
    })
  }

  return res.status(200).json({
    success: true,
    message: 'Thank you for your like!'
  })
})

router.get('/details/:id/reviews', authCheck, (req, res) => {
  const id = req.params.id

  const car = carsData.findById(id)

  if (!car) {
    return res.status(200).json({
      success: false,
      message: 'Car does not exists!'
    })
  }

  const response = carsData.allReviews(id)

  res.status(200).json(response)
})

router.get('/mine', authCheck, (req, res) => {
  const user = req.user.email

  const cars = carsData.byUser(user)

  res.status(200).json(cars)
})

router.post('/delete/:id', authCheck, (req, res) => {
  const id = req.params.id
  const user = req.user.email

  const car = carsData.findById(id)

  if (!car || car.createdBy !== user) {
    return res.status(200).json({
      success: false,
      message: 'Car does not exists!'
    })
  }

  carsData.delete(id)

  return res.status(200).json({
    success: true,
    message: 'Car deleted successfully!'
  })
})

module.exports = router
