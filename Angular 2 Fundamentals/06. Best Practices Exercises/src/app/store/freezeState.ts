function deepFreeze(obj) {
  Object.freeze(obj);
  Object.getOwnPropertyNames(obj).forEach(prop => {
    if (obj.hasOwnProperty(prop) && obj[prop] !== null
    && (typeof obj[prop] === 'object') && !Object.isFrozen(obj[prop])) {
      deepFreeze(obj[prop]);
    }
  })
  return obj;
}
export function freezeState(store) {
  return (next) => (action) => {
    const state = store.getState();
    deepFreeze(state);
    return next(action);
  }
}
