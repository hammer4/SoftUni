import {IMessage, initialState} from './core.state';
import { ROUTES_CHANGE} from './core.actions';

function handleMessage (state, action) {
  const result = action.result;
  if (result) {
    const message = result.message;
    const errors = result.errors;
    let newState = Object.assign({}, state);

    if (errors) {
      const currentErrors: IMessage[] = [];
      for (const key of Object.keys(errors)) {
        currentErrors.push({
          name: key,
          message: errors[key],
          displayed: false
        });
      }

      newState = Object.assign(newState, {
        errors: currentErrors
      });
    }

    if (message) {
      newState = Object.assign(newState, {
        message: message
      });
    }
    return newState;
  }
  return state;

}

function routeChange(state, action) {
  return Object.assign({}, state, {
    message: null,
    errors : []
  });
}

export function coreReducer(state = initialState, action) {
  if (action.type === ROUTES_CHANGE) {
    return routeChange(state, action);
  } else {
    return handleMessage(state, action);
  }
}
