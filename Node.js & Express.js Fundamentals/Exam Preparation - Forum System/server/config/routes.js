const controllers = require('../controllers')
const auth = require('./auth')

module.exports = (app) => {
  app.get('/', controllers.home.index)

  app.get('/users/register', controllers.users.registerGet)
  app.post('/users/register', controllers.users.registerPost)
  app.get('/users/login', controllers.users.loginGet)
  app.post('/users/login', controllers.users.loginPost)
  app.post('/users/logout', controllers.users.logout)

  app.get('/category/add', auth.isInRole('Admin'), controllers.category.addGet)
  app.post('/category/add', auth.isInRole('Admin'), controllers.category.addPost)
  app.get('/category/delete', auth.isInRole('Admin'), controllers.category.deleteGet)
  app.post('/category/delete', auth.isInRole('Admin'), controllers.category.deletePost)
  app.get('/categories', controllers.category.all)

  app.get('/admins/add', auth.isInRole('Admin'), controllers.users.addAdminGet)
  app.post('/admins/add', auth.isInRole('Admin'), controllers.users.addAdminPost)
  app.get('/admins/all', auth.isInRole('Admin'), controllers.users.all)

  app.get('/add', auth.isAuthenticated, controllers.thread.addGet)
  app.post('/add', auth.isAuthenticated, controllers.thread.addPost)
  app.get('/post/edit/:id', auth.isInRole('Admin'), controllers.thread.editGet)
  app.post('/post/edit/:id', auth.isInRole('Admin'), controllers.thread.editPost)
  app.get('/post/delete/:id', auth.isInRole('Admin'), controllers.thread.deleteGet)
  app.post('/post/delete/:id', auth.isInRole('Admin'), controllers.thread.deletePost)
  app.get('/post/:id/:name', controllers.thread.viewThreadGet)
  app.post('/post/:id/:name', auth.isAuthenticated, controllers.answer.addPost)
  app.get('/answer/edit/:id', auth.isInRole('Admin'), controllers.answer.editGet)
  app.post('/answer/edit/:id', auth.isInRole('Admin'), controllers.answer.editPost)
  app.get('/answer/delete/:id', auth.isInRole('Admin'), controllers.answer.deleteGet)
  app.post('/answer/delete/:id', auth.isInRole('Admin'), controllers.answer.deletePost)
  app.get('/profile/:username', auth.isAuthenticated, controllers.users.profile)
  app.get('/list', controllers.thread.all)
  app.get('/list/:id', controllers.category.getThreads)
  app.post('/block/:id', auth.isInRole('Admin'), controllers.users.block)
  app.post('/unblock/:id', auth.isInRole('Admin'), controllers.users.unblock)

  app.post('/like/:id', auth.isAuthenticated, controllers.thread.like)
  app.post('/dislike/:id', auth.isAuthenticated, controllers.thread.dislike)

  app.all('*', (req, res) => {
    res.status(404)
    res.send('404 Not Found!')
    res.end()
  })
}
