const controllers = require('../controllers')
const auth = require('./auth')

module.exports = (app) => {
  app.get('/', controllers.home.index)

  app.get('/users/register', controllers.users.registerGet)
  app.post('/users/register', controllers.users.registerPost)
  app.get('/users/login', controllers.users.loginGet)
  app.post('/users/login', controllers.users.loginPost)
  app.post('/users/logout', controllers.users.logout)

  app.get('/tweet', auth.isAuthenticated, controllers.tweet.addGet)
  app.post('/tweet', auth.isAuthenticated, controllers.tweet.addPost)
  app.get('/tag/:tagName', controllers.tweet.showByTag)
  app.post('/like/:id', auth.isAuthenticated, controllers.tweet.like)
  app.post('/dislike/:id', auth.isAuthenticated, controllers.tweet.dislike)
  app.get('/admins/add', auth.isInRole('Admin'), controllers.users.addAdminGet)
  app.post('/admins/add', auth.isInRole('Admin'), controllers.users.addAdminPost)
  app.get('/admins/all', auth.isInRole('Admin'), controllers.users.all)
  app.get('/profile/:username', auth.isAuthenticated, controllers.users.profile)
  app.get('/edit/:id', auth.isInRole('Admin'), controllers.tweet.editGet)
  app.post('/edit/:id', auth.isInRole('Admin'), controllers.tweet.editPost)
  app.get('/delete/:id', auth.isInRole('Admin'), controllers.tweet.deleteGet)
  app.post('/delete/:id', auth.isInRole('Admin'), controllers.tweet.deletePost)

  app.all('*', (req, res) => {
    res.status(404)
    res.send('404 Not Found!')
    res.end()
  })
}
