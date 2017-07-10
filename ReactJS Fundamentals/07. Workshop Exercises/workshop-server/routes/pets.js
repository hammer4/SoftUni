const express = require('express')
const authCheck = require('../middleware/auth-check')
const petsData = require('../data/pets')

const router = new express.Router()

function validatePetForm (payload) {
  const errors = {}
  let isFormValid = true
  let message = ''

  payload.age = parseInt(payload.age)

  if (!payload || typeof payload.name !== 'string' || payload.name < 3) {
    isFormValid = false
    errors.name = 'Name must be more than 3 symbols.'
  }

  if (!payload || typeof payload.image !== 'string' || payload.image === 0) {
    isFormValid = false
    errors.image = 'Image URL is required.'
  }

  if (!payload || !payload.age || payload.age < 0) {
    isFormValid = false
    errors.age = 'Age must be a positive number.'
  }

  if (!payload || typeof payload.type !== 'string' || (payload.type !== 'Cat' && payload.type !== 'Dog' && payload.type !== 'Other')) {
    isFormValid = false
    errors.type = 'Type must be Cat, Dog or Other.'
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
  const pet = req.body

  const validationResult = validatePetForm(pet)
  if (!validationResult.success) {
    return res.status(200).json({
      success: false,
      message: validationResult.message,
      errors: validationResult.errors
    })
  }

  petsData.save(pet)

  res.status(200).json({
    success: true,
    message: 'Pet added successfuly.',
    pet
  })
})

router.get('/all', (req, res) => {
  const page = parseInt(req.query.page) || 1

  const pets = petsData.all(page)

  res.status(200).json(pets)
})

router.get('/details/:id', authCheck, (req, res) => {
  const id = req.params.id

  let pet = petsData.findById(id)

  if (!pet) {
    return res.status(200).json({
      success: false,
      message: 'Pet does not exists!'
    })
  }

  let response = {
    id,
    name: pet.name,
    image: pet.image,
    age: pet.age,
    type: pet.type,
    createdOn: pet.createdOn
  }

  if (pet.breed) {
    response.breed = pet.breed
  }

  res.status(200).json(response)
})

router.post('/details/:id/comments/create', authCheck, (req, res) => {
  const id = req.params.id
  const user = req.user.name

  let pet = petsData.findById(id)

  if (!pet) {
    return res.status(200).json({
      success: false,
      message: 'Pet does not exists!'
    })
  }

  const comment = req.body

  if (!comment.message || typeof comment.message !== 'string' || comment.message.length < 10) {
    return res.status(200).json({
      success: false,
      message: 'Comment message must be at least 10 symbols.'
    })
  }

  petsData.addComment(id, comment.message, user)

  res.status(200).json({
    success: true,
    message: 'Comment added successfuly.',
    comment: {
      id,
      message: comment.message,
      user
    }
  })
})

router.get('/details/:id/comments', authCheck, (req, res) => {
  const id = req.params.id

  const pet = petsData.findById(id)

  if (!pet) {
    return res.status(200).json({
      success: false,
      message: 'Pet does not exists!'
    })
  }

  const response = petsData.allComments(id)

  res.status(200).json(response)
})

module.exports = router
