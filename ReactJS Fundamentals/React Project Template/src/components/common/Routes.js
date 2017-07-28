import React from 'react'
import {Switch, Route} from 'react-router-dom'
import ListHotelsPage from '../hotels/ListHotelsPage'
import RegisterPage from '../users/RegisterPage'
import LoginPage from '../users/LoginPage'
import LogoutPage from '../users/LogoutPage'
import PrivateRoute from './PrivateRoute'

const Routes = () => (
  <Switch>
    <Route path='/' exact component={ListHotelsPage} />
    <Route path='/users/register' component={RegisterPage} />
    <Route path='/users/login' exact component={LoginPage} />
    <PrivateRoute path='/users/logout' component={LogoutPage} />
  </Switch>
)

export default Routes
