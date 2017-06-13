const home = require('./home-controller')
const users = require('./users-controller')
const category = require('./category-controller')
const thread = require('./thread-controller')
const answer = require('./answer-controller')

module.exports = {
  home: home,
  users: users,
  category: category,
  thread: thread,
  answer: answer
}
