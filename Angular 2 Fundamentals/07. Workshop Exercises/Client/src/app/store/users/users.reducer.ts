import { initialState } from './users.state';

import { 
  USER_REGISTERED,
  USER_LOGGED_IN,
  USER_LOGOUT
} from './users.actions'

function userRegistration( state, action) {
  const result = action.result;
  return Object.assign({}, state,{
    userRegistered: result.success
  })
}

function userLogin(state, action) {
  const result = action.result;
  return Object.assign({}, state, {
    userAuthenticated: result.success,
    token: result.token,
    username: result.user ? result.user.name : null
  });
}

function logout(state, action) {
  return Object.assign({}, state, {
    userAuthenticated: false,
    token: null,
    username: null
  });
}

export function usersReducer(state = initialState, action) {
  switch (action.type){
    case USER_REGISTERED:
      return userRegistration(state, action);
    case USER_LOGGED_IN:
      return userLogin(state, action);
    case USER_LOGOUT:
      return logout(state, action);
    default:
       return state;
  }
}