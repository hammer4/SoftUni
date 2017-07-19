import React from 'react'
import {Redirect, Route} from 'react-router-dom'
import Auth from '../users/Auth'

const PrivateRoute = ({component: Component, ...rest}) => (
  <Route {...rest} render={props => (
      Auth.isUserAuthenticated() ? (
        <Component {...props} />
      ) : (
        <Redirect to={{
          pathname: '/users/login',
          state: { from: props.location }
        }} />
      )
    )
  } />
)

export default PrivateRoute
