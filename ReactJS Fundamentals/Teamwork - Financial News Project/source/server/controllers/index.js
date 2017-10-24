const commentController = require('./comment')
const userController = require('./user')
const categoryController = require('./category')
const articleController = require('./article')

module.exports = {
  comment: commentController,
  user: userController,
  category: categoryController,
  article: articleController
}
