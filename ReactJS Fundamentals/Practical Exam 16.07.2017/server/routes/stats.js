const express = require('express')
const carsData = require('../data/cars')
const usersData = require('../data/users')

const router = new express.Router()

router.get('/', (req, res) => {
  const cars = carsData.total()
  const users = usersData.total()

  res.status(200).json({
    cars,
    users
  })
})

module.exports = router
