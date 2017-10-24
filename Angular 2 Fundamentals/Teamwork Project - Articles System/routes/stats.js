const express = require('express')
const articlesData = require('../data/articles')
const usersData = require('../data/users')

const router = new express.Router()

router.get('/', (req, res) => {
  const articles = articlesData.total()
  const users = usersData.total()

  res.status(200).json({
    articles,
    users
  })
})

module.exports = router
