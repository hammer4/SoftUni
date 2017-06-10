const controllers = require('../controllers')
const auth = require('./auth')

module.exports = (app) => {
  app.get('/', controllers.home.index)
  app.get('/about', auth.isAuthenticated, controllers.home.about)

  app.get('/users/register', controllers.users.registerGet)
  app.post('/users/register', controllers.users.registerPost)
  app.get('/users/login', controllers.users.loginGet)
  app.post('/users/login', controllers.users.loginPost)
  app.post('/users/logout', controllers.users.logout)

  app.get('/article/add', auth.isAuthenticated, controllers.article.addGet)
  app.post('/article/add', auth.isAuthenticated, controllers.article.addPost)
  app.get('/article/list', controllers.article.list)
  app.get('/article/details/:id', auth.isAuthenticated, controllers.article.details)
  app.get('/article/edit/:id', auth.isAuthenticated, controllers.article.editGet);
  app.post('/article/edit/:id', auth.isAuthenticated, controllers.article.editPost);
  app.get('/article/delete/:id', auth.isInRole('Admin'), controllers.article.deleteGet);
  app.post('/article/delete/:id', auth.isInRole('Admin'), controllers.article.deletePost);

  app.post('/article/comment/:id', auth.isAuthenticated, controllers.comment.addPost);
  app.get('/comment/edit/:id', auth.isAuthenticated, controllers.comment.editGet);
  app.post('/comment/edit/:id', auth.isAuthenticated, controllers.comment.editPost);
  app.get('/comment/delete/:id', auth.isInRole('Admin'), controllers.comment.deleteGet);
  app.post('/comment/delete/:id', auth.isInRole('Admin'), controllers.comment.deletePost);

  app.get('/users/profile', auth.isAuthenticated, controllers.users.profile);


  app.all('*', (req, res) => {
    res.status(404)
    res.send('404 Not Found!')
    res.end()
  })
}
