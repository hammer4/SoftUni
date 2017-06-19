const controllers = require('../controllers')
const auth = require('./auth')

module.exports = (app) => {
  app.get('/', controllers.home.index)

  app.get('/thread/:username', auth.isAuthenticated, controllers.thread.displayThread)
  app.post('/thread/:username', auth.isAuthenticated, controllers.thread.addMessage)
  app.post('/like/:username/:id', auth.isAuthenticated, controllers.thread.likeMessage)
  app.post('/dislike/:username/:id', auth.isAuthenticated, controllers.thread.dislikeMessage)
  app.post('/block/:username', auth.isAuthenticated, controllers.users.block)
  app.post('/unblock/:username', auth.isAuthenticated, controllers.users.unblock)

  app.get('/users/register', controllers.users.registerGet)
  app.post('/users/register', controllers.users.registerPost)
  app.get('/users/login', controllers.users.loginGet)
  app.post('/users/login', controllers.users.loginPost)
  app.post('/users/logout', controllers.users.logout)

  app.all('*', (req, res) => {
    res.status(404)
    res.send('404 Not Found!')
    res.end()
  })
}
