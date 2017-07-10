import React from 'react'
import {Route, Switch} from 'react-router-dom'
import AuthorDetailsPage from './components/authors/AuthorDetailsPage'
import AllAuthors from './components/authors/AllAuthors'
import BookDetailsPage from './components/books/BookDetailsPage'
import AllBooks from './components/books/AllBooks'
import HomePage from './components/HomePage'
import PrivateRoute from './components/common/PrivateRoute'
import LogoutPage from './components/users/LogoutPage'
import RegisterPage from './components/users/RegisterPage'
import LoginPage from './components/users/LoginPage'
import CreateAuthorPage from './components/authors/CreateAuthorPage'
import CreateBookPage from './components/books/CreateBookPage'
import EditAuthorPage from './components/authors/EditAuthorPage'
import EditBookPage from './components/books/EditBookPage'
import EditCommentPage from './components/books/EditCommentPage'

const Routes = () => (
  <Switch>
    <Route path='/books/all' component={AllBooks} />
    <PrivateRoute path='/books/add' component={CreateBookPage} />
    <PrivateRoute path='/books/edit/:id' component={EditBookPage} />
    <Route path='/books/:id' component={BookDetailsPage} />
    <PrivateRoute path='/authors/add' component={CreateAuthorPage} />
    <Route path='/authors/all' component={AllAuthors} />
    <PrivateRoute path='/authors/add' component={CreateAuthorPage} />
    <PrivateRoute path='/authors/edit/:id' component={EditAuthorPage} />
    <Route path='/authors/:id' component={AuthorDetailsPage} />
    <PrivateRoute path='/comments/edit/:id' component={EditCommentPage} />
    <Route path='/' exact component={HomePage} />
    <Route path='/users/register' component={RegisterPage} />
    <Route path='/users/login' component={LoginPage} />
    <PrivateRoute path='/users/logout' component={LogoutPage} />
  </Switch>
)

export default Routes
