const express = require('express')
const authCheck = require('../middleware/auth-check')
const animalsData = require('../data/animals')

const router = new express.Router()

function validateAnimalForm (payload) {
  const errors = {}
  let isFormValid = true
  let message = ''

  payload.age = parseInt(payload.age)
  payload.price = parseInt(payload.price)

  if (!payload || typeof payload.name !== 'string' || payload.name.length < 3) {
    isFormValid = false
    errors.name = 'Name must be more than 3 symbols.'
  }

  if (!payload || !payload.age || payload.age < 0 || payload.age > 100) {
    isFormValid = false
    errors.age = 'Age must be between 0 and 100.'
  }
  
  if (!payload || typeof payload.color !== 'string' || payload.color.length < 3) {
    isFormValid = false
    errors.color = 'Color must be more than 3 symbols.'
  }

  if (!payload || typeof payload.type !== 'string' || 
    (payload.type !== 'Cat' && payload.type !== 'Dog' && payload.type !== 'Bunny' && payload.type !== 'Exotic' && payload.type !== 'Other')) {
    isFormValid = false
    errors.type = 'Type must Cat, Dog, Bunny, Exotic or Other.'
  }

  if (!payload || !payload.price || payload.price < 0) {
    isFormValid = false
    errors.price = 'Price must be a positive number.'
  }

  if (!payload || typeof payload.image !== 'string' || payload.image === 0) {
    isFormValid = false
    errors.image = 'Image URL is required.'
  }

  if (payload && payload.breed) {
    if (!payload || typeof payload.breed !== 'string' || payload.breed.length < 3) {
      isFormValid = false
      errors.breed = 'Breed must be more than 3 symbols.'
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
  const animal = req.body
  animal.createdBy = req.user.email

  const validationResult = validateAnimalForm(animal)
  if (!validationResult.success) {
    return res.status(200).json({
      success: false,
      message: validationResult.message,
      errors: validationResult.errors
    })
  }

  animalsData.save(animal)

  res.status(200).json({
    success: true,
    message: 'Animal added successfuly.',
    animal
  })
})

router.get('/all', (req, res) => {
  const page = parseInt(req.query.page) || 1
  const search = req.query.search

  const animals = animalsData
    .all(page, search)
    .map(a => ({
      id: a.id,
      name: a.name,
      age: a.age,
      color: a.color,
      type: a.type,
      price: a.price,
      image: a.image,
      createdOn: a.createdOn,
    }))

  res.status(200).json(animals)
})

router.get('/details/:id', authCheck, (req, res) => {
  const id = req.params.id

  const animal = animalsData.findById(id)

  if (!animal) {
    return res.status(200).json({
      success: false,
      message: 'Animal does not exists!'
    })
  }

  let response = {
    id,
    name: animal.name,
    age: animal.age,
    color: animal.color,
    type: animal.type,
    price: animal.price,
    image: animal.image,
    createdOn: animal.createdOn,
    reactions: {
      like: animal.reactions.like.length,
      love: animal.reactions.love.length,
      haha: animal.reactions.haha.length,
      wow: animal.reactions.wow.length,
      sad: animal.reactions.sad.length,
      angry: animal.reactions.angry.length
    } 
  }

  if (animal.breed) {
    response.breed = animal.breed
  }

  res.status(200).json(response)
})

router.post('/details/:id/comments/create', authCheck, (req, res) => {
  const id = req.params.id
  const user = req.user.name

  const animal = animalsData.findById(id)

  if (!animal) {
    return res.status(200).json({
      success: false,
      message: 'Animal does not exists!'
    })
  }

  const message = req.body.message

  if (!message || message.length < 10) {
    return res.status(200).json({
      success: false,
      message: 'Comment must be more than 10 symbols.'
    })
  }

  animalsData.addComment(id, message, user)

  res.status(200).json({
    success: true,
    message: 'Comment added successfuly.',
    comment: {
      id,
      message,
      user
    }
  })
})

router.post('/details/:id/reaction', authCheck, (req, res) => {
  const id = req.params.id
  const user = req.user.email
  const reactionType = req.body.type

  const animal = animalsData.findById(id)

  if (!animal) {
    return res.status(200).json({
      success: false,
      message: 'Animal does not exists!'
    })
  }

  const result = animalsData.reaction(id, reactionType, user)

  if (!result) {
    return res.status(200).json({
      success: false,
      message: 'Invalid reaction!'
    })
  }

  return res.status(200).json({
    success: true,
    message: 'Thank you for your reaction!'
  })
})

router.get('/details/:id/comments', authCheck, (req, res) => {
  const id = req.params.id

  const animal = animalsData.findById(id)

  if (!animal) {
    return res.status(200).json({
      success: false,
      message: 'Animal does not exists!'
    })
  }

  const comments = animalsData.allComments(id)

  res.status(200).json(comments)
})

router.get('/mine', authCheck, (req, res) => {
  const user = req.user.email

  const animals = animalsData
    .byUser(user)
    .map(a => ({
      id: a.id,
      name: a.name,
      age: a.age,
      color: a.color,
      type: a.type,
      price: a.price,
      image: a.image,
      createdOn: a.createdOn,
    }))

  res.status(200).json(animals)
})

router.post('/delete/:id', authCheck, (req, res) => {
  const id = req.params.id
  const user = req.user.email

  const animal = animalsData.findById(id)

  if (!animal || animal.createdBy !== user) {
    return res.status(200).json({
      success: false,
      message: 'Animal does not exists!'
    })
  }

  animalsData.delete(id)

  return res.status(200).json({
    success: true,
    message: 'Animal deleted successfully!'
  })
})

module.exports = router
