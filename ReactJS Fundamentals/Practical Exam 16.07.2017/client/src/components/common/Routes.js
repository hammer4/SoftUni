import React from 'react'
import {Switch, Route} from 'react-router-dom'
import RegisterPage from '../users/RegisterPage'
import LoginPage from '../users/LoginPage'
import LogoutPage from '../users/LogoutPage'
import PrivateRoute from './PrivateRoute'
import ListCarsPage from '../cars/ListCarsPage'
import CreateCarPage from '../cars/CreateCarPage'
import CarDetailsPage from '../cars/CarDetailsPage'
import ProfilePage from '../users/ProfilePage'

const Routes = () => (
  <Switch>
    <Route path='/' exact component={ListCarsPage} />
    <Route path='/users/register' component={RegisterPage} />
    <Route path='/users/login' exact component={LoginPage} />
    <PrivateRoute path='/users/logout' component={LogoutPage} />
    <PrivateRoute path='/cars/create' component={CreateCarPage} />
    <PrivateRoute path='/cars/details/:id' component={CarDetailsPage} />
    <PrivateRoute path='/profile/me' component={ProfilePage} />
  </Switch>
)

export default Routes
