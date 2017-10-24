const express = require('express')
const animalsData = require('../data/animals')
const usersData = require('../data/users')

const router = new express.Router()

router.get('/', (req, res) => {
  const animals = animalsData.total()
  const users = usersData.total()

  res.status(200).json({
    animals,
    users
  })
})

module.exports = router
