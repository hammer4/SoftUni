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
  app.get('/users/me', controllers.users.profile)

  app.get('/cars/add', auth.isInRole('Admin'), controllers.cars.addGet)
  app.post('/cars/add', auth.isInRole('Admin'), controllers.cars.addPost)
  app.get('/cars/all', controllers.cars.all)
  app.post('/cars/rent/:id', auth.isAuthenticated, controllers.cars.rent)
  app.get('/cars/edit/:id', auth.isInRole('Admin'), controllers.cars.editGet)
  app.post('/cars/edit/:id', auth.isInRole('Admin'), controllers.cars.editPost)

  app.all('*', (req, res) => {
    res.status(404)
    res.send('404 Not Found!')
    res.end()
  })
}
