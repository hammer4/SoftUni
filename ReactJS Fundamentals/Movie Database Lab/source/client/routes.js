import React from 'react';
import { Route } from 'react-router';
import authorize from './utilities/Authorize'

import App from './components/App';
import Home from './components/Home';
import MovieAdd from './components/MovieAdd';
import UserProfile from './components/UserProfile';
import UserRegister from './components/UserRegister'
import UserLogin from './components/UserLogin'

export default (
    <Route component={ App }>
        <Route path="/" component={ Home } />
        <Route path="/movie/Add" component={ authorize(MovieAdd) } />
        <Route path="/user/profile/:userId" component={ authorize(UserProfile) } />
        <Route path='/user/register' component={UserRegister} />
        <Route path='/user/login' component={UserLogin} />
    </Route>
);