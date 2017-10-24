const express = require('express')
const authCheck = require('../middleware/auth-check')
const articlesData = require('../data/articles')

const router = new express.Router()

function validateArticleForm (payload) {
  const errors = {}
  let isFormValid = true
  let message = ''

  payload.year = parseInt(payload.year)
 

  if (payload.mileage) {
    payload.mileage = parseInt(payload.mileage)
  }

  if (!payload || typeof payload.name !== 'string' || payload.name.length < 3) {
    isFormValid = false
    errors.name = 'Name must be more than 3 symbols.'
  }

  if (!payload || typeof payload.author !== 'string' || payload.author.length < 3) {
    isFormValid = false
    errors.author = 'Author must be more than 3 symbols.'
  }

  if (!payload || !payload.year || payload.year < 1950 || payload.year > 2050) {
    isFormValid = false
    errors.year = 'Year must be between 1950 and 2050.'
  }


  if (!payload || typeof payload.image !== 'string' || payload.image === 0) {
    isFormValid = false
    errors.image = 'Image URL is required.'
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
  const article = req.body
  article.createdBy = req.user.email

  const validationResult = validateArticleForm(article)
  if (!validationResult.success) {
    return res.status(200).json({
      success: false,
      message: validationResult.message,
      errors: validationResult.errors
    })
  }

  articlesData.save(article)

  res.status(200).json({
    success: true,
    message: 'Article added successfuly.',
    article
  })
})

router.get('/all', (req, res) => {
  const page = parseInt(req.query.page) || 1
  const search = req.query.search

  const articles = articlesData.all(page, search)

  res.status(200).json(articles)
})

router.get('/details/:id', authCheck, (req, res) => {
  const id = req.params.id

  const article = articlesData.findById(id)

  if (!article) {
    return res.status(200).json({
      success: false,
      message: 'Article does not exists!'
    })
  }

  let response = {
    id,
    name: article.name,
    author: article.author,
    details: article.details,
    year: article.year,
    image: article.image,
    createdOn: article.createdOn,
    likes: article.likes.length
  }


  res.status(200).json(response)
})

router.post('/details/:id/reviews/create', authCheck, (req, res) => {
  const id = req.params.id
  const user = req.user.name

  const article = articlesData.findById(id)

  if (!article) {
    return res.status(200).json({
      success: false,
      message: 'Article does not exists!'
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

  articlesData.addReview(id, rating, comment, user)

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

  const article = articlesData.findById(id)

  if (!article) {
    return res.status(200).json({
      success: false,
      message: 'Article does not exists!'
    })
  }

  const result = articlesData.like(id, user)

  if (!result) {
    return res.status(200).json({
      success: false,
      message: 'This user has already liked this article!'
    })
  }

  return res.status(200).json({
    success: true,
    message: 'Thank you for your like!'
  })
})

router.get('/details/:id/reviews', authCheck, (req, res) => {
  const id = req.params.id

  const article = articlesData.findById(id)

  if (!article) {
    return res.status(200).json({
      success: false,
      message: 'Article does not exists!'
    })
  }

  const response = articlesData.allReviews(id)

  res.status(200).json(response)
})

router.get('/mine', authCheck, (req, res) => {
  const user = req.user.email

  const articles = articlesData.byUser(user)

  res.status(200).json(articles)
})

router.post('/delete/:id', authCheck, (req, res) => {
  const id = req.params.id
  const user = req.user.email

  const article = articlesData.findById(id)

  if (!article || article.createdBy !== user) {
    return res.status(200).json({
      success: false,
      message: 'Article does not exists!'
    })
  }

  articlesData.delete(id)

  return res.status(200).json({
    success: true,
    message: 'Article deleted successfully!'
  })
})

module.exports = router
