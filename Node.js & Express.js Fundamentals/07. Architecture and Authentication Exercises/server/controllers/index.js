const home = require('./home-controller')
const users = require('./users-controller')
const article = require('./article-controller')
const comment = require('./comment-controller')

module.exports = {
  home: home,
  users: users,
  article: article,
  comment: comment
}
