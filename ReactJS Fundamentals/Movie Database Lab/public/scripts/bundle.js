(function e(t,n,r){function s(o,u){if(!n[o]){if(!t[o]){var a=typeof require=="function"&&require;if(!u&&a)return a(o,!0);if(i)return i(o,!0);var f=new Error("Cannot find module '"+o+"'");throw f.code="MODULE_NOT_FOUND",f}var l=n[o]={exports:{}};t[o][0].call(l.exports,function(e){var n=t[o][1][e];return s(n?n:e)},l,l.exports,e,t,n,r)}return n[o].exports}var i=typeof require=="function"&&require;for(var o=0;o<r.length;o++)s(r[o]);return s})({1:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
  value: true
});
exports['default'] = makeAction;

var _functions = require('../functions');

var fn = _interopRequireWildcard(_functions);

var _AltUtils = require('../utils/AltUtils');

var utils = _interopRequireWildcard(_AltUtils);

var _isPromise = require('is-promise');

var _isPromise2 = _interopRequireDefault(_isPromise);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { 'default': obj }; }

function _interopRequireWildcard(obj) { if (obj && obj.__esModule) { return obj; } else { var newObj = {}; if (obj != null) { for (var key in obj) { if (Object.prototype.hasOwnProperty.call(obj, key)) newObj[key] = obj[key]; } } newObj['default'] = obj; return newObj; } }

function makeAction(alt, namespace, name, implementation, obj) {
  var id = utils.uid(alt._actionsRegistry, String(namespace) + '.' + String(name));
  alt._actionsRegistry[id] = 1;

  var data = { id: id, namespace: namespace, name: name };

  var dispatch = function dispatch(payload) {
    return alt.dispatch(id, payload, data);
  };

  // the action itself
  var action = function action() {
    for (var _len = arguments.length, args = Array(_len), _key = 0; _key < _len; _key++) {
      args[_key] = arguments[_key];
    }

    var invocationResult = implementation.apply(obj, args);
    var actionResult = invocationResult;

    // async functions that return promises should not be dispatched
    if (invocationResult !== undefined && !(0, _isPromise2['default'])(invocationResult)) {
      if (fn.isFunction(invocationResult)) {
        // inner function result should be returned as an action result
        actionResult = invocationResult(dispatch, alt);
      } else {
        dispatch(invocationResult);
      }
    }

    if (invocationResult === undefined) {
      utils.warn('An action was called but nothing was dispatched');
    }

    return actionResult;
  };
  action.defer = function () {
    for (var _len2 = arguments.length, args = Array(_len2), _key2 = 0; _key2 < _len2; _key2++) {
      args[_key2] = arguments[_key2];
    }

    return setTimeout(function () {
      return action.apply(null, args);
    });
  };
  action.id = id;
  action.data = data;

  // ensure each reference is unique in the namespace
  var container = alt.actions[namespace];
  var namespaceId = utils.uid(container, name);
  container[namespaceId] = action;

  // generate a constant
  var constant = utils.formatAsConstant(namespaceId);
  container[constant] = id;

  return action;
}
module.exports = exports['default'];
},{"../functions":2,"../utils/AltUtils":7,"is-promise":29}],2:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
  value: true
});
exports.isMutableObject = isMutableObject;
exports.eachObject = eachObject;
exports.assign = assign;
var isFunction = exports.isFunction = function isFunction(x) {
  return typeof x === 'function';
};

function isMutableObject(target) {
  var Ctor = target.constructor;

  return !!target && Object.prototype.toString.call(target) === '[object Object]' && isFunction(Ctor) && !Object.isFrozen(target) && (Ctor instanceof Ctor || target.type === 'AltStore');
}

function eachObject(f, o) {
  o.forEach(function (from) {
    Object.keys(Object(from)).forEach(function (key) {
      f(key, from[key]);
    });
  });
}

function assign(target) {
  for (var _len = arguments.length, source = Array(_len > 1 ? _len - 1 : 0), _key = 1; _key < _len; _key++) {
    source[_key - 1] = arguments[_key];
  }

  eachObject(function (key, value) {
    return target[key] = value;
  }, source);
  return target;
}
},{}],3:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
  value: true
});

var _flux = require('flux');

var _StateFunctions = require('./utils/StateFunctions');

var StateFunctions = _interopRequireWildcard(_StateFunctions);

var _functions = require('./functions');

var fn = _interopRequireWildcard(_functions);

var _store = require('./store');

var store = _interopRequireWildcard(_store);

var _AltUtils = require('./utils/AltUtils');

var utils = _interopRequireWildcard(_AltUtils);

var _actions = require('./actions');

var _actions2 = _interopRequireDefault(_actions);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { 'default': obj }; }

function _interopRequireWildcard(obj) { if (obj && obj.__esModule) { return obj; } else { var newObj = {}; if (obj != null) { for (var key in obj) { if (Object.prototype.hasOwnProperty.call(obj, key)) newObj[key] = obj[key]; } } newObj['default'] = obj; return newObj; } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } } /* global window */


var Alt = function () {
  function Alt() {
    var config = arguments.length <= 0 || arguments[0] === undefined ? {} : arguments[0];

    _classCallCheck(this, Alt);

    this.config = config;
    this.serialize = config.serialize || JSON.stringify;
    this.deserialize = config.deserialize || JSON.parse;
    this.dispatcher = config.dispatcher || new _flux.Dispatcher();
    this.batchingFunction = config.batchingFunction || function (callback) {
      return callback();
    };
    this.actions = { global: {} };
    this.stores = {};
    this.storeTransforms = config.storeTransforms || [];
    this.trapAsync = false;
    this._actionsRegistry = {};
    this._initSnapshot = {};
    this._lastSnapshot = {};
  }

  Alt.prototype.dispatch = function () {
    function dispatch(action, data, details) {
      var _this = this;

      this.batchingFunction(function () {
        var id = Math.random().toString(18).substr(2, 16);

        // support straight dispatching of FSA-style actions
        if (action.hasOwnProperty('type') && action.hasOwnProperty('payload')) {
          var fsaDetails = {
            id: action.type,
            namespace: action.type,
            name: action.type
          };
          return _this.dispatcher.dispatch(utils.fsa(id, action.type, action.payload, fsaDetails));
        }

        if (action.id && action.dispatch) {
          return utils.dispatch(id, action, data, _this);
        }

        return _this.dispatcher.dispatch(utils.fsa(id, action, data, details));
      });
    }

    return dispatch;
  }();

  Alt.prototype.createUnsavedStore = function () {
    function createUnsavedStore(StoreModel) {
      var key = StoreModel.displayName || '';
      store.createStoreConfig(this.config, StoreModel);
      var Store = store.transformStore(this.storeTransforms, StoreModel);

      for (var _len = arguments.length, args = Array(_len > 1 ? _len - 1 : 0), _key = 1; _key < _len; _key++) {
        args[_key - 1] = arguments[_key];
      }

      return fn.isFunction(Store) ? store.createStoreFromClass.apply(store, [this, Store, key].concat(args)) : store.createStoreFromObject(this, Store, key);
    }

    return createUnsavedStore;
  }();

  Alt.prototype.createStore = function () {
    function createStore(StoreModel, iden) {
      var key = iden || StoreModel.displayName || StoreModel.name || '';
      store.createStoreConfig(this.config, StoreModel);
      var Store = store.transformStore(this.storeTransforms, StoreModel);

      /* istanbul ignore next */
      if (module.hot) delete this.stores[key];

      if (this.stores[key] || !key) {
        if (this.stores[key]) {
          utils.warn('A store named ' + String(key) + ' already exists, double check your store ' + 'names or pass in your own custom identifier for each store');
        } else {
          utils.warn('Store name was not specified');
        }

        key = utils.uid(this.stores, key);
      }

      for (var _len2 = arguments.length, args = Array(_len2 > 2 ? _len2 - 2 : 0), _key2 = 2; _key2 < _len2; _key2++) {
        args[_key2 - 2] = arguments[_key2];
      }

      var storeInstance = fn.isFunction(Store) ? store.createStoreFromClass.apply(store, [this, Store, key].concat(args)) : store.createStoreFromObject(this, Store, key);

      this.stores[key] = storeInstance;
      StateFunctions.saveInitialSnapshot(this, key);

      return storeInstance;
    }

    return createStore;
  }();

  Alt.prototype.generateActions = function () {
    function generateActions() {
      var actions = { name: 'global' };

      for (var _len3 = arguments.length, actionNames = Array(_len3), _key3 = 0; _key3 < _len3; _key3++) {
        actionNames[_key3] = arguments[_key3];
      }

      return this.createActions(actionNames.reduce(function (obj, action) {
        obj[action] = utils.dispatchIdentity;
        return obj;
      }, actions));
    }

    return generateActions;
  }();

  Alt.prototype.createAction = function () {
    function createAction(name, implementation, obj) {
      return (0, _actions2['default'])(this, 'global', name, implementation, obj);
    }

    return createAction;
  }();

  Alt.prototype.createActions = function () {
    function createActions(ActionsClass) {
      var _this3 = this;

      var exportObj = arguments.length <= 1 || arguments[1] === undefined ? {} : arguments[1];

      var actions = {};
      var key = utils.uid(this._actionsRegistry, ActionsClass.displayName || ActionsClass.name || 'Unknown');

      if (fn.isFunction(ActionsClass)) {
        fn.assign(actions, utils.getPrototypeChain(ActionsClass));

        var ActionsGenerator = function (_ActionsClass) {
          _inherits(ActionsGenerator, _ActionsClass);

          function ActionsGenerator() {
            _classCallCheck(this, ActionsGenerator);

            for (var _len5 = arguments.length, args = Array(_len5), _key5 = 0; _key5 < _len5; _key5++) {
              args[_key5] = arguments[_key5];
            }

            return _possibleConstructorReturn(this, _ActionsClass.call.apply(_ActionsClass, [this].concat(args)));
          }

          ActionsGenerator.prototype.generateActions = function () {
            function generateActions() {
              for (var _len6 = arguments.length, actionNames = Array(_len6), _key6 = 0; _key6 < _len6; _key6++) {
                actionNames[_key6] = arguments[_key6];
              }

              actionNames.forEach(function (actionName) {
                actions[actionName] = utils.dispatchIdentity;
              });
            }

            return generateActions;
          }();

          return ActionsGenerator;
        }(ActionsClass);

        for (var _len4 = arguments.length, argsForConstructor = Array(_len4 > 2 ? _len4 - 2 : 0), _key4 = 2; _key4 < _len4; _key4++) {
          argsForConstructor[_key4 - 2] = arguments[_key4];
        }

        fn.assign(actions, new (Function.prototype.bind.apply(ActionsGenerator, [null].concat(argsForConstructor)))());
      } else {
        fn.assign(actions, ActionsClass);
      }

      this.actions[key] = this.actions[key] || {};

      fn.eachObject(function (actionName, action) {
        if (!fn.isFunction(action)) {
          exportObj[actionName] = action;
          return;
        }

        // create the action
        exportObj[actionName] = (0, _actions2['default'])(_this3, key, actionName, action, exportObj);

        // generate a constant
        var constant = utils.formatAsConstant(actionName);
        exportObj[constant] = exportObj[actionName].id;
      }, [actions]);

      return exportObj;
    }

    return createActions;
  }();

  Alt.prototype.takeSnapshot = function () {
    function takeSnapshot() {
      for (var _len7 = arguments.length, storeNames = Array(_len7), _key7 = 0; _key7 < _len7; _key7++) {
        storeNames[_key7] = arguments[_key7];
      }

      var state = StateFunctions.snapshot(this, storeNames);
      fn.assign(this._lastSnapshot, state);
      return this.serialize(state);
    }

    return takeSnapshot;
  }();

  Alt.prototype.rollback = function () {
    function rollback() {
      StateFunctions.setAppState(this, this.serialize(this._lastSnapshot), function (storeInst) {
        storeInst.lifecycle('rollback');
        storeInst.emitChange();
      });
    }

    return rollback;
  }();

  Alt.prototype.recycle = function () {
    function recycle() {
      for (var _len8 = arguments.length, storeNames = Array(_len8), _key8 = 0; _key8 < _len8; _key8++) {
        storeNames[_key8] = arguments[_key8];
      }

      var initialSnapshot = storeNames.length ? StateFunctions.filterSnapshots(this, this._initSnapshot, storeNames) : this._initSnapshot;

      StateFunctions.setAppState(this, this.serialize(initialSnapshot), function (storeInst) {
        storeInst.lifecycle('init');
        storeInst.emitChange();
      });
    }

    return recycle;
  }();

  Alt.prototype.flush = function () {
    function flush() {
      var state = this.serialize(StateFunctions.snapshot(this));
      this.recycle();
      return state;
    }

    return flush;
  }();

  Alt.prototype.bootstrap = function () {
    function bootstrap(data) {
      StateFunctions.setAppState(this, data, function (storeInst, state) {
        storeInst.lifecycle('bootstrap', state);
        storeInst.emitChange();
      });
    }

    return bootstrap;
  }();

  Alt.prototype.prepare = function () {
    function prepare(storeInst, payload) {
      var data = {};
      if (!storeInst.displayName) {
        throw new ReferenceError('Store provided does not have a name');
      }
      data[storeInst.displayName] = payload;
      return this.serialize(data);
    }

    return prepare;
  }();

  // Instance type methods for injecting alt into your application as context

  Alt.prototype.addActions = function () {
    function addActions(name, ActionsClass) {
      for (var _len9 = arguments.length, args = Array(_len9 > 2 ? _len9 - 2 : 0), _key9 = 2; _key9 < _len9; _key9++) {
        args[_key9 - 2] = arguments[_key9];
      }

      this.actions[name] = Array.isArray(ActionsClass) ? this.generateActions.apply(this, ActionsClass) : this.createActions.apply(this, [ActionsClass].concat(args));
    }

    return addActions;
  }();

  Alt.prototype.addStore = function () {
    function addStore(name, StoreModel) {
      for (var _len10 = arguments.length, args = Array(_len10 > 2 ? _len10 - 2 : 0), _key10 = 2; _key10 < _len10; _key10++) {
        args[_key10 - 2] = arguments[_key10];
      }

      this.createStore.apply(this, [StoreModel, name].concat(args));
    }

    return addStore;
  }();

  Alt.prototype.getActions = function () {
    function getActions(name) {
      return this.actions[name];
    }

    return getActions;
  }();

  Alt.prototype.getStore = function () {
    function getStore(name) {
      return this.stores[name];
    }

    return getStore;
  }();

  Alt.debug = function () {
    function debug(name, alt, win) {
      var key = 'alt.js.org';
      var context = win;
      if (!context && typeof window !== 'undefined') {
        context = window;
      }
      if (typeof context !== 'undefined') {
        context[key] = context[key] || [];
        context[key].push({ name: name, alt: alt });
      }
      return alt;
    }

    return debug;
  }();

  return Alt;
}();

exports['default'] = Alt;
module.exports = exports['default'];
},{"./actions":1,"./functions":2,"./store":6,"./utils/AltUtils":7,"./utils/StateFunctions":8,"flux":13}],4:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
  value: true
});

var _functions = require('../functions');

var fn = _interopRequireWildcard(_functions);

var _transmitter = require('transmitter');

var _transmitter2 = _interopRequireDefault(_transmitter);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { 'default': obj }; }

function _interopRequireWildcard(obj) { if (obj && obj.__esModule) { return obj; } else { var newObj = {}; if (obj != null) { for (var key in obj) { if (Object.prototype.hasOwnProperty.call(obj, key)) newObj[key] = obj[key]; } } newObj['default'] = obj; return newObj; } }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var AltStore = function () {
  function AltStore(alt, model, state, StoreModel) {
    var _this = this;

    _classCallCheck(this, AltStore);

    var lifecycleEvents = model.lifecycleEvents;
    this.transmitter = (0, _transmitter2['default'])();
    this.lifecycle = function (event, x) {
      if (lifecycleEvents[event]) lifecycleEvents[event].publish(x);
    };
    this.state = state;

    this.alt = alt;
    this.preventDefault = false;
    this.displayName = model.displayName;
    this.boundListeners = model.boundListeners;
    this.StoreModel = StoreModel;
    this.reduce = model.reduce || function (x) {
      return x;
    };
    this.subscriptions = [];

    var output = model.output || function (x) {
      return x;
    };

    this.emitChange = function () {
      return _this.transmitter.publish(output(_this.state));
    };

    var handleDispatch = function handleDispatch(f, payload) {
      try {
        return f();
      } catch (e) {
        if (model.handlesOwnErrors) {
          _this.lifecycle('error', {
            error: e,
            payload: payload,
            state: _this.state
          });
          return false;
        }

        throw e;
      }
    };

    fn.assign(this, model.publicMethods);

    // Register dispatcher
    this.dispatchToken = alt.dispatcher.register(function (payload) {
      _this.preventDefault = false;

      _this.lifecycle('beforeEach', {
        payload: payload,
        state: _this.state
      });

      var actionHandlers = model.actionListeners[payload.action];

      if (actionHandlers || model.otherwise) {
        var result = void 0;

        if (actionHandlers) {
          result = handleDispatch(function () {
            return actionHandlers.filter(Boolean).every(function (handler) {
              return handler.call(model, payload.data, payload.action) !== false;
            });
          }, payload);
        } else {
          result = handleDispatch(function () {
            return model.otherwise(payload.data, payload.action);
          }, payload);
        }

        if (result !== false && !_this.preventDefault) _this.emitChange();
      }

      if (model.reduce) {
        handleDispatch(function () {
          var value = model.reduce(_this.state, payload);
          if (value !== undefined) _this.state = value;
        }, payload);
        if (!_this.preventDefault) _this.emitChange();
      }

      _this.lifecycle('afterEach', {
        payload: payload,
        state: _this.state
      });
    });

    this.lifecycle('init');
  }

  AltStore.prototype.listen = function () {
    function listen(cb) {
      var _this2 = this;

      if (!fn.isFunction(cb)) throw new TypeError('listen expects a function');

      var _transmitter$subscrib = this.transmitter.subscribe(cb);

      var dispose = _transmitter$subscrib.dispose;

      this.subscriptions.push({ cb: cb, dispose: dispose });
      return function () {
        _this2.lifecycle('unlisten');
        dispose();
      };
    }

    return listen;
  }();

  AltStore.prototype.unlisten = function () {
    function unlisten(cb) {
      this.lifecycle('unlisten');
      this.subscriptions.filter(function (subscription) {
        return subscription.cb === cb;
      }).forEach(function (subscription) {
        return subscription.dispose();
      });
    }

    return unlisten;
  }();

  AltStore.prototype.getState = function () {
    function getState() {
      return this.StoreModel.config.getState.call(this, this.state);
    }

    return getState;
  }();

  return AltStore;
}();

exports['default'] = AltStore;
module.exports = exports['default'];
},{"../functions":2,"transmitter":31}],5:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
  value: true
});

var _transmitter = require('transmitter');

var _transmitter2 = _interopRequireDefault(_transmitter);

var _functions = require('../functions');

var fn = _interopRequireWildcard(_functions);

function _interopRequireWildcard(obj) { if (obj && obj.__esModule) { return obj; } else { var newObj = {}; if (obj != null) { for (var key in obj) { if (Object.prototype.hasOwnProperty.call(obj, key)) newObj[key] = obj[key]; } } newObj['default'] = obj; return newObj; } }

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { 'default': obj }; }

var StoreMixin = {
  waitFor: function () {
    function waitFor() {
      for (var _len = arguments.length, sources = Array(_len), _key = 0; _key < _len; _key++) {
        sources[_key] = arguments[_key];
      }

      if (!sources.length) {
        throw new ReferenceError('Dispatch tokens not provided');
      }

      var sourcesArray = sources;
      if (sources.length === 1) {
        sourcesArray = Array.isArray(sources[0]) ? sources[0] : sources;
      }

      var tokens = sourcesArray.map(function (source) {
        return source.dispatchToken || source;
      });

      this.dispatcher.waitFor(tokens);
    }

    return waitFor;
  }(),
  exportAsync: function () {
    function exportAsync(asyncMethods) {
      this.registerAsync(asyncMethods);
    }

    return exportAsync;
  }(),
  registerAsync: function () {
    function registerAsync(asyncDef) {
      var _this = this;

      var loadCounter = 0;

      var asyncMethods = fn.isFunction(asyncDef) ? asyncDef(this.alt) : asyncDef;

      var toExport = Object.keys(asyncMethods).reduce(function (publicMethods, methodName) {
        var desc = asyncMethods[methodName];
        var spec = fn.isFunction(desc) ? desc(_this) : desc;

        var validHandlers = ['success', 'error', 'loading'];
        validHandlers.forEach(function (handler) {
          if (spec[handler] && !spec[handler].id) {
            throw new Error(String(handler) + ' handler must be an action function');
          }
        });

        publicMethods[methodName] = function () {
          for (var _len2 = arguments.length, args = Array(_len2), _key2 = 0; _key2 < _len2; _key2++) {
            args[_key2] = arguments[_key2];
          }

          var state = _this.getInstance().getState();
          var value = spec.local && spec.local.apply(spec, [state].concat(args));
          var shouldFetch = spec.shouldFetch ? spec.shouldFetch.apply(spec, [state].concat(args))
          /*eslint-disable*/
          : value == null;
          /*eslint-enable*/
          var intercept = spec.interceptResponse || function (x) {
            return x;
          };

          var makeActionHandler = function () {
            function makeActionHandler(action, isError) {
              return function (x) {
                var fire = function () {
                  function fire() {
                    loadCounter -= 1;
                    action(intercept(x, action, args));
                    if (isError) throw x;
                    return x;
                  }

                  return fire;
                }();
                return _this.alt.trapAsync ? function () {
                  return fire();
                } : fire();
              };
            }

            return makeActionHandler;
          }();

          // if we don't have it in cache then fetch it
          if (shouldFetch) {
            loadCounter += 1;
            /* istanbul ignore else */
            if (spec.loading) spec.loading(intercept(null, spec.loading, args));
            return spec.remote.apply(spec, [state].concat(args)).then(makeActionHandler(spec.success), makeActionHandler(spec.error, 1));
          }

          // otherwise emit the change now
          _this.emitChange();
          return value;
        };

        return publicMethods;
      }, {});

      this.exportPublicMethods(toExport);
      this.exportPublicMethods({
        isLoading: function () {
          function isLoading() {
            return loadCounter > 0;
          }

          return isLoading;
        }()
      });
    }

    return registerAsync;
  }(),
  exportPublicMethods: function () {
    function exportPublicMethods(methods) {
      var _this2 = this;

      fn.eachObject(function (methodName, value) {
        if (!fn.isFunction(value)) {
          throw new TypeError('exportPublicMethods expects a function');
        }

        _this2.publicMethods[methodName] = value;
      }, [methods]);
    }

    return exportPublicMethods;
  }(),
  emitChange: function () {
    function emitChange() {
      this.getInstance().emitChange();
    }

    return emitChange;
  }(),
  on: function () {
    function on(lifecycleEvent, handler) {
      if (lifecycleEvent === 'error') this.handlesOwnErrors = true;
      var bus = this.lifecycleEvents[lifecycleEvent] || (0, _transmitter2['default'])();
      this.lifecycleEvents[lifecycleEvent] = bus;
      return bus.subscribe(handler.bind(this));
    }

    return on;
  }(),
  bindAction: function () {
    function bindAction(symbol, handler) {
      if (!symbol) {
        throw new ReferenceError('Invalid action reference passed in');
      }
      if (!fn.isFunction(handler)) {
        throw new TypeError('bindAction expects a function');
      }

      // You can pass in the constant or the function itself
      var key = symbol.id ? symbol.id : symbol;
      this.actionListeners[key] = this.actionListeners[key] || [];
      this.actionListeners[key].push(handler.bind(this));
      this.boundListeners.push(key);
    }

    return bindAction;
  }(),
  bindActions: function () {
    function bindActions(actions) {
      var _this3 = this;

      fn.eachObject(function (action, symbol) {
        var matchFirstCharacter = /./;
        var assumedEventHandler = action.replace(matchFirstCharacter, function (x) {
          return 'on' + String(x[0].toUpperCase());
        });

        if (_this3[action] && _this3[assumedEventHandler]) {
          // If you have both action and onAction
          throw new ReferenceError('You have multiple action handlers bound to an action: ' + (String(action) + ' and ' + String(assumedEventHandler)));
        }

        var handler = _this3[action] || _this3[assumedEventHandler];
        if (handler) {
          _this3.bindAction(symbol, handler);
        }
      }, [actions]);
    }

    return bindActions;
  }(),
  bindListeners: function () {
    function bindListeners(obj) {
      var _this4 = this;

      fn.eachObject(function (methodName, symbol) {
        var listener = _this4[methodName];

        if (!listener) {
          throw new ReferenceError(String(methodName) + ' defined but does not exist in ' + String(_this4.displayName));
        }

        if (Array.isArray(symbol)) {
          symbol.forEach(function (action) {
            _this4.bindAction(action, listener);
          });
        } else {
          _this4.bindAction(symbol, listener);
        }
      }, [obj]);
    }

    return bindListeners;
  }()
};

exports['default'] = StoreMixin;
module.exports = exports['default'];
},{"../functions":2,"transmitter":31}],6:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
  value: true
});
exports.createStoreConfig = createStoreConfig;
exports.transformStore = transformStore;
exports.createStoreFromObject = createStoreFromObject;
exports.createStoreFromClass = createStoreFromClass;

var _AltUtils = require('../utils/AltUtils');

var utils = _interopRequireWildcard(_AltUtils);

var _functions = require('../functions');

var fn = _interopRequireWildcard(_functions);

var _AltStore = require('./AltStore');

var _AltStore2 = _interopRequireDefault(_AltStore);

var _StoreMixin = require('./StoreMixin');

var _StoreMixin2 = _interopRequireDefault(_StoreMixin);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { 'default': obj }; }

function _interopRequireWildcard(obj) { if (obj && obj.__esModule) { return obj; } else { var newObj = {}; if (obj != null) { for (var key in obj) { if (Object.prototype.hasOwnProperty.call(obj, key)) newObj[key] = obj[key]; } } newObj['default'] = obj; return newObj; } }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

function doSetState(store, storeInstance, state) {
  if (!state) {
    return;
  }

  var config = storeInstance.StoreModel.config;


  var nextState = fn.isFunction(state) ? state(storeInstance.state) : state;

  storeInstance.state = config.setState.call(store, storeInstance.state, nextState);

  if (!store.alt.dispatcher.isDispatching()) {
    store.emitChange();
  }
}

function createPrototype(proto, alt, key, extras) {
  return fn.assign(proto, _StoreMixin2['default'], {
    displayName: key,
    alt: alt,
    dispatcher: alt.dispatcher,
    preventDefault: function () {
      function preventDefault() {
        this.getInstance().preventDefault = true;
      }

      return preventDefault;
    }(),

    boundListeners: [],
    lifecycleEvents: {},
    actionListeners: {},
    publicMethods: {},
    handlesOwnErrors: false
  }, extras);
}

function createStoreConfig(globalConfig, StoreModel) {
  StoreModel.config = fn.assign({
    getState: function () {
      function getState(state) {
        if (Array.isArray(state)) {
          return state.slice();
        } else if (fn.isMutableObject(state)) {
          return fn.assign({}, state);
        }

        return state;
      }

      return getState;
    }(),
    setState: function () {
      function setState(currentState, nextState) {
        if (fn.isMutableObject(nextState)) {
          return fn.assign(currentState, nextState);
        }
        return nextState;
      }

      return setState;
    }()
  }, globalConfig, StoreModel.config);
}

function transformStore(transforms, StoreModel) {
  return transforms.reduce(function (Store, transform) {
    return transform(Store);
  }, StoreModel);
}

function createStoreFromObject(alt, StoreModel, key) {
  var storeInstance = void 0;

  var StoreProto = createPrototype({}, alt, key, fn.assign({
    getInstance: function () {
      function getInstance() {
        return storeInstance;
      }

      return getInstance;
    }(),
    setState: function () {
      function setState(nextState) {
        doSetState(this, storeInstance, nextState);
      }

      return setState;
    }()
  }, StoreModel));

  // bind the store listeners
  /* istanbul ignore else */
  if (StoreProto.bindListeners) {
    _StoreMixin2['default'].bindListeners.call(StoreProto, StoreProto.bindListeners);
  }
  /* istanbul ignore else */
  if (StoreProto.observe) {
    _StoreMixin2['default'].bindListeners.call(StoreProto, StoreProto.observe(alt));
  }

  // bind the lifecycle events
  /* istanbul ignore else */
  if (StoreProto.lifecycle) {
    fn.eachObject(function (eventName, event) {
      _StoreMixin2['default'].on.call(StoreProto, eventName, event);
    }, [StoreProto.lifecycle]);
  }

  // create the instance and fn.assign the public methods to the instance
  storeInstance = fn.assign(new _AltStore2['default'](alt, StoreProto, StoreProto.state !== undefined ? StoreProto.state : {}, StoreModel), StoreProto.publicMethods, {
    displayName: key,
    config: StoreModel.config
  });

  return storeInstance;
}

function createStoreFromClass(alt, StoreModel, key) {
  var storeInstance = void 0;
  var config = StoreModel.config;

  // Creating a class here so we don't overload the provided store's
  // prototype with the mixin behaviour and I'm extending from StoreModel
  // so we can inherit any extensions from the provided store.

  var Store = function (_StoreModel) {
    _inherits(Store, _StoreModel);

    function Store() {
      _classCallCheck(this, Store);

      for (var _len2 = arguments.length, args = Array(_len2), _key2 = 0; _key2 < _len2; _key2++) {
        args[_key2] = arguments[_key2];
      }

      return _possibleConstructorReturn(this, _StoreModel.call.apply(_StoreModel, [this].concat(args)));
    }

    return Store;
  }(StoreModel);

  createPrototype(Store.prototype, alt, key, {
    type: 'AltStore',
    getInstance: function () {
      function getInstance() {
        return storeInstance;
      }

      return getInstance;
    }(),
    setState: function () {
      function setState(nextState) {
        doSetState(this, storeInstance, nextState);
      }

      return setState;
    }()
  });

  for (var _len = arguments.length, argsForClass = Array(_len > 3 ? _len - 3 : 0), _key = 3; _key < _len; _key++) {
    argsForClass[_key - 3] = arguments[_key];
  }

  var store = new (Function.prototype.bind.apply(Store, [null].concat(argsForClass)))();

  /* istanbul ignore next */
  if (config.bindListeners) store.bindListeners(config.bindListeners);
  /* istanbul ignore next */
  if (config.datasource) store.registerAsync(config.datasource);

  storeInstance = fn.assign(new _AltStore2['default'](alt, store, store.state !== undefined ? store.state : store, StoreModel), utils.getInternalMethods(StoreModel), config.publicMethods, { displayName: key });

  return storeInstance;
}
},{"../functions":2,"../utils/AltUtils":7,"./AltStore":4,"./StoreMixin":5}],7:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
  value: true
});

var _extends = Object.assign || function (target) { for (var i = 1; i < arguments.length; i++) { var source = arguments[i]; for (var key in source) { if (Object.prototype.hasOwnProperty.call(source, key)) { target[key] = source[key]; } } } return target; };

exports.getInternalMethods = getInternalMethods;
exports.getPrototypeChain = getPrototypeChain;
exports.warn = warn;
exports.uid = uid;
exports.formatAsConstant = formatAsConstant;
exports.dispatchIdentity = dispatchIdentity;
exports.fsa = fsa;
exports.dispatch = dispatch;

var _functions = require('../functions');

var fn = _interopRequireWildcard(_functions);

function _interopRequireWildcard(obj) { if (obj && obj.__esModule) { return obj; } else { var newObj = {}; if (obj != null) { for (var key in obj) { if (Object.prototype.hasOwnProperty.call(obj, key)) newObj[key] = obj[key]; } } newObj['default'] = obj; return newObj; } }

/*eslint-disable*/
var builtIns = Object.getOwnPropertyNames(NoopClass);
var builtInProto = Object.getOwnPropertyNames(NoopClass.prototype);
/*eslint-enable*/

function getInternalMethods(Obj, isProto) {
  var excluded = isProto ? builtInProto : builtIns;
  var obj = isProto ? Obj.prototype : Obj;
  return Object.getOwnPropertyNames(obj).reduce(function (value, m) {
    if (excluded.indexOf(m) !== -1) {
      return value;
    }

    value[m] = obj[m];
    return value;
  }, {});
}

function getPrototypeChain(Obj) {
  var methods = arguments.length <= 1 || arguments[1] === undefined ? {} : arguments[1];

  return Obj === Function.prototype ? methods : getPrototypeChain(Object.getPrototypeOf(Obj), fn.assign(getInternalMethods(Obj, true), methods));
}

function warn(msg) {
  /* istanbul ignore else */
  /*eslint-disable*/
  if (typeof console !== 'undefined') {
    console.warn(new ReferenceError(msg));
  }
  /*eslint-enable*/
}

function uid(container, name) {
  var count = 0;
  var key = name;
  while (Object.hasOwnProperty.call(container, key)) {
    key = name + String(++count);
  }
  return key;
}

function formatAsConstant(name) {
  return name.replace(/[a-z]([A-Z])/g, function (i) {
    return String(i[0]) + '_' + String(i[1].toLowerCase());
  }).toUpperCase();
}

function dispatchIdentity(x) {
  if (x === undefined) return null;

  for (var _len = arguments.length, a = Array(_len > 1 ? _len - 1 : 0), _key = 1; _key < _len; _key++) {
    a[_key - 1] = arguments[_key];
  }

  return a.length ? [x].concat(a) : x;
}

function fsa(id, type, payload, details) {
  return {
    type: type,
    payload: payload,
    meta: _extends({
      dispatchId: id
    }, details),

    id: id,
    action: type,
    data: payload,
    details: details
  };
}

function dispatch(id, actionObj, payload, alt) {
  var data = actionObj.dispatch(payload);
  if (data === undefined) return null;

  var type = actionObj.id;
  var namespace = type;
  var name = type;
  var details = { id: type, namespace: namespace, name: name };

  var dispatchLater = function dispatchLater(x) {
    return alt.dispatch(type, x, details);
  };

  if (fn.isFunction(data)) return data(dispatchLater, alt);

  // XXX standardize this
  return alt.dispatcher.dispatch(fsa(id, type, data, details));
}

/* istanbul ignore next */
function NoopClass() {}
},{"../functions":2}],8:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
  value: true
});
exports.setAppState = setAppState;
exports.snapshot = snapshot;
exports.saveInitialSnapshot = saveInitialSnapshot;
exports.filterSnapshots = filterSnapshots;

var _functions = require('../functions');

var fn = _interopRequireWildcard(_functions);

function _interopRequireWildcard(obj) { if (obj && obj.__esModule) { return obj; } else { var newObj = {}; if (obj != null) { for (var key in obj) { if (Object.prototype.hasOwnProperty.call(obj, key)) newObj[key] = obj[key]; } } newObj['default'] = obj; return newObj; } }

function setAppState(instance, data, onStore) {
  var obj = instance.deserialize(data);
  fn.eachObject(function (key, value) {
    var store = instance.stores[key];
    if (store) {
      (function () {
        var config = store.StoreModel.config;

        var state = store.state;
        if (config.onDeserialize) obj[key] = config.onDeserialize(value) || value;
        if (fn.isMutableObject(state)) {
          fn.eachObject(function (k) {
            return delete state[k];
          }, [state]);
          fn.assign(state, obj[key]);
        } else {
          store.state = obj[key];
        }
        onStore(store, store.state);
      })();
    }
  }, [obj]);
}

function snapshot(instance) {
  var storeNames = arguments.length <= 1 || arguments[1] === undefined ? [] : arguments[1];

  var stores = storeNames.length ? storeNames : Object.keys(instance.stores);
  return stores.reduce(function (obj, storeHandle) {
    var storeName = storeHandle.displayName || storeHandle;
    var store = instance.stores[storeName];
    var config = store.StoreModel.config;

    store.lifecycle('snapshot');
    var customSnapshot = config.onSerialize && config.onSerialize(store.state);
    obj[storeName] = customSnapshot ? customSnapshot : store.getState();
    return obj;
  }, {});
}

function saveInitialSnapshot(instance, key) {
  var state = instance.deserialize(instance.serialize(instance.stores[key].state));
  instance._initSnapshot[key] = state;
  instance._lastSnapshot[key] = state;
}

function filterSnapshots(instance, state, stores) {
  return stores.reduce(function (obj, store) {
    var storeName = store.displayName || store;
    if (!state[storeName]) {
      throw new ReferenceError(String(storeName) + ' is not a valid store');
    }
    obj[storeName] = state[storeName];
    return obj;
  }, {});
}
},{"../functions":2}],9:[function(require,module,exports){
var pSlice = Array.prototype.slice;
var objectKeys = require('./lib/keys.js');
var isArguments = require('./lib/is_arguments.js');

var deepEqual = module.exports = function (actual, expected, opts) {
  if (!opts) opts = {};
  // 7.1. All identical values are equivalent, as determined by ===.
  if (actual === expected) {
    return true;

  } else if (actual instanceof Date && expected instanceof Date) {
    return actual.getTime() === expected.getTime();

  // 7.3. Other pairs that do not both pass typeof value == 'object',
  // equivalence is determined by ==.
  } else if (!actual || !expected || typeof actual != 'object' && typeof expected != 'object') {
    return opts.strict ? actual === expected : actual == expected;

  // 7.4. For all other Object pairs, including Array objects, equivalence is
  // determined by having the same number of owned properties (as verified
  // with Object.prototype.hasOwnProperty.call), the same set of keys
  // (although not necessarily the same order), equivalent values for every
  // corresponding key, and an identical 'prototype' property. Note: this
  // accounts for both named and indexed properties on Arrays.
  } else {
    return objEquiv(actual, expected, opts);
  }
}

function isUndefinedOrNull(value) {
  return value === null || value === undefined;
}

function isBuffer (x) {
  if (!x || typeof x !== 'object' || typeof x.length !== 'number') return false;
  if (typeof x.copy !== 'function' || typeof x.slice !== 'function') {
    return false;
  }
  if (x.length > 0 && typeof x[0] !== 'number') return false;
  return true;
}

function objEquiv(a, b, opts) {
  var i, key;
  if (isUndefinedOrNull(a) || isUndefinedOrNull(b))
    return false;
  // an identical 'prototype' property.
  if (a.prototype !== b.prototype) return false;
  //~~~I've managed to break Object.keys through screwy arguments passing.
  //   Converting to array solves the problem.
  if (isArguments(a)) {
    if (!isArguments(b)) {
      return false;
    }
    a = pSlice.call(a);
    b = pSlice.call(b);
    return deepEqual(a, b, opts);
  }
  if (isBuffer(a)) {
    if (!isBuffer(b)) {
      return false;
    }
    if (a.length !== b.length) return false;
    for (i = 0; i < a.length; i++) {
      if (a[i] !== b[i]) return false;
    }
    return true;
  }
  try {
    var ka = objectKeys(a),
        kb = objectKeys(b);
  } catch (e) {//happens when one is a string literal and the other isn't
    return false;
  }
  // having the same number of owned properties (keys incorporates
  // hasOwnProperty)
  if (ka.length != kb.length)
    return false;
  //the same set of keys (although not necessarily the same order),
  ka.sort();
  kb.sort();
  //~~~cheap key test
  for (i = ka.length - 1; i >= 0; i--) {
    if (ka[i] != kb[i])
      return false;
  }
  //equivalent values for every corresponding key, and
  //~~~possibly expensive deep test
  for (i = ka.length - 1; i >= 0; i--) {
    key = ka[i];
    if (!deepEqual(a[key], b[key], opts)) return false;
  }
  return typeof a === typeof b;
}

},{"./lib/is_arguments.js":10,"./lib/keys.js":11}],10:[function(require,module,exports){
var supportsArgumentsClass = (function(){
  return Object.prototype.toString.call(arguments)
})() == '[object Arguments]';

exports = module.exports = supportsArgumentsClass ? supported : unsupported;

exports.supported = supported;
function supported(object) {
  return Object.prototype.toString.call(object) == '[object Arguments]';
};

exports.unsupported = unsupported;
function unsupported(object){
  return object &&
    typeof object == 'object' &&
    typeof object.length == 'number' &&
    Object.prototype.hasOwnProperty.call(object, 'callee') &&
    !Object.prototype.propertyIsEnumerable.call(object, 'callee') ||
    false;
};

},{}],11:[function(require,module,exports){
exports = module.exports = typeof Object.keys === 'function'
  ? Object.keys : shim;

exports.shim = shim;
function shim (obj) {
  var keys = [];
  for (var key in obj) keys.push(key);
  return keys;
}

},{}],12:[function(require,module,exports){
(function (process){
/**
 * Copyright 2013-2015, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 * @providesModule invariant
 */

"use strict";

/**
 * Use invariant() to assert state which your program assumes to be true.
 *
 * Provide sprintf-style format (only %s is supported) and arguments
 * to provide information about what broke and what you were
 * expecting.
 *
 * The invariant message will be stripped in production, but the invariant
 * will remain to ensure logic does not differ in production.
 */

var invariant = function (condition, format, a, b, c, d, e, f) {
  if (process.env.NODE_ENV !== 'production') {
    if (format === undefined) {
      throw new Error('invariant requires an error message argument');
    }
  }

  if (!condition) {
    var error;
    if (format === undefined) {
      error = new Error('Minified exception occurred; use the non-minified dev environment ' + 'for the full error message and additional helpful warnings.');
    } else {
      var args = [a, b, c, d, e, f];
      var argIndex = 0;
      error = new Error('Invariant Violation: ' + format.replace(/%s/g, function () {
        return args[argIndex++];
      }));
    }

    error.framesToPop = 1; // we don't care about invariant's own frame
    throw error;
  }
};

module.exports = invariant;
}).call(this,require('_process'))

},{"_process":30}],13:[function(require,module,exports){
/**
 * Copyright (c) 2014-2015, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 */

module.exports.Dispatcher = require('./lib/Dispatcher');

},{"./lib/Dispatcher":14}],14:[function(require,module,exports){
(function (process){
/**
 * Copyright (c) 2014-2015, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 *
 * @providesModule Dispatcher
 * 
 * @preventMunge
 */

'use strict';

exports.__esModule = true;

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError('Cannot call a class as a function'); } }

var invariant = require('fbjs/lib/invariant');

var _prefix = 'ID_';

/**
 * Dispatcher is used to broadcast payloads to registered callbacks. This is
 * different from generic pub-sub systems in two ways:
 *
 *   1) Callbacks are not subscribed to particular events. Every payload is
 *      dispatched to every registered callback.
 *   2) Callbacks can be deferred in whole or part until other callbacks have
 *      been executed.
 *
 * For example, consider this hypothetical flight destination form, which
 * selects a default city when a country is selected:
 *
 *   var flightDispatcher = new Dispatcher();
 *
 *   // Keeps track of which country is selected
 *   var CountryStore = {country: null};
 *
 *   // Keeps track of which city is selected
 *   var CityStore = {city: null};
 *
 *   // Keeps track of the base flight price of the selected city
 *   var FlightPriceStore = {price: null}
 *
 * When a user changes the selected city, we dispatch the payload:
 *
 *   flightDispatcher.dispatch({
 *     actionType: 'city-update',
 *     selectedCity: 'paris'
 *   });
 *
 * This payload is digested by `CityStore`:
 *
 *   flightDispatcher.register(function(payload) {
 *     if (payload.actionType === 'city-update') {
 *       CityStore.city = payload.selectedCity;
 *     }
 *   });
 *
 * When the user selects a country, we dispatch the payload:
 *
 *   flightDispatcher.dispatch({
 *     actionType: 'country-update',
 *     selectedCountry: 'australia'
 *   });
 *
 * This payload is digested by both stores:
 *
 *   CountryStore.dispatchToken = flightDispatcher.register(function(payload) {
 *     if (payload.actionType === 'country-update') {
 *       CountryStore.country = payload.selectedCountry;
 *     }
 *   });
 *
 * When the callback to update `CountryStore` is registered, we save a reference
 * to the returned token. Using this token with `waitFor()`, we can guarantee
 * that `CountryStore` is updated before the callback that updates `CityStore`
 * needs to query its data.
 *
 *   CityStore.dispatchToken = flightDispatcher.register(function(payload) {
 *     if (payload.actionType === 'country-update') {
 *       // `CountryStore.country` may not be updated.
 *       flightDispatcher.waitFor([CountryStore.dispatchToken]);
 *       // `CountryStore.country` is now guaranteed to be updated.
 *
 *       // Select the default city for the new country
 *       CityStore.city = getDefaultCityForCountry(CountryStore.country);
 *     }
 *   });
 *
 * The usage of `waitFor()` can be chained, for example:
 *
 *   FlightPriceStore.dispatchToken =
 *     flightDispatcher.register(function(payload) {
 *       switch (payload.actionType) {
 *         case 'country-update':
 *         case 'city-update':
 *           flightDispatcher.waitFor([CityStore.dispatchToken]);
 *           FlightPriceStore.price =
 *             getFlightPriceStore(CountryStore.country, CityStore.city);
 *           break;
 *     }
 *   });
 *
 * The `country-update` payload will be guaranteed to invoke the stores'
 * registered callbacks in order: `CountryStore`, `CityStore`, then
 * `FlightPriceStore`.
 */

var Dispatcher = (function () {
  function Dispatcher() {
    _classCallCheck(this, Dispatcher);

    this._callbacks = {};
    this._isDispatching = false;
    this._isHandled = {};
    this._isPending = {};
    this._lastID = 1;
  }

  /**
   * Registers a callback to be invoked with every dispatched payload. Returns
   * a token that can be used with `waitFor()`.
   */

  Dispatcher.prototype.register = function register(callback) {
    var id = _prefix + this._lastID++;
    this._callbacks[id] = callback;
    return id;
  };

  /**
   * Removes a callback based on its token.
   */

  Dispatcher.prototype.unregister = function unregister(id) {
    !this._callbacks[id] ? process.env.NODE_ENV !== 'production' ? invariant(false, 'Dispatcher.unregister(...): `%s` does not map to a registered callback.', id) : invariant(false) : undefined;
    delete this._callbacks[id];
  };

  /**
   * Waits for the callbacks specified to be invoked before continuing execution
   * of the current callback. This method should only be used by a callback in
   * response to a dispatched payload.
   */

  Dispatcher.prototype.waitFor = function waitFor(ids) {
    !this._isDispatching ? process.env.NODE_ENV !== 'production' ? invariant(false, 'Dispatcher.waitFor(...): Must be invoked while dispatching.') : invariant(false) : undefined;
    for (var ii = 0; ii < ids.length; ii++) {
      var id = ids[ii];
      if (this._isPending[id]) {
        !this._isHandled[id] ? process.env.NODE_ENV !== 'production' ? invariant(false, 'Dispatcher.waitFor(...): Circular dependency detected while ' + 'waiting for `%s`.', id) : invariant(false) : undefined;
        continue;
      }
      !this._callbacks[id] ? process.env.NODE_ENV !== 'production' ? invariant(false, 'Dispatcher.waitFor(...): `%s` does not map to a registered callback.', id) : invariant(false) : undefined;
      this._invokeCallback(id);
    }
  };

  /**
   * Dispatches a payload to all registered callbacks.
   */

  Dispatcher.prototype.dispatch = function dispatch(payload) {
    !!this._isDispatching ? process.env.NODE_ENV !== 'production' ? invariant(false, 'Dispatch.dispatch(...): Cannot dispatch in the middle of a dispatch.') : invariant(false) : undefined;
    this._startDispatching(payload);
    try {
      for (var id in this._callbacks) {
        if (this._isPending[id]) {
          continue;
        }
        this._invokeCallback(id);
      }
    } finally {
      this._stopDispatching();
    }
  };

  /**
   * Is this Dispatcher currently dispatching.
   */

  Dispatcher.prototype.isDispatching = function isDispatching() {
    return this._isDispatching;
  };

  /**
   * Call the callback stored with the given id. Also do some internal
   * bookkeeping.
   *
   * @internal
   */

  Dispatcher.prototype._invokeCallback = function _invokeCallback(id) {
    this._isPending[id] = true;
    this._callbacks[id](this._pendingPayload);
    this._isHandled[id] = true;
  };

  /**
   * Set up bookkeeping needed when dispatching.
   *
   * @internal
   */

  Dispatcher.prototype._startDispatching = function _startDispatching(payload) {
    for (var id in this._callbacks) {
      this._isPending[id] = false;
      this._isHandled[id] = false;
    }
    this._pendingPayload = payload;
    this._isDispatching = true;
  };

  /**
   * Clear bookkeeping used for dispatching.
   *
   * @internal
   */

  Dispatcher.prototype._stopDispatching = function _stopDispatching() {
    delete this._pendingPayload;
    this._isDispatching = false;
  };

  return Dispatcher;
})();

module.exports = Dispatcher;
}).call(this,require('_process'))

},{"_process":30,"fbjs/lib/invariant":12}],15:[function(require,module,exports){
/**
 * Indicates that navigation was caused by a call to history.push.
 */
'use strict';

exports.__esModule = true;
var PUSH = 'PUSH';

exports.PUSH = PUSH;
/**
 * Indicates that navigation was caused by a call to history.replace.
 */
var REPLACE = 'REPLACE';

exports.REPLACE = REPLACE;
/**
 * Indicates that navigation was caused by some other action such
 * as using a browser's back/forward buttons and/or manually manipulating
 * the URL in a browser's location bar. This is the default.
 *
 * See https://developer.mozilla.org/en-US/docs/Web/API/WindowEventHandlers/onpopstate
 * for more information.
 */
var POP = 'POP';

exports.POP = POP;
exports['default'] = {
  PUSH: PUSH,
  REPLACE: REPLACE,
  POP: POP
};
},{}],16:[function(require,module,exports){
"use strict";

exports.__esModule = true;
exports.loopAsync = loopAsync;

function loopAsync(turns, work, callback) {
  var currentTurn = 0;
  var isDone = false;

  function done() {
    isDone = true;
    callback.apply(this, arguments);
  }

  function next() {
    if (isDone) return;

    if (currentTurn < turns) {
      work.call(this, currentTurn++, next, done);
    } else {
      done.apply(this, arguments);
    }
  }

  next();
}
},{}],17:[function(require,module,exports){
(function (process){
/*eslint-disable no-empty */
'use strict';

exports.__esModule = true;
exports.saveState = saveState;
exports.readState = readState;

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { 'default': obj }; }

var _warning = require('warning');

var _warning2 = _interopRequireDefault(_warning);

var KeyPrefix = '@@History/';
var QuotaExceededError = 'QuotaExceededError';
var SecurityError = 'SecurityError';

function createKey(key) {
  return KeyPrefix + key;
}

function saveState(key, state) {
  try {
    window.sessionStorage.setItem(createKey(key), JSON.stringify(state));
  } catch (error) {
    if (error.name === SecurityError) {
      // Blocking cookies in Chrome/Firefox/Safari throws SecurityError on any
      // attempt to access window.sessionStorage.
      process.env.NODE_ENV !== 'production' ? _warning2['default'](false, '[history] Unable to save state; sessionStorage is not available due to security settings') : undefined;

      return;
    }

    if (error.name === QuotaExceededError && window.sessionStorage.length === 0) {
      // Safari "private mode" throws QuotaExceededError.
      process.env.NODE_ENV !== 'production' ? _warning2['default'](false, '[history] Unable to save state; sessionStorage is not available in Safari private mode') : undefined;

      return;
    }

    throw error;
  }
}

function readState(key) {
  var json = undefined;
  try {
    json = window.sessionStorage.getItem(createKey(key));
  } catch (error) {
    if (error.name === SecurityError) {
      // Blocking cookies in Chrome/Firefox/Safari throws SecurityError on any
      // attempt to access window.sessionStorage.
      process.env.NODE_ENV !== 'production' ? _warning2['default'](false, '[history] Unable to read state; sessionStorage is not available due to security settings') : undefined;

      return null;
    }
  }

  if (json) {
    try {
      return JSON.parse(json);
    } catch (error) {
      // Ignore invalid JSON.
    }
  }

  return null;
}
}).call(this,require('_process'))

},{"_process":30,"warning":32}],18:[function(require,module,exports){
'use strict';

exports.__esModule = true;
exports.addEventListener = addEventListener;
exports.removeEventListener = removeEventListener;
exports.getHashPath = getHashPath;
exports.replaceHashPath = replaceHashPath;
exports.getWindowPath = getWindowPath;
exports.go = go;
exports.getUserConfirmation = getUserConfirmation;
exports.supportsHistory = supportsHistory;
exports.supportsGoWithoutReloadUsingHash = supportsGoWithoutReloadUsingHash;

function addEventListener(node, event, listener) {
  if (node.addEventListener) {
    node.addEventListener(event, listener, false);
  } else {
    node.attachEvent('on' + event, listener);
  }
}

function removeEventListener(node, event, listener) {
  if (node.removeEventListener) {
    node.removeEventListener(event, listener, false);
  } else {
    node.detachEvent('on' + event, listener);
  }
}

function getHashPath() {
  // We can't use window.location.hash here because it's not
  // consistent across browsers - Firefox will pre-decode it!
  return window.location.href.split('#')[1] || '';
}

function replaceHashPath(path) {
  window.location.replace(window.location.pathname + window.location.search + '#' + path);
}

function getWindowPath() {
  return window.location.pathname + window.location.search + window.location.hash;
}

function go(n) {
  if (n) window.history.go(n);
}

function getUserConfirmation(message, callback) {
  callback(window.confirm(message));
}

/**
 * Returns true if the HTML5 history API is supported. Taken from Modernizr.
 *
 * https://github.com/Modernizr/Modernizr/blob/master/LICENSE
 * https://github.com/Modernizr/Modernizr/blob/master/feature-detects/history.js
 * changed to avoid false negatives for Windows Phones: https://github.com/rackt/react-router/issues/586
 */

function supportsHistory() {
  var ua = navigator.userAgent;
  if ((ua.indexOf('Android 2.') !== -1 || ua.indexOf('Android 4.0') !== -1) && ua.indexOf('Mobile Safari') !== -1 && ua.indexOf('Chrome') === -1 && ua.indexOf('Windows Phone') === -1) {
    return false;
  }
  // FIXME: Work around our browser history not working correctly on Chrome
  // iOS: https://github.com/rackt/react-router/issues/2565
  if (ua.indexOf('CriOS') !== -1) {
    return false;
  }
  return window.history && 'pushState' in window.history;
}

/**
 * Returns false if using go(n) with hash history causes a full page reload.
 */

function supportsGoWithoutReloadUsingHash() {
  var ua = navigator.userAgent;
  return ua.indexOf('Firefox') === -1;
}
},{}],19:[function(require,module,exports){
'use strict';

exports.__esModule = true;
var canUseDOM = !!(typeof window !== 'undefined' && window.document && window.document.createElement);
exports.canUseDOM = canUseDOM;
},{}],20:[function(require,module,exports){
(function (process){
'use strict';

exports.__esModule = true;

var _extends = Object.assign || function (target) { for (var i = 1; i < arguments.length; i++) { var source = arguments[i]; for (var key in source) { if (Object.prototype.hasOwnProperty.call(source, key)) { target[key] = source[key]; } } } return target; };

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { 'default': obj }; }

var _invariant = require('invariant');

var _invariant2 = _interopRequireDefault(_invariant);

var _Actions = require('./Actions');

var _ExecutionEnvironment = require('./ExecutionEnvironment');

var _DOMUtils = require('./DOMUtils');

var _DOMStateStorage = require('./DOMStateStorage');

var _createDOMHistory = require('./createDOMHistory');

var _createDOMHistory2 = _interopRequireDefault(_createDOMHistory);

var _parsePath = require('./parsePath');

var _parsePath2 = _interopRequireDefault(_parsePath);

/**
 * Creates and returns a history object that uses HTML5's history API
 * (pushState, replaceState, and the popstate event) to manage history.
 * This is the recommended method of managing history in browsers because
 * it provides the cleanest URLs.
 *
 * Note: In browsers that do not support the HTML5 history API full
 * page reloads will be used to preserve URLs.
 */
function createBrowserHistory() {
  var options = arguments.length <= 0 || arguments[0] === undefined ? {} : arguments[0];

  !_ExecutionEnvironment.canUseDOM ? process.env.NODE_ENV !== 'production' ? _invariant2['default'](false, 'Browser history needs a DOM') : _invariant2['default'](false) : undefined;

  var forceRefresh = options.forceRefresh;

  var isSupported = _DOMUtils.supportsHistory();
  var useRefresh = !isSupported || forceRefresh;

  function getCurrentLocation(historyState) {
    historyState = historyState || window.history.state || {};

    var path = _DOMUtils.getWindowPath();
    var _historyState = historyState;
    var key = _historyState.key;

    var state = undefined;
    if (key) {
      state = _DOMStateStorage.readState(key);
    } else {
      state = null;
      key = history.createKey();

      if (isSupported) window.history.replaceState(_extends({}, historyState, { key: key }), null, path);
    }

    var location = _parsePath2['default'](path);

    return history.createLocation(_extends({}, location, { state: state }), undefined, key);
  }

  function startPopStateListener(_ref) {
    var transitionTo = _ref.transitionTo;

    function popStateListener(event) {
      if (event.state === undefined) return; // Ignore extraneous popstate events in WebKit.

      transitionTo(getCurrentLocation(event.state));
    }

    _DOMUtils.addEventListener(window, 'popstate', popStateListener);

    return function () {
      _DOMUtils.removeEventListener(window, 'popstate', popStateListener);
    };
  }

  function finishTransition(location) {
    var basename = location.basename;
    var pathname = location.pathname;
    var search = location.search;
    var hash = location.hash;
    var state = location.state;
    var action = location.action;
    var key = location.key;

    if (action === _Actions.POP) return; // Nothing to do.

    _DOMStateStorage.saveState(key, state);

    var path = (basename || '') + pathname + search + hash;
    var historyState = {
      key: key
    };

    if (action === _Actions.PUSH) {
      if (useRefresh) {
        window.location.href = path;
        return false; // Prevent location update.
      } else {
          window.history.pushState(historyState, null, path);
        }
    } else {
      // REPLACE
      if (useRefresh) {
        window.location.replace(path);
        return false; // Prevent location update.
      } else {
          window.history.replaceState(historyState, null, path);
        }
    }
  }

  var history = _createDOMHistory2['default'](_extends({}, options, {
    getCurrentLocation: getCurrentLocation,
    finishTransition: finishTransition,
    saveState: _DOMStateStorage.saveState
  }));

  var listenerCount = 0,
      stopPopStateListener = undefined;

  function listenBefore(listener) {
    if (++listenerCount === 1) stopPopStateListener = startPopStateListener(history);

    var unlisten = history.listenBefore(listener);

    return function () {
      unlisten();

      if (--listenerCount === 0) stopPopStateListener();
    };
  }

  function listen(listener) {
    if (++listenerCount === 1) stopPopStateListener = startPopStateListener(history);

    var unlisten = history.listen(listener);

    return function () {
      unlisten();

      if (--listenerCount === 0) stopPopStateListener();
    };
  }

  // deprecated
  function registerTransitionHook(hook) {
    if (++listenerCount === 1) stopPopStateListener = startPopStateListener(history);

    history.registerTransitionHook(hook);
  }

  // deprecated
  function unregisterTransitionHook(hook) {
    history.unregisterTransitionHook(hook);

    if (--listenerCount === 0) stopPopStateListener();
  }

  return _extends({}, history, {
    listenBefore: listenBefore,
    listen: listen,
    registerTransitionHook: registerTransitionHook,
    unregisterTransitionHook: unregisterTransitionHook
  });
}

exports['default'] = createBrowserHistory;
module.exports = exports['default'];
}).call(this,require('_process'))

},{"./Actions":15,"./DOMStateStorage":17,"./DOMUtils":18,"./ExecutionEnvironment":19,"./createDOMHistory":21,"./parsePath":26,"_process":30,"invariant":28}],21:[function(require,module,exports){
(function (process){
'use strict';

exports.__esModule = true;

var _extends = Object.assign || function (target) { for (var i = 1; i < arguments.length; i++) { var source = arguments[i]; for (var key in source) { if (Object.prototype.hasOwnProperty.call(source, key)) { target[key] = source[key]; } } } return target; };

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { 'default': obj }; }

var _invariant = require('invariant');

var _invariant2 = _interopRequireDefault(_invariant);

var _ExecutionEnvironment = require('./ExecutionEnvironment');

var _DOMUtils = require('./DOMUtils');

var _createHistory = require('./createHistory');

var _createHistory2 = _interopRequireDefault(_createHistory);

function createDOMHistory(options) {
  var history = _createHistory2['default'](_extends({
    getUserConfirmation: _DOMUtils.getUserConfirmation
  }, options, {
    go: _DOMUtils.go
  }));

  function listen(listener) {
    !_ExecutionEnvironment.canUseDOM ? process.env.NODE_ENV !== 'production' ? _invariant2['default'](false, 'DOM history needs a DOM') : _invariant2['default'](false) : undefined;

    return history.listen(listener);
  }

  return _extends({}, history, {
    listen: listen
  });
}

exports['default'] = createDOMHistory;
module.exports = exports['default'];
}).call(this,require('_process'))

},{"./DOMUtils":18,"./ExecutionEnvironment":19,"./createHistory":22,"_process":30,"invariant":28}],22:[function(require,module,exports){
//import warning from 'warning'
'use strict';

exports.__esModule = true;

var _extends = Object.assign || function (target) { for (var i = 1; i < arguments.length; i++) { var source = arguments[i]; for (var key in source) { if (Object.prototype.hasOwnProperty.call(source, key)) { target[key] = source[key]; } } } return target; };

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { 'default': obj }; }

var _deepEqual = require('deep-equal');

var _deepEqual2 = _interopRequireDefault(_deepEqual);

var _AsyncUtils = require('./AsyncUtils');

var _Actions = require('./Actions');

var _createLocation2 = require('./createLocation');

var _createLocation3 = _interopRequireDefault(_createLocation2);

var _runTransitionHook = require('./runTransitionHook');

var _runTransitionHook2 = _interopRequireDefault(_runTransitionHook);

var _parsePath = require('./parsePath');

var _parsePath2 = _interopRequireDefault(_parsePath);

var _deprecate = require('./deprecate');

var _deprecate2 = _interopRequireDefault(_deprecate);

function createRandomKey(length) {
  return Math.random().toString(36).substr(2, length);
}

function locationsAreEqual(a, b) {
  return a.pathname === b.pathname && a.search === b.search &&
  //a.action === b.action && // Different action !== location change.
  a.key === b.key && _deepEqual2['default'](a.state, b.state);
}

var DefaultKeyLength = 6;

function createHistory() {
  var options = arguments.length <= 0 || arguments[0] === undefined ? {} : arguments[0];
  var getCurrentLocation = options.getCurrentLocation;
  var finishTransition = options.finishTransition;
  var saveState = options.saveState;
  var go = options.go;
  var keyLength = options.keyLength;
  var getUserConfirmation = options.getUserConfirmation;

  if (typeof keyLength !== 'number') keyLength = DefaultKeyLength;

  var transitionHooks = [];

  function listenBefore(hook) {
    transitionHooks.push(hook);

    return function () {
      transitionHooks = transitionHooks.filter(function (item) {
        return item !== hook;
      });
    };
  }

  var allKeys = [];
  var changeListeners = [];
  var location = undefined;

  function getCurrent() {
    if (pendingLocation && pendingLocation.action === _Actions.POP) {
      return allKeys.indexOf(pendingLocation.key);
    } else if (location) {
      return allKeys.indexOf(location.key);
    } else {
      return -1;
    }
  }

  function updateLocation(newLocation) {
    var current = getCurrent();

    location = newLocation;

    if (location.action === _Actions.PUSH) {
      allKeys = [].concat(allKeys.slice(0, current + 1), [location.key]);
    } else if (location.action === _Actions.REPLACE) {
      allKeys[current] = location.key;
    }

    changeListeners.forEach(function (listener) {
      listener(location);
    });
  }

  function listen(listener) {
    changeListeners.push(listener);

    if (location) {
      listener(location);
    } else {
      var _location = getCurrentLocation();
      allKeys = [_location.key];
      updateLocation(_location);
    }

    return function () {
      changeListeners = changeListeners.filter(function (item) {
        return item !== listener;
      });
    };
  }

  function confirmTransitionTo(location, callback) {
    _AsyncUtils.loopAsync(transitionHooks.length, function (index, next, done) {
      _runTransitionHook2['default'](transitionHooks[index], location, function (result) {
        if (result != null) {
          done(result);
        } else {
          next();
        }
      });
    }, function (message) {
      if (getUserConfirmation && typeof message === 'string') {
        getUserConfirmation(message, function (ok) {
          callback(ok !== false);
        });
      } else {
        callback(message !== false);
      }
    });
  }

  var pendingLocation = undefined;

  function transitionTo(nextLocation) {
    if (location && locationsAreEqual(location, nextLocation)) return; // Nothing to do.

    pendingLocation = nextLocation;

    confirmTransitionTo(nextLocation, function (ok) {
      if (pendingLocation !== nextLocation) return; // Transition was interrupted.

      if (ok) {
        // treat PUSH to current path like REPLACE to be consistent with browsers
        if (nextLocation.action === _Actions.PUSH) {
          var prevPath = createPath(location);
          var nextPath = createPath(nextLocation);

          if (nextPath === prevPath) nextLocation.action = _Actions.REPLACE;
        }

        if (finishTransition(nextLocation) !== false) updateLocation(nextLocation);
      } else if (location && nextLocation.action === _Actions.POP) {
        var prevIndex = allKeys.indexOf(location.key);
        var nextIndex = allKeys.indexOf(nextLocation.key);

        if (prevIndex !== -1 && nextIndex !== -1) go(prevIndex - nextIndex); // Restore the URL.
      }
    });
  }

  function push(location) {
    transitionTo(createLocation(location, _Actions.PUSH, createKey()));
  }

  function replace(location) {
    transitionTo(createLocation(location, _Actions.REPLACE, createKey()));
  }

  function goBack() {
    go(-1);
  }

  function goForward() {
    go(1);
  }

  function createKey() {
    return createRandomKey(keyLength);
  }

  function createPath(location) {
    if (location == null || typeof location === 'string') return location;

    var pathname = location.pathname;
    var search = location.search;
    var hash = location.hash;

    var result = pathname;

    if (search) result += search;

    if (hash) result += hash;

    return result;
  }

  function createHref(location) {
    return createPath(location);
  }

  function createLocation(location, action) {
    var key = arguments.length <= 2 || arguments[2] === undefined ? createKey() : arguments[2];

    if (typeof action === 'object') {
      //warning(
      //  false,
      //  'The state (2nd) argument to history.createLocation is deprecated; use a ' +
      //  'location descriptor instead'
      //)

      if (typeof location === 'string') location = _parsePath2['default'](location);

      location = _extends({}, location, { state: action });

      action = key;
      key = arguments[3] || createKey();
    }

    return _createLocation3['default'](location, action, key);
  }

  // deprecated
  function setState(state) {
    if (location) {
      updateLocationState(location, state);
      updateLocation(location);
    } else {
      updateLocationState(getCurrentLocation(), state);
    }
  }

  function updateLocationState(location, state) {
    location.state = _extends({}, location.state, state);
    saveState(location.key, location.state);
  }

  // deprecated
  function registerTransitionHook(hook) {
    if (transitionHooks.indexOf(hook) === -1) transitionHooks.push(hook);
  }

  // deprecated
  function unregisterTransitionHook(hook) {
    transitionHooks = transitionHooks.filter(function (item) {
      return item !== hook;
    });
  }

  // deprecated
  function pushState(state, path) {
    if (typeof path === 'string') path = _parsePath2['default'](path);

    push(_extends({ state: state }, path));
  }

  // deprecated
  function replaceState(state, path) {
    if (typeof path === 'string') path = _parsePath2['default'](path);

    replace(_extends({ state: state }, path));
  }

  return {
    listenBefore: listenBefore,
    listen: listen,
    transitionTo: transitionTo,
    push: push,
    replace: replace,
    go: go,
    goBack: goBack,
    goForward: goForward,
    createKey: createKey,
    createPath: createPath,
    createHref: createHref,
    createLocation: createLocation,

    setState: _deprecate2['default'](setState, 'setState is deprecated; use location.key to save state instead'),
    registerTransitionHook: _deprecate2['default'](registerTransitionHook, 'registerTransitionHook is deprecated; use listenBefore instead'),
    unregisterTransitionHook: _deprecate2['default'](unregisterTransitionHook, 'unregisterTransitionHook is deprecated; use the callback returned from listenBefore instead'),
    pushState: _deprecate2['default'](pushState, 'pushState is deprecated; use push instead'),
    replaceState: _deprecate2['default'](replaceState, 'replaceState is deprecated; use replace instead')
  };
}

exports['default'] = createHistory;
module.exports = exports['default'];
},{"./Actions":15,"./AsyncUtils":16,"./createLocation":23,"./deprecate":24,"./parsePath":26,"./runTransitionHook":27,"deep-equal":9}],23:[function(require,module,exports){
//import warning from 'warning'
'use strict';

exports.__esModule = true;

var _extends = Object.assign || function (target) { for (var i = 1; i < arguments.length; i++) { var source = arguments[i]; for (var key in source) { if (Object.prototype.hasOwnProperty.call(source, key)) { target[key] = source[key]; } } } return target; };

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { 'default': obj }; }

var _Actions = require('./Actions');

var _parsePath = require('./parsePath');

var _parsePath2 = _interopRequireDefault(_parsePath);

function createLocation() {
  var location = arguments.length <= 0 || arguments[0] === undefined ? '/' : arguments[0];
  var action = arguments.length <= 1 || arguments[1] === undefined ? _Actions.POP : arguments[1];
  var key = arguments.length <= 2 || arguments[2] === undefined ? null : arguments[2];

  var _fourthArg = arguments.length <= 3 || arguments[3] === undefined ? null : arguments[3];

  if (typeof location === 'string') location = _parsePath2['default'](location);

  if (typeof action === 'object') {
    //warning(
    //  false,
    //  'The state (2nd) argument to createLocation is deprecated; use a ' +
    //  'location descriptor instead'
    //)

    location = _extends({}, location, { state: action });

    action = key || _Actions.POP;
    key = _fourthArg;
  }

  var pathname = location.pathname || '/';
  var search = location.search || '';
  var hash = location.hash || '';
  var state = location.state || null;

  return {
    pathname: pathname,
    search: search,
    hash: hash,
    state: state,
    action: action,
    key: key
  };
}

exports['default'] = createLocation;
module.exports = exports['default'];
},{"./Actions":15,"./parsePath":26}],24:[function(require,module,exports){
//import warning from 'warning'

"use strict";

exports.__esModule = true;
function deprecate(fn) {
  return fn;
  //return function () {
  //  warning(false, '[history] ' + message)
  //  return fn.apply(this, arguments)
  //}
}

exports["default"] = deprecate;
module.exports = exports["default"];
},{}],25:[function(require,module,exports){
"use strict";

exports.__esModule = true;
function extractPath(string) {
  var match = string.match(/^https?:\/\/[^\/]*/);

  if (match == null) return string;

  return string.substring(match[0].length);
}

exports["default"] = extractPath;
module.exports = exports["default"];
},{}],26:[function(require,module,exports){
(function (process){
'use strict';

exports.__esModule = true;

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { 'default': obj }; }

var _warning = require('warning');

var _warning2 = _interopRequireDefault(_warning);

var _extractPath = require('./extractPath');

var _extractPath2 = _interopRequireDefault(_extractPath);

function parsePath(path) {
  var pathname = _extractPath2['default'](path);
  var search = '';
  var hash = '';

  process.env.NODE_ENV !== 'production' ? _warning2['default'](path === pathname, 'A path must be pathname + search + hash only, not a fully qualified URL like "%s"', path) : undefined;

  var hashIndex = pathname.indexOf('#');
  if (hashIndex !== -1) {
    hash = pathname.substring(hashIndex);
    pathname = pathname.substring(0, hashIndex);
  }

  var searchIndex = pathname.indexOf('?');
  if (searchIndex !== -1) {
    search = pathname.substring(searchIndex);
    pathname = pathname.substring(0, searchIndex);
  }

  if (pathname === '') pathname = '/';

  return {
    pathname: pathname,
    search: search,
    hash: hash
  };
}

exports['default'] = parsePath;
module.exports = exports['default'];
}).call(this,require('_process'))

},{"./extractPath":25,"_process":30,"warning":32}],27:[function(require,module,exports){
(function (process){
'use strict';

exports.__esModule = true;

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { 'default': obj }; }

var _warning = require('warning');

var _warning2 = _interopRequireDefault(_warning);

function runTransitionHook(hook, location, callback) {
  var result = hook(location, callback);

  if (hook.length < 2) {
    // Assume the hook runs synchronously and automatically
    // call the callback with the return value.
    callback(result);
  } else {
    process.env.NODE_ENV !== 'production' ? _warning2['default'](result === undefined, 'You should not "return" in a transition hook with a callback argument; call the callback instead') : undefined;
  }
}

exports['default'] = runTransitionHook;
module.exports = exports['default'];
}).call(this,require('_process'))

},{"_process":30,"warning":32}],28:[function(require,module,exports){
(function (process){
/**
 * Copyright 2013-2015, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 */

'use strict';

/**
 * Use invariant() to assert state which your program assumes to be true.
 *
 * Provide sprintf-style format (only %s is supported) and arguments
 * to provide information about what broke and what you were
 * expecting.
 *
 * The invariant message will be stripped in production, but the invariant
 * will remain to ensure logic does not differ in production.
 */

var invariant = function(condition, format, a, b, c, d, e, f) {
  if (process.env.NODE_ENV !== 'production') {
    if (format === undefined) {
      throw new Error('invariant requires an error message argument');
    }
  }

  if (!condition) {
    var error;
    if (format === undefined) {
      error = new Error(
        'Minified exception occurred; use the non-minified dev environment ' +
        'for the full error message and additional helpful warnings.'
      );
    } else {
      var args = [a, b, c, d, e, f];
      var argIndex = 0;
      error = new Error(
        format.replace(/%s/g, function() { return args[argIndex++]; })
      );
      error.name = 'Invariant Violation';
    }

    error.framesToPop = 1; // we don't care about invariant's own frame
    throw error;
  }
};

module.exports = invariant;

}).call(this,require('_process'))

},{"_process":30}],29:[function(require,module,exports){
module.exports = isPromise;

function isPromise(obj) {
  return !!obj && (typeof obj === 'object' || typeof obj === 'function') && typeof obj.then === 'function';
}

},{}],30:[function(require,module,exports){
// shim for using process in browser
var process = module.exports = {};

// cached from whatever global is present so that test runners that stub it
// don't break things.  But we need to wrap it in a try catch in case it is
// wrapped in strict mode code which doesn't define any globals.  It's inside a
// function because try/catches deoptimize in certain engines.

var cachedSetTimeout;
var cachedClearTimeout;

function defaultSetTimout() {
    throw new Error('setTimeout has not been defined');
}
function defaultClearTimeout () {
    throw new Error('clearTimeout has not been defined');
}
(function () {
    try {
        if (typeof setTimeout === 'function') {
            cachedSetTimeout = setTimeout;
        } else {
            cachedSetTimeout = defaultSetTimout;
        }
    } catch (e) {
        cachedSetTimeout = defaultSetTimout;
    }
    try {
        if (typeof clearTimeout === 'function') {
            cachedClearTimeout = clearTimeout;
        } else {
            cachedClearTimeout = defaultClearTimeout;
        }
    } catch (e) {
        cachedClearTimeout = defaultClearTimeout;
    }
} ())
function runTimeout(fun) {
    if (cachedSetTimeout === setTimeout) {
        //normal enviroments in sane situations
        return setTimeout(fun, 0);
    }
    // if setTimeout wasn't available but was latter defined
    if ((cachedSetTimeout === defaultSetTimout || !cachedSetTimeout) && setTimeout) {
        cachedSetTimeout = setTimeout;
        return setTimeout(fun, 0);
    }
    try {
        // when when somebody has screwed with setTimeout but no I.E. maddness
        return cachedSetTimeout(fun, 0);
    } catch(e){
        try {
            // When we are in I.E. but the script has been evaled so I.E. doesn't trust the global object when called normally
            return cachedSetTimeout.call(null, fun, 0);
        } catch(e){
            // same as above but when it's a version of I.E. that must have the global object for 'this', hopfully our context correct otherwise it will throw a global error
            return cachedSetTimeout.call(this, fun, 0);
        }
    }


}
function runClearTimeout(marker) {
    if (cachedClearTimeout === clearTimeout) {
        //normal enviroments in sane situations
        return clearTimeout(marker);
    }
    // if clearTimeout wasn't available but was latter defined
    if ((cachedClearTimeout === defaultClearTimeout || !cachedClearTimeout) && clearTimeout) {
        cachedClearTimeout = clearTimeout;
        return clearTimeout(marker);
    }
    try {
        // when when somebody has screwed with setTimeout but no I.E. maddness
        return cachedClearTimeout(marker);
    } catch (e){
        try {
            // When we are in I.E. but the script has been evaled so I.E. doesn't  trust the global object when called normally
            return cachedClearTimeout.call(null, marker);
        } catch (e){
            // same as above but when it's a version of I.E. that must have the global object for 'this', hopfully our context correct otherwise it will throw a global error.
            // Some versions of I.E. have different rules for clearTimeout vs setTimeout
            return cachedClearTimeout.call(this, marker);
        }
    }



}
var queue = [];
var draining = false;
var currentQueue;
var queueIndex = -1;

function cleanUpNextTick() {
    if (!draining || !currentQueue) {
        return;
    }
    draining = false;
    if (currentQueue.length) {
        queue = currentQueue.concat(queue);
    } else {
        queueIndex = -1;
    }
    if (queue.length) {
        drainQueue();
    }
}

function drainQueue() {
    if (draining) {
        return;
    }
    var timeout = runTimeout(cleanUpNextTick);
    draining = true;

    var len = queue.length;
    while(len) {
        currentQueue = queue;
        queue = [];
        while (++queueIndex < len) {
            if (currentQueue) {
                currentQueue[queueIndex].run();
            }
        }
        queueIndex = -1;
        len = queue.length;
    }
    currentQueue = null;
    draining = false;
    runClearTimeout(timeout);
}

process.nextTick = function (fun) {
    var args = new Array(arguments.length - 1);
    if (arguments.length > 1) {
        for (var i = 1; i < arguments.length; i++) {
            args[i - 1] = arguments[i];
        }
    }
    queue.push(new Item(fun, args));
    if (queue.length === 1 && !draining) {
        runTimeout(drainQueue);
    }
};

// v8 likes predictible objects
function Item(fun, array) {
    this.fun = fun;
    this.array = array;
}
Item.prototype.run = function () {
    this.fun.apply(null, this.array);
};
process.title = 'browser';
process.browser = true;
process.env = {};
process.argv = [];
process.version = ''; // empty string to avoid regexp issues
process.versions = {};

function noop() {}

process.on = noop;
process.addListener = noop;
process.once = noop;
process.off = noop;
process.removeListener = noop;
process.removeAllListeners = noop;
process.emit = noop;
process.prependListener = noop;
process.prependOnceListener = noop;

process.listeners = function (name) { return [] }

process.binding = function (name) {
    throw new Error('process.binding is not supported');
};

process.cwd = function () { return '/' };
process.chdir = function (dir) {
    throw new Error('process.chdir is not supported');
};
process.umask = function() { return 0; };

},{}],31:[function(require,module,exports){
"use strict";

function transmitter() {
  var subscriptions = [];
  var nowDispatching = false;
  var toUnsubscribe = {};

  var unsubscribe = function unsubscribe(onChange) {
    var id = subscriptions.indexOf(onChange);
    if (id < 0) return;
    if (nowDispatching) {
      toUnsubscribe[id] = onChange;
      return;
    }
    subscriptions.splice(id, 1);
  };

  var subscribe = function subscribe(onChange) {
    var id = subscriptions.push(onChange);
    var dispose = function dispose() {
      return unsubscribe(onChange);
    };
    return { dispose: dispose };
  };

  var publish = function publish() {
    for (var _len = arguments.length, args = Array(_len), _key = 0; _key < _len; _key++) {
      args[_key] = arguments[_key];
    }

    nowDispatching = true;
    try {
      subscriptions.forEach(function (subscription, id) {
        return toUnsubscribe[id] || subscription.apply(undefined, args);
      });
    } finally {
      nowDispatching = false;
      Object.keys(toUnsubscribe).forEach(function (id) {
        return unsubscribe(toUnsubscribe[id]);
      });
      toUnsubscribe = {};
    }
  };

  return {
    publish: publish,
    subscribe: subscribe,
    $subscriptions: subscriptions
  };
}

module.exports = transmitter;
},{}],32:[function(require,module,exports){
(function (process){
/**
 * Copyright 2014-2015, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 */

'use strict';

/**
 * Similar to invariant but only logs a warning if the condition is not met.
 * This can be used to log issues in development environments in critical
 * paths. Removing the logging code for production environments will keep the
 * same logic and follow the same code paths.
 */

var warning = function() {};

if (process.env.NODE_ENV !== 'production') {
  warning = function(condition, format, args) {
    var len = arguments.length;
    args = new Array(len > 2 ? len - 2 : 0);
    for (var key = 2; key < len; key++) {
      args[key - 2] = arguments[key];
    }
    if (format === undefined) {
      throw new Error(
        '`warning(condition, format, ...args)` requires a warning ' +
        'message argument'
      );
    }

    if (format.length < 10 || (/^[s\W]*$/).test(format)) {
      throw new Error(
        'The warning format should be able to uniquely identify this ' +
        'warning. Please, use a more descriptive format than: ' + format
      );
    }

    if (!condition) {
      var argIndex = 0;
      var message = 'Warning: ' +
        format.replace(/%s/g, function() {
          return args[argIndex++];
        });
      if (typeof console !== 'undefined') {
        console.error(message);
      }
      try {
        // This error was thrown as a convenience so that you can use this stack
        // to find the callsite that caused this warning to fire.
        throw new Error(message);
      } catch(x) {}
    }
  };
}

module.exports = warning;

}).call(this,require('_process'))

},{"_process":30}],33:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
  value: true
});

var _alt = require('../alt');

var _alt2 = _interopRequireDefault(_alt);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var FormActions = function FormActions() {
  _classCallCheck(this, FormActions);

  this.generateActions('handleUsernameChange', 'handlePasswordChange', 'handleConfirmedPasswordChange', 'handleFirstNameChange', 'handleLastNameChange', 'handleAgeChange', 'handleGenderChange', 'usernameValidationFail', 'passwordValidationFail', 'unauthorizedAccessAttempt', 'handleCommentChange', 'commentValidationFail', 'handleScoreChange', 'scoreValidationFail');
};

exports.default = _alt2.default.createActions(FormActions);

},{"../alt":38}],34:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
  value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _alt = require('../alt');

var _alt2 = _interopRequireDefault(_alt);

var _RequesterTMDB = require('../utilities/RequesterTMDB');

var _RequesterTMDB2 = _interopRequireDefault(_RequesterTMDB);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var MovieActions = function () {
  function MovieActions() {
    _classCallCheck(this, MovieActions);

    this.generateActions('getTopTenMoviesSuccess', 'getTopTenMoviesFail', 'getFiveRecentMoviesSuccess', 'getFiveRecentMoviesFail', 'emptyTopTenMovies', 'addMovieToTopTen', 'addCommentSuccess', 'addCommentFail', 'addVoteSuccess', 'addVoteFail');
  }

  _createClass(MovieActions, [{
    key: 'getFiveRecentMovies',
    value: function getFiveRecentMovies() {
      var _this = this;

      var request = {
        method: 'get',
        url: '/api/movies/five-recent'
      };
      $.ajax(request).done(function (data) {
        return _this.getFiveRecentMoviesSuccess(data);
      });

      return true;
    }
  }, {
    key: 'getTopTenMovies',
    value: function getTopTenMovies() {
      var _this2 = this;

      var request = {
        url: '/api/movies/top-ten',
        method: 'get'
      };

      $.ajax(request).done(function (payload) {
        _this2.emptyTopTenMovies();
        var _iteratorNormalCompletion = true;
        var _didIteratorError = false;
        var _iteratorError = undefined;

        try {
          var _loop = function _loop() {
            var movie = _step.value;

            var movieData = {
              _id: movie._id,
              name: movie.name,
              description: movie.description,
              genres: movie.genres,
              votes: movie.votes,
              score: movie.score
            };

            _RequesterTMDB2.default.getMoviePoster(movie.name).then(function (tmdbResponse) {
              movieData.moviePosterUrl = tmdbResponse.posterUrl;

              getComments(movie._id).then(function (comments) {
                movieData.comments = comments;

                getLoggedInUserVote(movie._id).then(function (vote) {
                  movieData.loggedInUserScore = vote.voteScore;

                  _this2.addMovieToTopTen(movieData);
                });
              });
            });
          };

          for (var _iterator = payload[Symbol.iterator](), _step; !(_iteratorNormalCompletion = (_step = _iterator.next()).done); _iteratorNormalCompletion = true) {
            _loop();
          }
        } catch (err) {
          _didIteratorError = true;
          _iteratorError = err;
        } finally {
          try {
            if (!_iteratorNormalCompletion && _iterator.return) {
              _iterator.return();
            }
          } finally {
            if (_didIteratorError) {
              throw _iteratorError;
            }
          }
        }
      }).fail(function (err) {
        return _this2.getTopTenMoviesFail(err);
      });

      return true;
    }
  }, {
    key: 'addComment',
    value: function addComment(movieId, comment) {
      var _this3 = this;

      var request = {
        url: '/api/movies/' + movieId + '/comments',
        method: 'post',
        contentType: 'application/json',
        data: JSON.stringify({ content: comment })
      };

      $.ajax(request).done(function (data) {
        _this3.addCommentSuccess(data);
      }).fail(function (err) {
        _this3.addCommentFail(err.responseJSON);
      });

      return true;
    }
  }, {
    key: 'addVote',
    value: function addVote(movieId, score) {
      var _this4 = this;

      var request = {
        url: '/api/movies/' + movieId + '/vote',
        method: 'post',
        contentType: 'application/json',
        data: JSON.stringify({ score: score })
      };

      $.ajax(request).then(function (data) {
        data.movieId = movieId, _this4.addVoteSuccess(data);
      }).fail(function (err) {
        return _this4.addVoteFail(err.responseJSON);
      });

      return true;
    }
  }]);

  return MovieActions;
}();

exports.default = _alt2.default.createActions(MovieActions);


function getComments(movieId) {
  return new Promise(function (resolve, reject) {
    var request = {
      url: '/api/movies/' + movieId + '/comments',
      method: 'get'
    };

    $.ajax(request).done(function (data) {
      return resolve(data);
    }).fail(function (err) {
      return reject(err);
    });
  });
}

function getLoggedInUserVote(movieId, userId) {
  return new Promise(function (resolve) {
    var request = {
      method: 'get'
    };

    if (userId) {
      request.url = '/api/movies/' + movieId + '/vote?userId=' + userId;
    } else {
      request.url = '/api/movies/' + movieId + '/vote?user=loggedInUser';
    }

    $.ajax(request).done(function (data) {
      return resolve(data);
    });
  });
}

},{"../alt":38,"../utilities/RequesterTMDB":74}],35:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
    value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _alt = require('../alt');

var _alt2 = _interopRequireDefault(_alt);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var MovieAddActions = function () {
    function MovieAddActions() {
        _classCallCheck(this, MovieAddActions);

        this.generateActions('handleNameChange', 'handleDescriptionChange', 'handleGenresChange', 'nameValidationFail', 'genresValidationFail', 'addMovieSuccess', 'addMovieFail');
    }

    _createClass(MovieAddActions, [{
        key: 'addMovie',
        value: function addMovie(data) {
            var _this = this;

            var request = {
                url: '/api/movies/add',
                method: 'POST',
                data: JSON.stringify(data),
                contentType: 'application/json'
            };
            $.ajax(request).done(function () {
                return _this.addMovieSuccess();
            }).fail(function (err) {
                return _this.addMovieFail(err);
            });

            return true;
        }
    }]);

    return MovieAddActions;
}();

exports.default = _alt2.default.createActions(MovieAddActions);

},{"../alt":38}],36:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
    value: true
});

var _alt = require('../alt');

var _alt2 = _interopRequireDefault(_alt);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var NavbarActions = function NavbarActions() {
    _classCallCheck(this, NavbarActions);

    this.generateActions('updateAjaxAnimation');
};

exports.default = _alt2.default.createActions(NavbarActions);

},{"../alt":38}],37:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
    value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _alt = require('../alt');

var _alt2 = _interopRequireDefault(_alt);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var UserActions = function () {
    function UserActions() {
        _classCallCheck(this, UserActions);

        this.generateActions('registerUserSuccess', 'registerUserFail', 'loginUserSuccess', 'loginUserFail', 'logoutUserSuccess');
    }

    _createClass(UserActions, [{
        key: 'registerUser',
        value: function registerUser(data) {
            var _this = this;

            var request = {
                url: '/user/register',
                method: 'post',
                data: JSON.stringify(data),
                contentType: 'application/json'
            };
            $.ajax(request).done(function () {
                return _this.registerUserSuccess();
            }).fail(function (err) {
                console.log('error', err);
                _this.registerUserFail(err.responseJSON.message);
            });

            return true;
        }
    }, {
        key: 'loginUser',
        value: function loginUser(data) {
            var _this2 = this;

            var request = {
                url: '/user/login',
                method: 'post',
                data: JSON.stringify(data),
                contentType: 'application/json'
            };
            $.ajax(request).done(function (data) {
                return _this2.loginUserSuccess(data);
            }).fail(function (err) {
                return _this2.loginUserFail(err.responseJSON);
            });

            return true;
        }
    }, {
        key: 'logoutUser',
        value: function logoutUser() {
            var _this3 = this;

            var request = {
                url: '/user/logout',
                method: 'post'
            };
            $.ajax(request).done(function () {
                return _this3.logoutUserSuccess();
            });

            return true;
        }
    }]);

    return UserActions;
}();

exports.default = _alt2.default.createActions(UserActions);

},{"../alt":38}],38:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
  value: true
});

var _alt = require('alt');

var _alt2 = _interopRequireDefault(_alt);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

exports.default = new _alt2.default();

},{"alt":3}],39:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
    value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _react = require('react');

var _react2 = _interopRequireDefault(_react);

var _UserActions = require('../actions/UserActions');

var _UserActions2 = _interopRequireDefault(_UserActions);

var _UserStore = require('../stores/UserStore');

var _UserStore2 = _interopRequireDefault(_UserStore);

var _Footer = require('./Footer');

var _Footer2 = _interopRequireDefault(_Footer);

var _Navbar = require('./Navbar');

var _Navbar2 = _interopRequireDefault(_Navbar);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var App = function (_React$Component) {
    _inherits(App, _React$Component);

    function App(props) {
        _classCallCheck(this, App);

        var _this = _possibleConstructorReturn(this, (App.__proto__ || Object.getPrototypeOf(App)).call(this, props));

        _this.state = _UserStore2.default.getState();

        _this.onChange = _this.onChange.bind(_this);
        return _this;
    }

    _createClass(App, [{
        key: 'onChange',
        value: function onChange(state) {
            this.setState(state);
        }
    }, {
        key: 'componentDidMount',
        value: function componentDidMount() {
            _UserStore2.default.listen(this.onChange);
        }
    }, {
        key: 'componentWillUnmount',
        value: function componentWillUnmount() {
            _UserStore2.default.unlisten(this.onChange);
        }
    }, {
        key: 'render',
        value: function render() {
            return _react2.default.createElement(
                'div',
                null,
                _react2.default.createElement(_Navbar2.default, null),
                this.props.children,
                _react2.default.createElement(_Footer2.default, null)
            );
        }
    }]);

    return App;
}(_react2.default.Component);

exports.default = App;

},{"../actions/UserActions":37,"../stores/UserStore":71,"./Footer":40,"./Navbar":43,"react":"react"}],40:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
    value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _react = require('react');

var _react2 = _interopRequireDefault(_react);

var _reactRouter = require('react-router');

var _MovieActions = require('../actions/MovieActions');

var _MovieActions2 = _interopRequireDefault(_MovieActions);

var _MovieStore = require('../stores/MovieStore');

var _MovieStore2 = _interopRequireDefault(_MovieStore);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var Footer = function (_React$Component) {
    _inherits(Footer, _React$Component);

    function Footer(props) {
        _classCallCheck(this, Footer);

        var _this = _possibleConstructorReturn(this, (Footer.__proto__ || Object.getPrototypeOf(Footer)).call(this, props));

        _this.state = _MovieStore2.default.getState();

        _this.onChange = _this.onChange.bind(_this);
        return _this;
    }

    _createClass(Footer, [{
        key: 'onChange',
        value: function onChange(state) {
            this.setState(state);
        }
    }, {
        key: 'componentDidMount',
        value: function componentDidMount() {
            _MovieStore2.default.listen(this.onChange);

            _MovieActions2.default.getFiveRecentMovies();
            this.interval = setInterval(function () {
                return _MovieActions2.default.getFiveRecentMovies();
            }, 30000);
        }
    }, {
        key: 'componentWillUnmount',
        value: function componentWillUnmount() {
            _MovieStore2.default.unlisten(this.onChange);
            clearInterval(this.interval);
        }
    }, {
        key: 'render',
        value: function render() {
            var mostRecentMovies = this.state.mostRecentMovies.map(function (movie) {
                return _react2.default.createElement(
                    'li',
                    { key: movie._id },
                    _react2.default.createElement(
                        _reactRouter.Link,
                        { to: '/...' },
                        movie.name
                    )
                );
            });

            return _react2.default.createElement(
                'footer',
                null,
                _react2.default.createElement(
                    'div',
                    { className: 'container' },
                    _react2.default.createElement(
                        'div',
                        { className: 'row' },
                        _react2.default.createElement(
                            'div',
                            { className: 'col-sm-5' },
                            _react2.default.createElement(
                                'h3',
                                { className: 'lead' },
                                _react2.default.createElement(
                                    'strong',
                                    null,
                                    'Information'
                                ),
                                ' and',
                                _react2.default.createElement(
                                    'strong',
                                    null,
                                    ' Copyright'
                                )
                            ),
                            _react2.default.createElement(
                                'p',
                                null,
                                'Powered by',
                                _react2.default.createElement(
                                    'strong',
                                    null,
                                    ' Express'
                                ),
                                ',',
                                _react2.default.createElement(
                                    'strong',
                                    null,
                                    ' MongoDB'
                                ),
                                ' and',
                                _react2.default.createElement(
                                    'strong',
                                    null,
                                    ' React'
                                )
                            ),
                            _react2.default.createElement(
                                'p',
                                null,
                                '\xA9 2017 SoftUni.'
                            )
                        ),
                        _react2.default.createElement(
                            'div',
                            { className: 'col-sm-4 hidden-xs' },
                            _react2.default.createElement(
                                'h3',
                                { className: 'lead' },
                                _react2.default.createElement(
                                    'strong',
                                    null,
                                    'Newest'
                                ),
                                '  5 Movies'
                            ),
                            _react2.default.createElement(
                                'ul',
                                { className: 'list-inline' },
                                mostRecentMovies
                            )
                        ),
                        _react2.default.createElement(
                            'div',
                            { className: 'col-sm-3' },
                            _react2.default.createElement(
                                'h3',
                                { className: 'lead' },
                                'Author'
                            ),
                            _react2.default.createElement(
                                'a',
                                { href: 'https://github.com/achobanov' },
                                _react2.default.createElement(
                                    'strong',
                                    null,
                                    ' Alex Chobanov'
                                )
                            )
                        )
                    )
                )
            );
        }
    }]);

    return Footer;
}(_react2.default.Component);

exports.default = Footer;

},{"../actions/MovieActions":34,"../stores/MovieStore":69,"react":"react","react-router":"react-router"}],41:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
    value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _react = require('react');

var _react2 = _interopRequireDefault(_react);

var _MovieActions = require('../actions/MovieActions');

var _MovieActions2 = _interopRequireDefault(_MovieActions);

var _MovieStore = require('../stores/MovieStore');

var _MovieStore2 = _interopRequireDefault(_MovieStore);

var _MovieCard = require('./sub-components/MovieCard');

var _MovieCard2 = _interopRequireDefault(_MovieCard);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var Home = function (_React$Component) {
    _inherits(Home, _React$Component);

    function Home(props) {
        _classCallCheck(this, Home);

        var _this = _possibleConstructorReturn(this, (Home.__proto__ || Object.getPrototypeOf(Home)).call(this, props));

        _this.state = _MovieStore2.default.getState();

        _this.onChange = _this.onChange.bind(_this);
        return _this;
    }

    _createClass(Home, [{
        key: 'onChange',
        value: function onChange(state) {
            this.setState(state);
        }
    }, {
        key: 'componentDidMount',
        value: function componentDidMount() {
            _MovieStore2.default.listen(this.onChange);

            _MovieActions2.default.getTopTenMovies();
        }
    }, {
        key: 'componentWillUnmount',
        value: function componentWillUnmount() {
            _MovieStore2.default.unlisten(this.onChange);
        }
    }, {
        key: 'render',
        value: function render() {
            var movies = this.state.topTenMovies.map(function (movie, index) {
                return _react2.default.createElement(_MovieCard2.default, { key: movie._id,
                    movie: movie,
                    index: index });
            });

            return _react2.default.createElement(
                'div',
                { className: 'container' },
                _react2.default.createElement(
                    'h3',
                    { className: 'text-center' },
                    'Welcome to',
                    _react2.default.createElement(
                        'strong',
                        null,
                        ' Movie Database'
                    )
                ),
                _react2.default.createElement(
                    'div',
                    { className: 'list-group' },
                    movies
                )
            );
        }
    }]);

    return Home;
}(_react2.default.Component);

exports.default = Home;

},{"../actions/MovieActions":34,"../stores/MovieStore":69,"./sub-components/MovieCard":53,"react":"react"}],42:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
    value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _react = require('react');

var _react2 = _interopRequireDefault(_react);

var _MovieAddActions = require('../actions/MovieAddActions');

var _MovieAddActions2 = _interopRequireDefault(_MovieAddActions);

var _MovieAddStore = require('../stores/MovieAddStore');

var _MovieAddStore2 = _interopRequireDefault(_MovieAddStore);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var AddMovie = function (_React$Component) {
    _inherits(AddMovie, _React$Component);

    function AddMovie(props) {
        _classCallCheck(this, AddMovie);

        var _this = _possibleConstructorReturn(this, (AddMovie.__proto__ || Object.getPrototypeOf(AddMovie)).call(this, props));

        _this.state = _MovieAddStore2.default.getState();

        _this.onChange = _this.onChange.bind(_this);
        return _this;
    }

    _createClass(AddMovie, [{
        key: 'onChange',
        value: function onChange(state) {
            this.setState(state);
        }
    }, {
        key: 'componentDidMount',
        value: function componentDidMount() {
            _MovieAddStore2.default.listen(this.onChange);
        }
    }, {
        key: 'componentWillUnmount',
        value: function componentWillUnmount() {
            _MovieAddStore2.default.unlisten(this.onChange);
        }
    }, {
        key: 'handleSubmit',
        value: function handleSubmit(e) {
            e.preventDefault();

            var name = this.state.name.trim();
            var genres = this.state.genres;
            if (!name) {
                _MovieAddActions2.default.nameValidationFail();
            }
            if (genres.length === 0) {
                _MovieAddActions2.default.genresValidationFail();
            }

            if (name) {
                var data = {
                    name: this.state.name,
                    description: this.state.description,
                    genres: this.state.genres
                };
                _MovieAddActions2.default.addMovie(data);
            }
        }
    }, {
        key: 'render',
        value: function render() {
            return _react2.default.createElement(
                'div',
                { className: 'container' },
                _react2.default.createElement(
                    'div',
                    { className: 'row flipInX animated' },
                    _react2.default.createElement(
                        'div',
                        { className: 'col-sm-8' },
                        _react2.default.createElement(
                            'div',
                            { className: 'panel panel-default' },
                            _react2.default.createElement(
                                'div',
                                { className: 'panel-heading' },
                                'Add Movie'
                            ),
                            _react2.default.createElement(
                                'div',
                                { className: 'panel-body' },
                                _react2.default.createElement(
                                    'form',
                                    { onSubmit: this.handleSubmit.bind(this) },
                                    _react2.default.createElement(
                                        'div',
                                        { className: 'form-group ' + this.state.nameValidationState },
                                        _react2.default.createElement(
                                            'label',
                                            { className: 'control-label' },
                                            'Name'
                                        ),
                                        _react2.default.createElement('input', { type: 'text', className: 'form-control', ref: 'nameTextField',
                                            value: this.state.name,
                                            onChange: _MovieAddActions2.default.handleNameChange, autoFocus: true }),
                                        _react2.default.createElement(
                                            'span',
                                            { className: 'help-block' },
                                            this.state.helpBlock
                                        )
                                    ),
                                    _react2.default.createElement(
                                        'div',
                                        { className: 'form-group' },
                                        _react2.default.createElement(
                                            'label',
                                            { className: 'control-label' },
                                            'Description'
                                        ),
                                        _react2.default.createElement('textarea', { className: 'form-control',
                                            rows: '5',
                                            value: this.state.description,
                                            onChange: _MovieAddActions2.default.handleDescriptionChange })
                                    ),
                                    _react2.default.createElement(
                                        'div',
                                        { className: 'form-group ' + this.state.genresValidationState },
                                        _react2.default.createElement(
                                            'div',
                                            { className: 'checkbox checkbox-inline' },
                                            _react2.default.createElement('input', { type: 'checkbox', name: 'genres', id: 'action', value: 'Action',
                                                checked: this.state.genres.indexOf('Action') !== -1,
                                                onChange: _MovieAddActions2.default.handleGenresChange }),
                                            _react2.default.createElement(
                                                'label',
                                                { htmlFor: 'action' },
                                                'Action'
                                            )
                                        ),
                                        _react2.default.createElement(
                                            'div',
                                            { className: 'checkbox checkbox-inline' },
                                            _react2.default.createElement('input', { type: 'checkbox', name: 'genres', id: 'horror', value: 'Horror',
                                                checked: this.state.genres.indexOf('Horror') !== -1,
                                                onChange: _MovieAddActions2.default.handleGenresChange }),
                                            _react2.default.createElement(
                                                'label',
                                                { htmlFor: 'horror' },
                                                'Horror'
                                            )
                                        ),
                                        _react2.default.createElement(
                                            'div',
                                            { className: 'checkbox checkbox-inline' },
                                            _react2.default.createElement('input', { type: 'checkbox', name: 'genres', id: 'sci-fi', value: 'Sci-fi',
                                                checked: this.state.genres.indexOf('Sci-fi') !== -1,
                                                onChange: _MovieAddActions2.default.handleGenresChange }),
                                            _react2.default.createElement(
                                                'label',
                                                { htmlFor: 'sci-fi' },
                                                'Sci-fi'
                                            )
                                        ),
                                        _react2.default.createElement(
                                            'div',
                                            { className: 'checkbox checkbox-inline' },
                                            _react2.default.createElement('input', { type: 'checkbox', name: 'genres', id: 'fantasy', value: 'Fantasy',
                                                checked: this.state.genres.indexOf('Fantasy') !== -1,
                                                onChange: _MovieAddActions2.default.handleGenresChange }),
                                            _react2.default.createElement(
                                                'label',
                                                { htmlFor: 'fantasy' },
                                                'Fantasy'
                                            )
                                        ),
                                        _react2.default.createElement(
                                            'div',
                                            { className: 'checkbox checkbox-inline' },
                                            _react2.default.createElement('input', { type: 'checkbox', name: 'genres', id: 'romance', value: 'Romance',
                                                checked: this.state.genres.indexOf('Romance') !== -1,
                                                onChange: _MovieAddActions2.default.handleGenresChange }),
                                            _react2.default.createElement(
                                                'label',
                                                { htmlFor: 'romance' },
                                                'Romance'
                                            )
                                        ),
                                        _react2.default.createElement(
                                            'div',
                                            { className: 'checkbox checkbox-inline' },
                                            _react2.default.createElement('input', { type: 'checkbox', name: 'genres', id: 'thriller', value: 'Thriller',
                                                checked: this.state.genres.indexOf('Thriller') !== -1,
                                                onChange: _MovieAddActions2.default.handleGenresChange }),
                                            _react2.default.createElement(
                                                'label',
                                                { htmlFor: 'thriller' },
                                                'Thriller'
                                            )
                                        ),
                                        _react2.default.createElement(
                                            'div',
                                            { className: 'checkbox checkbox-inline' },
                                            _react2.default.createElement('input', { type: 'checkbox', name: 'genres', id: 'adventure', value: 'Adventure',
                                                checked: this.state.genres.indexOf('Adventure') !== -1,
                                                onChange: _MovieAddActions2.default.handleGenresChange }),
                                            _react2.default.createElement(
                                                'label',
                                                { htmlFor: 'adventure' },
                                                'Adventure'
                                            )
                                        )
                                    ),
                                    _react2.default.createElement(
                                        'button',
                                        { type: 'submit', className: 'btn btn-primary' },
                                        'Submit'
                                    )
                                )
                            )
                        )
                    )
                )
            );
        }
    }]);

    return AddMovie;
}(_react2.default.Component);

exports.default = AddMovie;

},{"../actions/MovieAddActions":35,"../stores/MovieAddStore":68,"react":"react"}],43:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
    value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _react = require('react');

var _react2 = _interopRequireDefault(_react);

var _reactRouter = require('react-router');

var _NavbarActions = require('../actions/NavbarActions');

var _NavbarActions2 = _interopRequireDefault(_NavbarActions);

var _NavbarStore = require('../stores/NavbarStore');

var _NavbarStore2 = _interopRequireDefault(_NavbarStore);

var _NavbarUserMenu = require('./sub-components/NavbarUserMenu');

var _NavbarUserMenu2 = _interopRequireDefault(_NavbarUserMenu);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var Navbar = function (_React$Component) {
    _inherits(Navbar, _React$Component);

    function Navbar(props) {
        _classCallCheck(this, Navbar);

        var _this = _possibleConstructorReturn(this, (Navbar.__proto__ || Object.getPrototypeOf(Navbar)).call(this, props));

        _this.state = _NavbarStore2.default.getState();

        _this.onChange = _this.onChange.bind(_this);
        return _this;
    }

    _createClass(Navbar, [{
        key: 'onChange',
        value: function onChange(state) {
            this.setState(state);
        }
    }, {
        key: 'componentDidMount',
        value: function componentDidMount() {
            _NavbarStore2.default.listen(this.onChange);

            $(document).ajaxStart(function () {
                return _NavbarActions2.default.updateAjaxAnimation('fadeIn');
            });
            $(document).ajaxComplete(function () {
                return _NavbarActions2.default.updateAjaxAnimation('fadeOut');
            });
        }
    }, {
        key: 'componentWillUnmount',
        value: function componentWillUnmount() {
            _NavbarStore2.default.unlisten(this.onChange);
        }
    }, {
        key: 'render',
        value: function render() {
            var navbarUserMenu = _react2.default.createElement(_NavbarUserMenu2.default, { userData: this.props.userData });
            return _react2.default.createElement(
                'nav',
                { className: 'navbar navbar-default navbar-static-top' },
                _react2.default.createElement(
                    'div',
                    { className: 'navbar-header' },
                    _react2.default.createElement(
                        'button',
                        { type: 'button',
                            className: 'navbar-toggle collapsed',
                            'data-toggle': 'collapse',
                            'data-target': '#navbar' },
                        _react2.default.createElement(
                            'span',
                            { className: 'sr-only' },
                            'Toggle navigation'
                        ),
                        _react2.default.createElement('span', { className: 'icon-bar' }),
                        _react2.default.createElement('span', { className: 'icon-bar' }),
                        _react2.default.createElement('span', { className: 'icon-bar' })
                    ),
                    _react2.default.createElement(
                        _reactRouter.Link,
                        { to: '/', className: 'navbar-brand' },
                        _react2.default.createElement(
                            'span',
                            {
                                ref: 'triangles',
                                className: 'triangles animated ' + this.state.ajaxAnimationClass },
                            _react2.default.createElement('div', { className: 'tri invert' }),
                            _react2.default.createElement('div', { className: 'tri invert' }),
                            _react2.default.createElement('div', { className: 'tri' }),
                            _react2.default.createElement('div', { className: 'tri invert' }),
                            _react2.default.createElement('div', { className: 'tri invert' }),
                            _react2.default.createElement('div', { className: 'tri' }),
                            _react2.default.createElement('div', { className: 'tri invert' }),
                            _react2.default.createElement('div', { className: 'tri' }),
                            _react2.default.createElement('div', { className: 'tri invert' })
                        ),
                        'MDB'
                    )
                ),
                _react2.default.createElement(
                    'div',
                    { id: 'navbar', className: 'navbar-collapse collapse' },
                    _react2.default.createElement(
                        'ul',
                        { className: 'nav navbar-nav' },
                        _react2.default.createElement(
                            'li',
                            null,
                            _react2.default.createElement(
                                _reactRouter.Link,
                                { to: '/' },
                                'Home'
                            )
                        ),
                        _react2.default.createElement(
                            'li',
                            null,
                            _react2.default.createElement(
                                _reactRouter.Link,
                                { to: '/movie/add' },
                                'Add Movie'
                            )
                        )
                    ),
                    navbarUserMenu
                )
            );
        }
    }]);

    return Navbar;
}(_react2.default.Component);

exports.default = Navbar;

},{"../actions/NavbarActions":36,"../stores/NavbarStore":70,"./sub-components/NavbarUserMenu":59,"react":"react","react-router":"react-router"}],44:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
  value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _react = require('react');

var _react2 = _interopRequireDefault(_react);

var _UserActions = require('../actions/UserActions');

var _UserActions2 = _interopRequireDefault(_UserActions);

var _FormActions = require('../actions/FormActions');

var _FormActions2 = _interopRequireDefault(_FormActions);

var _FormStore = require('../stores/FormStore');

var _FormStore2 = _interopRequireDefault(_FormStore);

var _Form = require('./form/Form');

var _Form2 = _interopRequireDefault(_Form);

var _TextGroup = require('./form/TextGroup');

var _TextGroup2 = _interopRequireDefault(_TextGroup);

var _Submit = require('./form/Submit');

var _Submit2 = _interopRequireDefault(_Submit);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var UserLogin = function (_React$Component) {
  _inherits(UserLogin, _React$Component);

  function UserLogin(props) {
    _classCallCheck(this, UserLogin);

    var _this = _possibleConstructorReturn(this, (UserLogin.__proto__ || Object.getPrototypeOf(UserLogin)).call(this, props));

    _this.state = _FormStore2.default.getState();
    _this.onChange = _this.onChange.bind(_this);
    return _this;
  }

  _createClass(UserLogin, [{
    key: 'onChange',
    value: function onChange(state) {
      this.setState(state);
    }
  }, {
    key: 'componentDidMount',
    value: function componentDidMount() {
      _FormStore2.default.listen(this.onChange);
    }
  }, {
    key: 'componentWillUnmount',
    value: function componentWillUnmount() {
      _FormStore2.default.unlisten(this.onChange);
    }
  }, {
    key: 'handleSubmit',
    value: function handleSubmit(e) {
      e.preventDefault();

      var username = this.state.username;
      var password = this.state.password;
      if (!username) {
        _FormActions2.default.usernameValidationFail();
        return;
      }
      if (!password) {
        _FormActions2.default.passwordValidationFail();
        return;
      }

      _UserActions2.default.loginUser({ username: username, password: password });
    }
  }, {
    key: 'render',
    value: function render() {
      return _react2.default.createElement(
        _Form2.default,
        { title: 'Login',
          handleSubmit: this.handleSubmit.bind(this),
          submitState: this.state.formSubmitState,
          message: this.state.message },
        _react2.default.createElement(_TextGroup2.default, { type: 'text',
          value: this.state.username,
          label: 'Username',
          handleChange: _FormActions2.default.handleUsernameChange,
          validationState: this.state.usernameValidationState }),
        _react2.default.createElement(_TextGroup2.default, { type: 'password',
          value: this.state.password,
          label: 'Password',
          handleChange: _FormActions2.default.handlePasswordChange,
          validationState: this.state.passwordValidationState,
          message: this.state.message }),
        _react2.default.createElement(_Submit2.default, { type: 'btn-primary',
          value: 'Login' })
      );
    }
  }]);

  return UserLogin;
}(_react2.default.Component);

exports.default = UserLogin;

},{"../actions/FormActions":33,"../actions/UserActions":37,"../stores/FormStore":67,"./form/Form":47,"./form/Submit":50,"./form/TextGroup":51,"react":"react"}],45:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
    value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _react = require('react');

var _react2 = _interopRequireDefault(_react);

var _UserStore = require('../stores/UserStore');

var _UserStore2 = _interopRequireDefault(_UserStore);

var _UserInfo = require('./sub-components/UserInfo');

var _UserInfo2 = _interopRequireDefault(_UserInfo);

var _UserRatedMovies = require('./sub-components/UserRatedMovies');

var _UserRatedMovies2 = _interopRequireDefault(_UserRatedMovies);

var _UserReviews = require('./sub-components/UserReviews');

var _UserReviews2 = _interopRequireDefault(_UserReviews);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var UserProfile = function (_React$Component) {
    _inherits(UserProfile, _React$Component);

    function UserProfile(props) {
        _classCallCheck(this, UserProfile);

        var _this = _possibleConstructorReturn(this, (UserProfile.__proto__ || Object.getPrototypeOf(UserProfile)).call(this, props));

        _this.state = _UserStore2.default.getState();

        _this.onChange = _this.onChange.bind(_this);
        return _this;
    }

    _createClass(UserProfile, [{
        key: 'onChange',
        value: function onChange(state) {
            this.setState(state);
        }
    }, {
        key: 'componentDidMount',
        value: function componentDidMount() {
            _UserStore2.default.listen(this.onChange);
        }
    }, {
        key: 'componentWillUnmount',
        value: function componentWillUnmount() {
            _UserStore2.default.unlisten(this.onChange);
        }
    }, {
        key: 'render',
        value: function render() {
            var nodes = {};
            nodes.roles = this.state.roles.map(function (role, index) {
                return _react2.default.createElement(
                    'h4',
                    { key: index, className: 'lead' },
                    _react2.default.createElement(
                        'strong',
                        null,
                        role
                    )
                );
            });

            return _react2.default.createElement(
                'div',
                null,
                _react2.default.createElement(_UserInfo2.default, { name: this.state.name,
                    roles: this.state.roles,
                    information: this.state.information }),
                _react2.default.createElement(_UserRatedMovies2.default, { votes: this.state.votes }),
                _react2.default.createElement(_UserReviews2.default, { reviews: this.props.reviews })
            );
        }
    }]);

    return UserProfile;
}(_react2.default.Component);

exports.default = UserProfile;

},{"../stores/UserStore":71,"./sub-components/UserInfo":60,"./sub-components/UserRatedMovies":61,"./sub-components/UserReviews":63,"react":"react"}],46:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
  value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _react = require('react');

var _react2 = _interopRequireDefault(_react);

var _FormActions = require('../actions/FormActions');

var _FormActions2 = _interopRequireDefault(_FormActions);

var _UserActions = require('../actions/UserActions');

var _UserActions2 = _interopRequireDefault(_UserActions);

var _FormStore = require('../stores/FormStore');

var _FormStore2 = _interopRequireDefault(_FormStore);

var _Form = require('./form/Form');

var _Form2 = _interopRequireDefault(_Form);

var _TextGroup = require('./form/TextGroup');

var _TextGroup2 = _interopRequireDefault(_TextGroup);

var _RadioGroup = require('./form/RadioGroup');

var _RadioGroup2 = _interopRequireDefault(_RadioGroup);

var _RadioElement = require('./form/RadioElement');

var _RadioElement2 = _interopRequireDefault(_RadioElement);

var _Submit = require('./form/Submit');

var _Submit2 = _interopRequireDefault(_Submit);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var UserRegister = function (_React$Component) {
  _inherits(UserRegister, _React$Component);

  function UserRegister(props) {
    _classCallCheck(this, UserRegister);

    var _this = _possibleConstructorReturn(this, (UserRegister.__proto__ || Object.getPrototypeOf(UserRegister)).call(this, props));

    _this.state = _FormStore2.default.getState();
    _this.onChange = _this.onChange.bind(_this);
    return _this;
  }

  _createClass(UserRegister, [{
    key: 'onChange',
    value: function onChange(state) {
      this.setState(state);
    }
  }, {
    key: 'componentDidMount',
    value: function componentDidMount() {
      _FormStore2.default.listen(this.onChange);
    }
  }, {
    key: 'componentWillUnmount',
    value: function componentWillUnmount() {
      _FormStore2.default.unlisten(this.onChange);
    }
  }, {
    key: 'handleSubmit',
    value: function handleSubmit(e) {
      e.preventDefault();
      var data = {
        username: this.state.username,
        password: this.state.password,
        confirmedPassword: this.state.confirmedPassword,
        firstName: this.state.firstName,
        lastName: this.state.lastName,
        age: this.state.age,
        gender: this.state.gender
      };
      if (!data.username) {
        return _FormActions2.default.usernameValidationFail();
      }
      if (!data.password || !data.confirmedPassword || data.password !== data.confirmedPassword) {
        return _FormActions2.default.passwordValidationFail();
      }
      _UserActions2.default.registerUser(data);
    }
  }, {
    key: 'render',
    value: function render() {
      return _react2.default.createElement(
        _Form2.default,
        { title: 'Register',
          handleSubmit: this.handleSubmit.bind(this),
          submitState: this.state.formSubmitState,
          message: this.state.message },
        _react2.default.createElement(_TextGroup2.default, { type: 'text',
          label: 'Username',
          value: this.state.username,
          autoFocus: true,
          handleChange: _FormActions2.default.handleUsernameChange,
          validationState: this.state.usernameValidationState,
          message: this.state.message }),
        _react2.default.createElement(_TextGroup2.default, { type: 'password',
          label: 'Password',
          value: this.state.Password,
          handleChange: _FormActions2.default.handlePasswordChange,
          validationState: this.state.passwordValidationState,
          message: this.state.message }),
        _react2.default.createElement(_TextGroup2.default, { type: 'password',
          label: 'Confirm Password',
          value: this.state.confirmPassword,
          handleChange: _FormActions2.default.handleConfirmedPasswordChange,
          validationState: this.state.passwordValidationState,
          message: this.state.message }),
        _react2.default.createElement(_TextGroup2.default, { type: 'text',
          label: 'First Name',
          handleChange: _FormActions2.default.handleFirstNameChange,
          value: this.state.firstName }),
        _react2.default.createElement(_TextGroup2.default, { type: 'text',
          label: 'Last Name',
          handleChange: _FormActions2.default.handleLastNameChange,
          value: this.state.lastName }),
        _react2.default.createElement(_TextGroup2.default, { type: 'number',
          label: 'Age',
          handleChange: _FormActions2.default.handleAgeChange,
          value: this.state.age }),
        _react2.default.createElement(
          _RadioGroup2.default,
          { validationState: this.state.genderValidationState,
            message: this.state.message },
          _react2.default.createElement(_RadioElement2.default, { groupName: 'gender',
            value: 'Male',
            selectedValue: this.state.gender,
            handleChange: _FormActions2.default.handleGenderChange }),
          _react2.default.createElement(_RadioElement2.default, { groupName: 'gender',
            value: 'Female',
            selectedValue: this.state.gender,
            handleChange: _FormActions2.default.handleGenderChange })
        ),
        _react2.default.createElement(_Submit2.default, { type: 'btn-primary', value: 'Register' })
      );
    }
  }]);

  return UserRegister;
}(_react2.default.Component);

exports.default = UserRegister;

},{"../actions/FormActions":33,"../actions/UserActions":37,"../stores/FormStore":67,"./form/Form":47,"./form/RadioElement":48,"./form/RadioGroup":49,"./form/Submit":50,"./form/TextGroup":51,"react":"react"}],47:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
  value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _react = require('react');

var _react2 = _interopRequireDefault(_react);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var Form = function (_React$Component) {
  _inherits(Form, _React$Component);

  function Form() {
    _classCallCheck(this, Form);

    return _possibleConstructorReturn(this, (Form.__proto__ || Object.getPrototypeOf(Form)).apply(this, arguments));
  }

  _createClass(Form, [{
    key: 'render',
    value: function render() {
      return _react2.default.createElement(
        'div',
        { className: 'container' },
        _react2.default.createElement(
          'div',
          { className: 'row flipInX animated' },
          _react2.default.createElement(
            'div',
            { className: 'col-sm-8' },
            _react2.default.createElement(
              'div',
              { className: 'panel panel-default' },
              _react2.default.createElement(
                'div',
                { className: 'panel-heading' },
                this.props.title
              ),
              _react2.default.createElement(
                'div',
                { className: 'panel-body' },
                _react2.default.createElement(
                  'form',
                  { onSubmit: this.props.handleSubmit },
                  _react2.default.createElement(
                    'div',
                    { className: 'form-group ' + this.props.submitState },
                    _react2.default.createElement(
                      'span',
                      { className: 'help-block' },
                      this.props.message
                    )
                  ),
                  this.props.children
                )
              )
            )
          )
        )
      );
    }
  }]);

  return Form;
}(_react2.default.Component);

exports.default = Form;

},{"react":"react"}],48:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
  value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _react = require('react');

var _react2 = _interopRequireDefault(_react);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var RadioElement = function (_React$Component) {
  _inherits(RadioElement, _React$Component);

  function RadioElement() {
    _classCallCheck(this, RadioElement);

    return _possibleConstructorReturn(this, (RadioElement.__proto__ || Object.getPrototypeOf(RadioElement)).apply(this, arguments));
  }

  _createClass(RadioElement, [{
    key: 'render',
    value: function render() {
      return _react2.default.createElement(
        'div',
        { className: 'radio radio-inline' },
        _react2.default.createElement('input', { type: 'radio',
          name: this.props.groupName,
          id: this.props.value.toLowerCase(),
          value: this.props.value,
          checked: this.props.selectedValue === this.props.value,
          onChange: this.props.handleChange }),
        _react2.default.createElement(
          'label',
          { htmlFor: this.props.value.toLowerCase() },
          this.props.value
        )
      );
    }
  }]);

  return RadioElement;
}(_react2.default.Component);

exports.default = RadioElement;

},{"react":"react"}],49:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
  value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _react = require('react');

var _react2 = _interopRequireDefault(_react);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var RadioGroup = function (_React$Component) {
  _inherits(RadioGroup, _React$Component);

  function RadioGroup() {
    _classCallCheck(this, RadioGroup);

    return _possibleConstructorReturn(this, (RadioGroup.__proto__ || Object.getPrototypeOf(RadioGroup)).apply(this, arguments));
  }

  _createClass(RadioGroup, [{
    key: 'render',
    value: function render() {
      return _react2.default.createElement(
        'div',
        { className: 'form-group ' + this.props.validationState },
        _react2.default.createElement(
          'span',
          { className: 'help-block' },
          this.props.message
        ),
        this.props.children
      );
    }
  }]);

  return RadioGroup;
}(_react2.default.Component);

exports.default = RadioGroup;

},{"react":"react"}],50:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
  value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _react = require('react');

var _react2 = _interopRequireDefault(_react);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var Submit = function (_React$Component) {
  _inherits(Submit, _React$Component);

  function Submit() {
    _classCallCheck(this, Submit);

    return _possibleConstructorReturn(this, (Submit.__proto__ || Object.getPrototypeOf(Submit)).apply(this, arguments));
  }

  _createClass(Submit, [{
    key: 'render',
    value: function render() {
      return _react2.default.createElement('input', { type: 'submit', className: 'btn ' + this.props.type, value: this.props.value });
    }
  }]);

  return Submit;
}(_react2.default.Component);

exports.default = Submit;

},{"react":"react"}],51:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
  value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _react = require('react');

var _react2 = _interopRequireDefault(_react);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var TextGroup = function (_React$Component) {
  _inherits(TextGroup, _React$Component);

  function TextGroup() {
    _classCallCheck(this, TextGroup);

    return _possibleConstructorReturn(this, (TextGroup.__proto__ || Object.getPrototypeOf(TextGroup)).apply(this, arguments));
  }

  _createClass(TextGroup, [{
    key: 'render',
    value: function render() {
      return _react2.default.createElement(
        'div',
        { className: 'form-group ' + this.props.validationState },
        _react2.default.createElement(
          'label',
          { className: 'control-label' },
          this.props.label
        ),
        _react2.default.createElement('input', { type: this.props.type, className: 'form-control',
          value: this.props.value,
          onChange: this.props.handleChange, autoFocus: this.props.autoFocus }),
        _react2.default.createElement(
          'span',
          { className: 'help-block' },
          this.props.message
        )
      );
    }
  }]);

  return TextGroup;
}(_react2.default.Component);

exports.default = TextGroup;

},{"react":"react"}],52:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
  value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _react = require('react');

var _react2 = _interopRequireDefault(_react);

var _FormStore = require('../../stores/FormStore');

var _FormStore2 = _interopRequireDefault(_FormStore);

var _FormActions = require('../../actions/FormActions');

var _FormActions2 = _interopRequireDefault(_FormActions);

var _MovieActions = require('../../actions/MovieActions');

var _MovieActions2 = _interopRequireDefault(_MovieActions);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var MovieCommentsPanelForm = function (_React$Component) {
  _inherits(MovieCommentsPanelForm, _React$Component);

  function MovieCommentsPanelForm(props) {
    _classCallCheck(this, MovieCommentsPanelForm);

    var _this = _possibleConstructorReturn(this, (MovieCommentsPanelForm.__proto__ || Object.getPrototypeOf(MovieCommentsPanelForm)).call(this, props));

    _this.state = _FormStore2.default.getState();
    _this.onChange = _this.onChange.bind(_this);
    return _this;
  }

  _createClass(MovieCommentsPanelForm, [{
    key: 'onChange',
    value: function onChange(state) {
      this.setState(state);
    }
  }, {
    key: 'componentDidMount',
    value: function componentDidMount() {
      _FormStore2.default.listen(this.onChange);
    }
  }, {
    key: 'componentWillUnmount',
    value: function componentWillUnmount() {
      _FormStore2.default.unlisten(this.onChange);
    }
  }, {
    key: 'handleSubmit',
    value: function handleSubmit(e) {
      e.preventDefault();

      if (!this.state.comment) {
        _FormActions2.default.commentValidationFail();
        return;
      }

      _MovieActions2.default.addComment(this.props.movieId, this.state.comment);
    }
  }, {
    key: 'render',
    value: function render() {
      return _react2.default.createElement(
        'form',
        { onSubmit: this.handleSubmit.bind(this) },
        _react2.default.createElement(
          'div',
          { className: 'form-group ' + this.state.commentValidationState },
          _react2.default.createElement(
            'label',
            { className: 'control-label', htmlFor: 'content' },
            'Add comment'
          ),
          _react2.default.createElement('textarea', { id: 'content',
            className: 'form-control',
            value: this.state.comment,
            onChange: _FormActions2.default.handleCommentChange,
            rows: '5' }),
          _react2.default.createElement(
            'span',
            { className: 'help-block' },
            this.state.message
          )
        ),
        _react2.default.createElement(
          'div',
          { className: 'form-group' },
          _react2.default.createElement('input', { type: 'submit', className: 'btn btn-primary', value: 'Comment' })
        )
      );
    }
  }]);

  return MovieCommentsPanelForm;
}(_react2.default.Component);

exports.default = MovieCommentsPanelForm;

},{"../../actions/FormActions":33,"../../actions/MovieActions":34,"../../stores/FormStore":67,"react":"react"}],53:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
    value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _react = require('react');

var _react2 = _interopRequireDefault(_react);

var _MoviePoster = require('./MoviePoster');

var _MoviePoster2 = _interopRequireDefault(_MoviePoster);

var _MovieInfo = require('./MovieInfo');

var _MovieInfo2 = _interopRequireDefault(_MovieInfo);

var _MoviePanelsToggle = require('./MoviePanelsToggle');

var _MoviePanelsToggle2 = _interopRequireDefault(_MoviePanelsToggle);

var _MovieVotePanel = require('./MovieVotePanel');

var _MovieVotePanel2 = _interopRequireDefault(_MovieVotePanel);

var _MovieCommentsPanel = require('./MovieCommentsPanel');

var _MovieCommentsPanel2 = _interopRequireDefault(_MovieCommentsPanel);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var MovieCard = function (_React$Component) {
    _inherits(MovieCard, _React$Component);

    function MovieCard(props) {
        _classCallCheck(this, MovieCard);

        var _this = _possibleConstructorReturn(this, (MovieCard.__proto__ || Object.getPrototypeOf(MovieCard)).call(this, props));

        _this.state = {
            showVotePanel: false,
            showCommentsPanel: false
        };
        return _this;
    }

    _createClass(MovieCard, [{
        key: 'toggleCommentsPanel',
        value: function toggleCommentsPanel() {
            this.setState(function (prevState) {
                return {
                    showCommentsPanel: !prevState.showCommentsPanel,
                    showVotePanel: false
                };
            });
        }
    }, {
        key: 'toggleVotePanel',
        value: function toggleVotePanel() {
            this.setState(function (prevState) {
                return {
                    showVotePanel: !prevState.showVotePanel,
                    showCommentsPanel: false
                };
            });
        }
    }, {
        key: 'render',
        value: function render() {
            return _react2.default.createElement(
                'div',
                { className: 'animated fadeIn' },
                _react2.default.createElement(
                    'div',
                    { className: 'media movie' },
                    _react2.default.createElement(
                        'span',
                        { className: 'position pull-left' },
                        this.props.index + 1
                    ),
                    _react2.default.createElement(_MoviePoster2.default, { posterUrl: this.props.movie.moviePosterUrl }),
                    _react2.default.createElement(_MovieInfo2.default, { movie: this.props.movie }),
                    _react2.default.createElement(_MoviePanelsToggle2.default, { toggleCommentsPanel: this.toggleCommentsPanel.bind(this),
                        toggleVotePanel: this.toggleVotePanel.bind(this),
                        showCommentsPanel: this.state.showCommentsPanel,
                        showVotePanel: this.state.showVotePanel,
                        movieId: this.props.movie._id })
                ),
                this.state.showVotePanel ? _react2.default.createElement(_MovieVotePanel2.default, { movieId: this.props.movie._id }) : null,
                this.state.showCommentsPanel ? _react2.default.createElement(_MovieCommentsPanel2.default, { comments: this.props.movie.comments, movieId: this.props.movie._id }) : null,
                _react2.default.createElement('div', { id: 'clear' })
            );
        }
    }]);

    return MovieCard;
}(_react2.default.Component);

exports.default = MovieCard;

},{"./MovieCommentsPanel":54,"./MovieInfo":55,"./MoviePanelsToggle":56,"./MoviePoster":57,"./MovieVotePanel":58,"react":"react"}],54:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
    value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _react = require('react');

var _react2 = _interopRequireDefault(_react);

var _CommentForm = require('./CommentForm');

var _CommentForm2 = _interopRequireDefault(_CommentForm);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var MovieCommentsPanel = function (_React$Component) {
    _inherits(MovieCommentsPanel, _React$Component);

    function MovieCommentsPanel() {
        _classCallCheck(this, MovieCommentsPanel);

        return _possibleConstructorReturn(this, (MovieCommentsPanel.__proto__ || Object.getPrototypeOf(MovieCommentsPanel)).apply(this, arguments));
    }

    _createClass(MovieCommentsPanel, [{
        key: 'render',
        value: function render() {
            var comments = this.props.comments.map(function (comment) {
                return _react2.default.createElement(
                    'div',
                    { key: comment._id, className: 'comment col-sm-9 list-group-item animated fadeIn' },
                    _react2.default.createElement(
                        'div',
                        { className: 'media' },
                        _react2.default.createElement(
                            'div',
                            { className: 'media-body' },
                            _react2.default.createElement(
                                'p',
                                null,
                                comment.content
                            )
                        )
                    )
                );
            });

            return _react2.default.createElement(
                'div',
                { className: 'list-group' },
                _react2.default.createElement(
                    'h3',
                    { className: 'col-sm-3' },
                    'Comments:'
                ),
                comments,
                _react2.default.createElement(
                    'div',
                    { className: 'col-sm-6 col-xs-offset-6 list-group-item animated fadeIn' },
                    _react2.default.createElement(
                        'div',
                        { className: 'media' },
                        _react2.default.createElement(_CommentForm2.default, { movieId: this.props.movieId })
                    )
                )
            );
        }
    }]);

    return MovieCommentsPanel;
}(_react2.default.Component);

exports.default = MovieCommentsPanel;

},{"./CommentForm":52,"react":"react"}],55:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
    value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _react = require('react');

var _react2 = _interopRequireDefault(_react);

var _reactRouter = require('react-router');

var _Helpers = require('../../utilities/Helpers');

var _Helpers2 = _interopRequireDefault(_Helpers);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var MovieInfo = function (_React$Component) {
    _inherits(MovieInfo, _React$Component);

    function MovieInfo() {
        _classCallCheck(this, MovieInfo);

        return _possibleConstructorReturn(this, (MovieInfo.__proto__ || Object.getPrototypeOf(MovieInfo)).apply(this, arguments));
    }

    _createClass(MovieInfo, [{
        key: 'render',
        value: function render() {
            var _this2 = this;

            var genres = this.props.movie.genres.map(function (genre) {
                return _react2.default.createElement(
                    'strong',
                    { key: _this2.props.movie._id + genre },
                    genre,
                    ' '
                );
            });
            var rating = _Helpers2.default.formatMovieRating(this.props.movie.score, this.props.movie.votes);

            return _react2.default.createElement(
                'div',
                { className: 'media-body' },
                _react2.default.createElement(
                    'h4',
                    { className: 'media-heading' },
                    _react2.default.createElement(
                        _reactRouter.Link,
                        { to: '/movie/' + this.props.movie._id + '/' + this.props.movie.name },
                        this.props.movie.name
                    )
                ),
                _react2.default.createElement(
                    'small',
                    null,
                    'Genres: ',
                    genres
                ),
                _react2.default.createElement('br', null),
                _react2.default.createElement(
                    'p',
                    null,
                    this.props.movie.description
                ),
                _react2.default.createElement(
                    'span',
                    { className: 'votes' },
                    'Votes:',
                    _react2.default.createElement(
                        'strong',
                        null,
                        ' ',
                        this.props.movie.votes
                    )
                ),
                _react2.default.createElement(
                    'span',
                    { className: 'rating position pull-right' },
                    rating,
                    _react2.default.createElement(
                        'span',
                        { className: 'badge badge-up' },
                        this.props.movie.loggedInUserScore
                    )
                )
            );
        }
    }]);

    return MovieInfo;
}(_react2.default.Component);

exports.default = MovieInfo;

},{"../../utilities/Helpers":73,"react":"react","react-router":"react-router"}],56:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
    value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _react = require('react');

var _react2 = _interopRequireDefault(_react);

var _reactRouter = require('react-router');

var _Authorize = require('../../utilities/Authorize');

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var VoteToggle = function (_React$Component) {
    _inherits(VoteToggle, _React$Component);

    function VoteToggle() {
        _classCallCheck(this, VoteToggle);

        return _possibleConstructorReturn(this, (VoteToggle.__proto__ || Object.getPrototypeOf(VoteToggle)).apply(this, arguments));
    }

    _createClass(VoteToggle, [{
        key: 'render',
        value: function render() {
            return _react2.default.createElement(
                'a',
                { className: 'btn btn-primary',
                    onClick: this.props.toggleVotePanel },
                this.props.showVotePanel ? 'Hide' : 'Vote'
            );
        }
    }]);

    return VoteToggle;
}(_react2.default.Component);

var MoviePanelToggles = function (_React$Component2) {
    _inherits(MoviePanelToggles, _React$Component2);

    function MoviePanelToggles() {
        _classCallCheck(this, MoviePanelToggles);

        return _possibleConstructorReturn(this, (MoviePanelToggles.__proto__ || Object.getPrototypeOf(MoviePanelToggles)).apply(this, arguments));
    }

    _createClass(MoviePanelToggles, [{
        key: 'render',
        value: function render() {
            return _react2.default.createElement(
                'div',
                { className: 'pull-right btn-group' },
                _react2.default.createElement(
                    'a',
                    { className: 'btn btn-primary',
                        onClick: this.props.toggleCommentsPanel },
                    this.props.showCommentsPanel ? 'Hide' : 'Comments'
                ),
                _react2.default.createElement(_Authorize.Concealer, { ChildComponent: VoteToggle,
                    toggleVotePanel: this.props.toggleVotePanel,
                    showVotePanel: this.props.showVotePanel }),
                _react2.default.createElement(
                    _reactRouter.Link,
                    { to: '/movie/' + this.props.movieId + '/review/add', className: 'btn btn-warning' },
                    'Write review'
                )
            );
        }
    }]);

    return MoviePanelToggles;
}(_react2.default.Component);

exports.default = MoviePanelToggles;

},{"../../utilities/Authorize":72,"react":"react","react-router":"react-router"}],57:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
    value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _react = require('react');

var _react2 = _interopRequireDefault(_react);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var MoviePoster = function (_React$Component) {
    _inherits(MoviePoster, _React$Component);

    function MoviePoster(props) {
        _classCallCheck(this, MoviePoster);

        return _possibleConstructorReturn(this, (MoviePoster.__proto__ || Object.getPrototypeOf(MoviePoster)).call(this, props));
    }

    _createClass(MoviePoster, [{
        key: 'render',
        value: function render() {
            var poster = void 0;
            if (this.props.posterUrl) {
                poster = _react2.default.createElement(
                    'div',
                    { className: 'pull-left thumb-lg' },
                    _react2.default.createElement('img', { className: 'media-object', src: this.props.posterUrl })
                );
            }

            return poster;
        }
    }]);

    return MoviePoster;
}(_react2.default.Component);

exports.default = MoviePoster;

},{"react":"react"}],58:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
    value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _react = require('react');

var _react2 = _interopRequireDefault(_react);

var _FormActions = require('../../actions/FormActions');

var _FormActions2 = _interopRequireDefault(_FormActions);

var _MovieActions = require('../../actions/MovieActions');

var _MovieActions2 = _interopRequireDefault(_MovieActions);

var _FormStore = require('../../stores/FormStore');

var _FormStore2 = _interopRequireDefault(_FormStore);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var MovieVotePanel = function (_React$Component) {
    _inherits(MovieVotePanel, _React$Component);

    function MovieVotePanel(props) {
        _classCallCheck(this, MovieVotePanel);

        var _this = _possibleConstructorReturn(this, (MovieVotePanel.__proto__ || Object.getPrototypeOf(MovieVotePanel)).call(this, props));

        _this.state = _FormStore2.default.getState();
        _this.onChange = _this.onChange.bind(_this);
        return _this;
    }

    _createClass(MovieVotePanel, [{
        key: 'onChange',
        value: function onChange(state) {
            this.setState(state);
        }
    }, {
        key: 'componentWillMount',
        value: function componentWillMount() {
            _FormStore2.default.listen(this.onChange);
        }
    }, {
        key: 'componentWillUnmount',
        value: function componentWillUnmount() {
            _FormStore2.default.unlisten(this.onChange);
        }
    }, {
        key: 'handleSubmit',
        value: function handleSubmit(e) {
            e.preventDefault();

            if (this.state.score > 10) {
                _FormActions2.default.scoreValidationFail();
                return;
            }

            _MovieActions2.default.addVote(this.props.movieId, this.state.score);
        }
    }, {
        key: 'render',
        value: function render() {
            return _react2.default.createElement(
                'div',
                { className: 'col-sm-4 col-xs-offset-8 list-group-item animated fadeIn vote' },
                _react2.default.createElement(
                    'div',
                    { className: 'media' },
                    _react2.default.createElement(
                        'div',
                        { className: 'media-body' },
                        _react2.default.createElement(
                            'div',
                            { className: 'form-group ' + this.state.scoreValidationState },
                            _react2.default.createElement(
                                'span',
                                { className: 'help-block' },
                                this.state.message
                            )
                        ),
                        _react2.default.createElement(
                            'form',
                            { className: 'form-inline', onSubmit: this.handleSubmit.bind(this) },
                            _react2.default.createElement(
                                'div',
                                { className: 'form-group ' + this.state.scoreValidationState },
                                _react2.default.createElement(
                                    'label',
                                    { className: 'control-label' },
                                    'Score'
                                ),
                                _react2.default.createElement('input', { className: 'form-control',
                                    step: '0.1',
                                    type: 'number',
                                    value: this.state.score || this.props.loggedInUserScore,
                                    onChange: _FormActions2.default.handleScoreChange }),
                                _react2.default.createElement('input', { className: 'btn btn-primary', type: 'submit', value: 'Vote' })
                            )
                        )
                    )
                )
            );
        }
    }]);

    return MovieVotePanel;
}(_react2.default.Component);

exports.default = MovieVotePanel;

},{"../../actions/FormActions":33,"../../actions/MovieActions":34,"../../stores/FormStore":67,"react":"react"}],59:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
    value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _react = require('react');

var _react2 = _interopRequireDefault(_react);

var _reactRouter = require('react-router');

var _UserActions = require('../../actions/UserActions');

var _UserActions2 = _interopRequireDefault(_UserActions);

var _UserStore = require('../../stores/UserStore');

var _UserStore2 = _interopRequireDefault(_UserStore);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var NavbarUserMenu = function (_React$Component) {
    _inherits(NavbarUserMenu, _React$Component);

    function NavbarUserMenu(props) {
        _classCallCheck(this, NavbarUserMenu);

        var _this = _possibleConstructorReturn(this, (NavbarUserMenu.__proto__ || Object.getPrototypeOf(NavbarUserMenu)).call(this, props));

        _this.state = _UserStore2.default.getState();

        _this.onChange = _this.onChange.bind(_this);
        return _this;
    }

    _createClass(NavbarUserMenu, [{
        key: 'onChange',
        value: function onChange(state) {
            this.setState(state);
        }
    }, {
        key: 'componentDidMount',
        value: function componentDidMount() {
            _UserStore2.default.listen(this.onChange);
        }
    }, {
        key: 'componentWillUnmount',
        value: function componentWillUnmount() {
            _UserStore2.default.unlisten(this.onChange);
        }
    }, {
        key: 'render',
        value: function render() {
            var userMenu = void 0;
            if (!this.state.loggedInUserId) {
                userMenu = _react2.default.createElement(
                    'ul',
                    { className: 'nav navbar-nav pull-right' },
                    _react2.default.createElement(
                        'li',
                        null,
                        _react2.default.createElement(
                            _reactRouter.Link,
                            { to: '/user/login' },
                            'Login'
                        )
                    ),
                    _react2.default.createElement(
                        'li',
                        null,
                        _react2.default.createElement(
                            _reactRouter.Link,
                            { to: '/user/register' },
                            'Register'
                        )
                    )
                );
            } else {
                userMenu = _react2.default.createElement(
                    'ul',
                    { className: 'nav navbar-nav pull-right' },
                    _react2.default.createElement(
                        'li',
                        null,
                        _react2.default.createElement(
                            _reactRouter.Link,
                            { to: '/user/profile/' + this.state.loggedInUserId },
                            'Profile'
                        )
                    ),
                    _react2.default.createElement(
                        'li',
                        null,
                        _react2.default.createElement(
                            'a',
                            { href: '#', onClick: _UserActions2.default.logoutUser },
                            'Logout'
                        )
                    )
                );
            }

            return _react2.default.createElement(
                'div',
                null,
                userMenu
            );
        }
    }]);

    return NavbarUserMenu;
}(_react2.default.Component);

exports.default = NavbarUserMenu;

},{"../../actions/UserActions":37,"../../stores/UserStore":71,"react":"react","react-router":"react-router"}],60:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
    value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _react = require('react');

var _react2 = _interopRequireDefault(_react);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var UserProfileInfo = function (_React$Component) {
    _inherits(UserProfileInfo, _React$Component);

    function UserProfileInfo(props) {
        _classCallCheck(this, UserProfileInfo);

        return _possibleConstructorReturn(this, (UserProfileInfo.__proto__ || Object.getPrototypeOf(UserProfileInfo)).call(this, props));
    }

    _createClass(UserProfileInfo, [{
        key: 'render',
        value: function render() {
            var roles = void 0;
            if (this.props.roles) {
                roles = this.props.roles.map(function (role, index) {
                    return _react2.default.createElement(
                        'h4',
                        { key: index, className: 'lead' },
                        _react2.default.createElement(
                            'strong',
                            null,
                            role
                        )
                    );
                });
            }

            return _react2.default.createElement(
                'div',
                { className: 'container profile-container' },
                _react2.default.createElement(
                    'div',
                    { className: 'profile-img' },
                    _react2.default.createElement('img', { src: '/images/user-default.png' })
                ),
                _react2.default.createElement(
                    'div',
                    { className: 'profile-info clearfix' },
                    _react2.default.createElement(
                        'h2',
                        null,
                        _react2.default.createElement(
                            'strong',
                            null,
                            this.props.name
                        )
                    ),
                    _react2.default.createElement(
                        'h4',
                        { className: 'lead' },
                        'Roles:'
                    ),
                    roles,
                    _react2.default.createElement(
                        'p',
                        null,
                        this.props.information
                    )
                )
            );
        }
    }]);

    return UserProfileInfo;
}(_react2.default.Component);

exports.default = UserProfileInfo;

},{"react":"react"}],61:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
    value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _react = require('react');

var _react2 = _interopRequireDefault(_react);

var _UserRatedMoviesPanel = require('./UserRatedMoviesPanel');

var _UserRatedMoviesPanel2 = _interopRequireDefault(_UserRatedMoviesPanel);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var UserVotedMovies = function (_React$Component) {
    _inherits(UserVotedMovies, _React$Component);

    function UserVotedMovies(props) {
        _classCallCheck(this, UserVotedMovies);

        var _this = _possibleConstructorReturn(this, (UserVotedMovies.__proto__ || Object.getPrototypeOf(UserVotedMovies)).call(this, props));

        _this.state = {
            showRatedMoviesPanel: false
        };
        return _this;
    }

    _createClass(UserVotedMovies, [{
        key: 'toggleRatedMovies',
        value: function toggleRatedMovies() {
            this.setState(function (prevState) {
                return {
                    showRatedMoviesPanel: !prevState.showRatedMoviesPanel
                };
            });
        }
    }, {
        key: 'render',
        value: function render() {
            return _react2.default.createElement(
                'div',
                { className: 'container profile-container' },
                _react2.default.createElement(
                    'div',
                    { className: 'profile-stats clearfix' },
                    _react2.default.createElement(
                        'ul',
                        null,
                        _react2.default.createElement(
                            'li',
                            null,
                            _react2.default.createElement(
                                'span',
                                { className: 'stats-number' },
                                this.props.votes ? this.props.votes.length : 0
                            ),
                            'Votes'
                        )
                    )
                ),
                _react2.default.createElement(
                    'div',
                    { className: 'pull-right btn-group' },
                    _react2.default.createElement(
                        'a',
                        { className: 'btn btn-primary', onClick: this.toggleRatedMovies.bind(this) },
                        this.state.showRatedMoviesPanel ? 'Hide' : 'Rated Movies'
                    )
                ),
                this.state.showRatedMoviesPanel ? _react2.default.createElement(_UserRatedMoviesPanel2.default, { movies: this.props.votes }) : null
            );
        }
    }]);

    return UserVotedMovies;
}(_react2.default.Component);

exports.default = UserVotedMovies;

},{"./UserRatedMoviesPanel":62,"react":"react"}],62:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
    value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _react = require('react');

var _react2 = _interopRequireDefault(_react);

var _MovieCard = require('./MovieCard');

var _MovieCard2 = _interopRequireDefault(_MovieCard);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var UserVotedMoviesPanel = function (_React$Component) {
    _inherits(UserVotedMoviesPanel, _React$Component);

    function UserVotedMoviesPanel(props) {
        _classCallCheck(this, UserVotedMoviesPanel);

        return _possibleConstructorReturn(this, (UserVotedMoviesPanel.__proto__ || Object.getPrototypeOf(UserVotedMoviesPanel)).call(this, props));
    }

    _createClass(UserVotedMoviesPanel, [{
        key: 'render',
        value: function render() {
            return _react2.default.createElement(
                'div',
                { className: 'list-group' },
                'Hello from UserRatedMoviesPanel'
            );
        }
    }]);

    return UserVotedMoviesPanel;
}(_react2.default.Component);

exports.default = UserVotedMoviesPanel;

},{"./MovieCard":53,"react":"react"}],63:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
    value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _react = require('react');

var _react2 = _interopRequireDefault(_react);

var _UserReviewsPanel = require('./UserReviewsPanel');

var _UserReviewsPanel2 = _interopRequireDefault(_UserReviewsPanel);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var UserReviews = function (_React$Component) {
    _inherits(UserReviews, _React$Component);

    function UserReviews(props) {
        _classCallCheck(this, UserReviews);

        var _this = _possibleConstructorReturn(this, (UserReviews.__proto__ || Object.getPrototypeOf(UserReviews)).call(this, props));

        _this.state = {
            showReviewsPanel: false
        };
        return _this;
    }

    _createClass(UserReviews, [{
        key: 'toggleReviews',
        value: function toggleReviews() {
            this.setState(function (prevState) {
                return {
                    showReviewsPanel: !prevState.showReviewsPanel
                };
            });
        }
    }, {
        key: 'render',
        value: function render() {
            return _react2.default.createElement(
                'div',
                { className: 'container profile-container' },
                _react2.default.createElement(
                    'div',
                    { className: 'profile-stats clearfix' },
                    _react2.default.createElement(
                        'ul',
                        null,
                        _react2.default.createElement(
                            'li',
                            null,
                            _react2.default.createElement(
                                'span',
                                { className: 'stats-number' },
                                this.props.reviews ? this.props.reviews.length : 0
                            ),
                            'Reviews'
                        )
                    )
                ),
                _react2.default.createElement(
                    'div',
                    { className: 'pull-right btn-group' },
                    _react2.default.createElement(
                        'a',
                        { className: 'btn btn-primary', onClick: this.toggleReviews.bind(this) },
                        this.state.showReviewsPanel ? 'Hide' : 'Reviews'
                    )
                ),
                this.state.showReviewsPanel ? _react2.default.createElement(_UserReviewsPanel2.default, { reviews: this.props.reviews }) : null
            );
        }
    }]);

    return UserReviews;
}(_react2.default.Component);

exports.default = UserReviews;

},{"./UserReviewsPanel":64,"react":"react"}],64:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
    value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _react = require('react');

var _react2 = _interopRequireDefault(_react);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var UserReviewsPanel = function (_React$Component) {
    _inherits(UserReviewsPanel, _React$Component);

    function UserReviewsPanel(props) {
        _classCallCheck(this, UserReviewsPanel);

        return _possibleConstructorReturn(this, (UserReviewsPanel.__proto__ || Object.getPrototypeOf(UserReviewsPanel)).call(this, props));
    }

    _createClass(UserReviewsPanel, [{
        key: 'render',
        value: function render() {
            return _react2.default.createElement(
                'div',
                { className: 'container' },
                _react2.default.createElement(
                    'div',
                    { className: 'list-group' },
                    'Hello from UserReviewsPanel'
                )
            );
        }
    }]);

    return UserReviewsPanel;
}(_react2.default.Component);

exports.default = UserReviewsPanel;

},{"react":"react"}],65:[function(require,module,exports){
'use strict';

var _react = require('react');

var _react2 = _interopRequireDefault(_react);

var _reactRouter = require('react-router');

var _reactRouter2 = _interopRequireDefault(_reactRouter);

var _reactDom = require('react-dom');

var _reactDom2 = _interopRequireDefault(_reactDom);

var _createBrowserHistory = require('history/lib/createBrowserHistory');

var _createBrowserHistory2 = _interopRequireDefault(_createBrowserHistory);

var _routes = require('./routes');

var _routes2 = _interopRequireDefault(_routes);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

var history = (0, _createBrowserHistory2.default)();

_reactDom2.default.render(_react2.default.createElement(
    _reactRouter2.default,
    { history: history },
    _routes2.default
), document.getElementById('app'));

},{"./routes":66,"history/lib/createBrowserHistory":20,"react":"react","react-dom":"react-dom","react-router":"react-router"}],66:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
    value: true
});

var _react = require('react');

var _react2 = _interopRequireDefault(_react);

var _reactRouter = require('react-router');

var _Authorize = require('./utilities/Authorize');

var _Authorize2 = _interopRequireDefault(_Authorize);

var _App = require('./components/App');

var _App2 = _interopRequireDefault(_App);

var _Home = require('./components/Home');

var _Home2 = _interopRequireDefault(_Home);

var _MovieAdd = require('./components/MovieAdd');

var _MovieAdd2 = _interopRequireDefault(_MovieAdd);

var _UserProfile = require('./components/UserProfile');

var _UserProfile2 = _interopRequireDefault(_UserProfile);

var _UserRegister = require('./components/UserRegister');

var _UserRegister2 = _interopRequireDefault(_UserRegister);

var _UserLogin = require('./components/UserLogin');

var _UserLogin2 = _interopRequireDefault(_UserLogin);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

exports.default = _react2.default.createElement(
    _reactRouter.Route,
    { component: _App2.default },
    _react2.default.createElement(_reactRouter.Route, { path: '/', component: _Home2.default }),
    _react2.default.createElement(_reactRouter.Route, { path: '/movie/Add', component: (0, _Authorize2.default)(_MovieAdd2.default) }),
    _react2.default.createElement(_reactRouter.Route, { path: '/user/profile/:userId', component: (0, _Authorize2.default)(_UserProfile2.default) }),
    _react2.default.createElement(_reactRouter.Route, { path: '/user/register', component: _UserRegister2.default }),
    _react2.default.createElement(_reactRouter.Route, { path: '/user/login', component: _UserLogin2.default })
);

},{"./components/App":39,"./components/Home":41,"./components/MovieAdd":42,"./components/UserLogin":44,"./components/UserProfile":45,"./components/UserRegister":46,"./utilities/Authorize":72,"react":"react","react-router":"react-router"}],67:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
  value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _alt = require('../alt');

var _alt2 = _interopRequireDefault(_alt);

var _FormActions = require('../actions/FormActions');

var _FormActions2 = _interopRequireDefault(_FormActions);

var _UserActions = require('../actions/UserActions');

var _UserActions2 = _interopRequireDefault(_UserActions);

var _MovieActions = require('../actions/MovieActions');

var _MovieActions2 = _interopRequireDefault(_MovieActions);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var FormStore = function () {
  function FormStore() {
    _classCallCheck(this, FormStore);

    this.bindActions(_FormActions2.default);
    this.bindListeners({
      onRegisterUserFail: _UserActions2.default.registerUserFail,
      onRegisterUserSuccess: _UserActions2.default.registerUserSuccess,
      onLoginUserSuccess: _UserActions2.default.loginUserSuccess,
      onLoginUserFail: _UserActions2.default.loginUserFail,
      onAddCommentFail: _MovieActions2.default.addCommentFail,
      onAddVoteSuccess: _MovieActions2.default.addVoteSuccess,
      onAddVoteFail: _MovieActions2.default.addVoteFail
    });

    this.username = '';
    this.password = '';
    this.confirmedPassword = '';
    this.firstName = '';
    this.lastName = '';
    this.age = '';
    this.gender = '';
    this.formSubmitState = '';
    this.usernameValidationState = '';
    this.passwordValidationState = '';
    this.message = '';
  }

  _createClass(FormStore, [{
    key: 'onUnauthorizedAccessAttempt',
    value: function onUnauthorizedAccessAttempt() {
      this.formSubmitState = 'has-error';
      this.usernameValidationState = '';
      this.passwordValidationState = '';
      this.message = 'Please login.';
    }
  }, {
    key: 'onLoginUserSuccess',
    value: function onLoginUserSuccess() {
      this.formSubmitState = 'has-success';
      this.usernameValidationState = '';
      this.passwordValidationState = '';
      this.message = 'User login successful';
    }
  }, {
    key: 'onLoginUserFail',
    value: function onLoginUserFail(err) {
      this.formSubmitState = 'has-error';
      this.usernameValidationState = 'has-error';
      this.passwordValidationState = 'has-error';
      this.message = err.message;
    }
  }, {
    key: 'onRegisterUserSuccess',
    value: function onRegisterUserSuccess() {
      console.log('FormStore register success');
      this.formSubmitState = 'has-success';
      this.usernameValidationState = '';
      this.passwordValidationState = '';
      this.message = 'User register successful';
    }
  }, {
    key: 'onRegisterUserFail',
    value: function onRegisterUserFail(err) {
      console.log('FormStore register error', err);
      if (err.code === 11000) {
        this.usernameValidationState = 'has-error';
        this.message = 'Username already in use';
        return;
      }

      this.formSubmitState = 'has-error';
      this.message = err.errmsg;
    }
  }, {
    key: 'onUsernameValidationFail',
    value: function onUsernameValidationFail() {
      this.usernameValidationState = 'has-error';
      this.passwordValidationState = '';
      this.formSubmitState = '';
      this.message = 'Enter username';
    }
  }, {
    key: 'onPasswordValidationFail',
    value: function onPasswordValidationFail() {
      this.passwordValidationState = 'has-error';
      this.usernameValidationState = '';
      this.formSubmitState = '';
      this.message = 'Invalid password, or passwords do not match';
    }
  }, {
    key: 'onHandleUsernameChange',
    value: function onHandleUsernameChange(e) {
      this.username = e.target.value;
    }
  }, {
    key: 'onHandlePasswordChange',
    value: function onHandlePasswordChange(e) {
      this.password = e.target.value;
    }
  }, {
    key: 'onHandleConfirmedPasswordChange',
    value: function onHandleConfirmedPasswordChange(e) {
      this.confirmedPassword = e.target.value;
    }
  }, {
    key: 'onHandleFirstNameChange',
    value: function onHandleFirstNameChange(e) {
      this.firstName = e.target.value;
    }
  }, {
    key: 'onHandleLastNameChange',
    value: function onHandleLastNameChange(e) {
      this.lastName = e.target.value;
    }
  }, {
    key: 'onHandleAgeChange',
    value: function onHandleAgeChange(e) {
      this.age = e.target.value;
    }
  }, {
    key: 'onHandleGenderChange',
    value: function onHandleGenderChange(e) {
      this.gender = e.target.value;
    }
  }, {
    key: 'onAddCommentFail',
    value: function onAddCommentFail(err) {
      this.commentValidationState = 'has-error';
      this.message = err.message;
    }
  }, {
    key: 'onCommentValidationFail',
    value: function onCommentValidationFail() {
      this.commentValidationState = 'has-error';
      this.message = 'Please enter comment text.';
    }
  }, {
    key: 'onHandleCommentChange',
    value: function onHandleCommentChange(e) {
      this.comment = e.target.value;
    }
  }, {
    key: 'onHandleScoreChange',
    value: function onHandleScoreChange(e) {
      this.score = e.target.value;
    }
  }, {
    key: 'onScoreValidationFail',
    value: function onScoreValidationFail() {
      this.scoreValidationState = 'has-error';
      this.message = 'Valid score is between 0 - 10';
    }
  }, {
    key: 'onAddVoteSuccess',
    value: function onAddVoteSuccess() {
      this.scoreValidationState = '';
      this.message = '';
    }
  }, {
    key: 'onAddVoteFail',
    value: function onAddVoteFail(err) {
      this.scoreValidationState = 'has-error';
      this.message = err.message;
    }
  }]);

  return FormStore;
}();

exports.default = _alt2.default.createStore(FormStore);

},{"../actions/FormActions":33,"../actions/MovieActions":34,"../actions/UserActions":37,"../alt":38}],68:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
    value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _alt = require('../alt');

var _alt2 = _interopRequireDefault(_alt);

var _MovieAddActions = require('../actions/MovieAddActions');

var _MovieAddActions2 = _interopRequireDefault(_MovieAddActions);

var _Helpers = require('../utilities/Helpers');

var _Helpers2 = _interopRequireDefault(_Helpers);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var MovieAddStore = function () {
    function MovieAddStore() {
        _classCallCheck(this, MovieAddStore);

        this.bindActions(_MovieAddActions2.default);

        this.name = '';
        this.description = '';
        this.genres = [];
        this.moviePosterUrl = '';
        this.genresValidationState = '';
        this.nameValidationState = '';
        this.helpBlock = '';
    }

    _createClass(MovieAddStore, [{
        key: 'onAddMovieSuccess',
        value: function onAddMovieSuccess() {
            console.log('Added movie!');
        }
    }, {
        key: 'onAddMovieFail',
        value: function onAddMovieFail(err) {
            console.log('Failed to add movie', err);
        }
    }, {
        key: 'onGetMoviePosterSuccess',
        value: function onGetMoviePosterSuccess(data) {
            this.moviePosterUrl = data.posterUrl;
        }
    }, {
        key: 'onGetMoviePosterFail',
        value: function onGetMoviePosterFail(err) {
            console.log('Could not get movie post', err);
        }
    }, {
        key: 'onHandleNameChange',
        value: function onHandleNameChange(e) {
            this.name = e.target.value;
            this.nameValidationState = '';
            this.helpBlock = '';
        }
    }, {
        key: 'onHandleDescriptionChange',
        value: function onHandleDescriptionChange(e) {
            this.description = e.target.value;
            this.genresValidationState = '';
            this.helpBlock = '';
        }
    }, {
        key: 'onHandleGenresChange',
        value: function onHandleGenresChange(e) {
            console.log(e);
            var genreValue = e.target.value;
            if (this.genres.indexOf(genreValue) === -1) {
                this.genres = _Helpers2.default.appendToArray(genreValue, this.genres);
            } else {
                this.genres = _Helpers2.default.removeFromArray(genreValue, this.genres);
            }
            this.genresValidationState = '';
            this.helpBlock = '';
        }
    }, {
        key: 'onNameValidationFail',
        value: function onNameValidationFail() {
            this.nameValidationState = 'has-error';
            this.helpBlock = 'Enter movie name';
        }
    }, {
        key: 'onGenresValidationFail',
        value: function onGenresValidationFail() {
            this.genresValidationState = 'has-error';
            this.helpBlock = 'Select atleast one movie genre';
        }
    }]);

    return MovieAddStore;
}();

exports.default = _alt2.default.createStore(MovieAddStore);

},{"../actions/MovieAddActions":35,"../alt":38,"../utilities/Helpers":73}],69:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
  value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _alt = require('../alt');

var _alt2 = _interopRequireDefault(_alt);

var _MovieActions = require('../actions/MovieActions');

var _MovieActions2 = _interopRequireDefault(_MovieActions);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var MovieStore = function () {
  function MovieStore() {
    _classCallCheck(this, MovieStore);

    this.bindActions(_MovieActions2.default);
    this.topTenMovies = [];
    this.mostRecentMovies = [];
  }

  _createClass(MovieStore, [{
    key: 'onAddMovieToTopTen',
    value: function onAddMovieToTopTen(movie) {
      this.topTenMovies.push(movie);
    }
  }, {
    key: 'onEmptyTopTenMovies',
    value: function onEmptyTopTenMovies() {
      this.topTenMovies = [];
    }
  }, {
    key: 'onGetTopTenMoviesSuccess',
    value: function onGetTopTenMoviesSuccess(movies) {
      this.topTenMovies = movies;
    }
  }, {
    key: 'onGetTopTenMoviesFail',
    value: function onGetTopTenMoviesFail(err) {
      console.log('Could connect to DB', err);
    }
  }, {
    key: 'onGetFiveRecentMoviesSuccess',
    value: function onGetFiveRecentMoviesSuccess(data) {
      this.mostRecentMovies = data;
    }
  }, {
    key: 'onGetFiveRecentMoviesFail',
    value: function onGetFiveRecentMoviesFail() {
      console.log('Could not connext to DB');
    }
  }, {
    key: 'onAddCommentSuccess',
    value: function onAddCommentSuccess(data) {
      var comment = data.comment;
      var movieId = data.comment.movie;
      for (var i = 0, n = this.topTenMovies.length; i < n; i++) {
        if (this.topTenMovies[i]._id === movieId) {
          this.topTenMovies[i].comments.unshift(comment);
        }
      }
    }
  }, {
    key: 'onAddVoteSuccess',
    value: function onAddVoteSuccess(data) {
      var movieId = data.movieId;
      var loggedInUserScore = data.voteScore;
      var movieScore = data.movieScore;
      var movieVotes = data.movieVotes;

      var _iteratorNormalCompletion = true;
      var _didIteratorError = false;
      var _iteratorError = undefined;

      try {
        for (var _iterator = this.topTenMovies[Symbol.iterator](), _step; !(_iteratorNormalCompletion = (_step = _iterator.next()).done); _iteratorNormalCompletion = true) {
          var movie = _step.value;

          if (movie._id === movieId) {
            movie.loggedInUserScore = loggedInUserScore;
            movie.score = movieScore;
            movie.votes = movieVotes;
            break;
          }
        }
      } catch (err) {
        _didIteratorError = true;
        _iteratorError = err;
      } finally {
        try {
          if (!_iteratorNormalCompletion && _iterator.return) {
            _iterator.return();
          }
        } finally {
          if (_didIteratorError) {
            throw _iteratorError;
          }
        }
      }
    }
  }]);

  return MovieStore;
}();

exports.default = _alt2.default.createStore(MovieStore);

},{"../actions/MovieActions":34,"../alt":38}],70:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
    value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _alt = require('../alt');

var _alt2 = _interopRequireDefault(_alt);

var _NavbarActions = require('../actions/NavbarActions');

var _NavbarActions2 = _interopRequireDefault(_NavbarActions);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var NavbarStore = function () {
    function NavbarStore() {
        _classCallCheck(this, NavbarStore);

        this.bindActions(_NavbarActions2.default);

        this.ajaxAnimationClass = '';
    }

    _createClass(NavbarStore, [{
        key: 'onUpdateAjaxAnimation',
        value: function onUpdateAjaxAnimation(animationClass) {
            this.ajaxAnimationClass = animationClass;
        }
    }]);

    return NavbarStore;
}();

exports.default = _alt2.default.createStore(NavbarStore);

},{"../actions/NavbarActions":36,"../alt":38}],71:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
    value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _alt = require('../alt');

var _alt2 = _interopRequireDefault(_alt);

var _UserActions = require('../actions/UserActions');

var _UserActions2 = _interopRequireDefault(_UserActions);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var AppStore = function () {
    function AppStore() {
        _classCallCheck(this, AppStore);

        this.bindActions(_UserActions2.default);

        this.loggedInUserId = '';
        this.username = '';
        this.roles = [];
    }

    _createClass(AppStore, [{
        key: 'onLoginUserSuccess',
        value: function onLoginUserSuccess(user) {
            this.loggedInUserId = user._id;
            this.username = user.username;
            this.roles = user.roles;
        }
    }, {
        key: 'onLoginUserFail',
        value: function onLoginUserFail() {
            console.log('Failed login attempt');
        }
    }, {
        key: 'onLogoutUserSuccess',
        value: function onLogoutUserSuccess() {
            // Redirect on part 3
            this.loggedInUserId = '';
            this.username = '';
            this.roles = [];
        }
    }]);

    return AppStore;
}();

exports.default = _alt2.default.createStore(AppStore);

},{"../actions/UserActions":37,"../alt":38}],72:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
  value: true
});
exports.Concealer = undefined;

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

exports.default = authorize;

var _react = require('react');

var _react2 = _interopRequireDefault(_react);

var _UserStore = require('../stores/UserStore');

var _UserStore2 = _interopRequireDefault(_UserStore);

var _FormActions = require('../actions/FormActions');

var _FormActions2 = _interopRequireDefault(_FormActions);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

function authorize(ChildComponent) {
  return function (_React$Component) {
    _inherits(Authorization, _React$Component);

    function Authorization(props) {
      _classCallCheck(this, Authorization);

      var _this = _possibleConstructorReturn(this, (Authorization.__proto__ || Object.getPrototypeOf(Authorization)).call(this, props));

      _this.state = _UserStore2.default.getState();
      _this.onChange = _this.onChange.bind(_this);
      return _this;
    }

    _createClass(Authorization, [{
      key: 'onChange',
      value: function onChange(state) {
        this.setState(state);
      }
    }, {
      key: 'componentWillMount',
      value: function componentWillMount() {
        if (!this.state.loggedInUserId) {
          this.props.history.pushState(null, '/user/login');
          _FormActions2.default.unauthorizedAccessAttempt();
        }
      }
    }, {
      key: 'componentDidMount',
      value: function componentDidMount() {
        _UserStore2.default.listen(this.onChange);
      }
    }, {
      key: 'componentWillUnmount',
      value: function componentWillUnmount() {
        _UserStore2.default.unlisten(this.onChange);
      }
    }, {
      key: 'render',
      value: function render() {
        return _react2.default.createElement(ChildComponent, this.props);
      }
    }]);

    return Authorization;
  }(_react2.default.Component);
}

var Concealer = exports.Concealer = function (_React$Component2) {
  _inherits(Concealer, _React$Component2);

  function Concealer(props) {
    _classCallCheck(this, Concealer);

    var _this2 = _possibleConstructorReturn(this, (Concealer.__proto__ || Object.getPrototypeOf(Concealer)).call(this, props));

    _this2.state = _UserStore2.default.getState();
    _this2.onChange = _this2.onChange.bind(_this2);
    return _this2;
  }

  _createClass(Concealer, [{
    key: 'onChange',
    value: function onChange(state) {
      this.setState(state);
    }
  }, {
    key: 'componentDidMount',
    value: function componentDidMount() {
      _UserStore2.default.listen(this.onChange);
    }
  }, {
    key: 'componentWillUnmount',
    value: function componentWillUnmount() {
      _UserStore2.default.unlisten(this.onChange);
    }
  }, {
    key: 'render',
    value: function render() {
      var ChildComponent = this.props.ChildComponent;

      return this.state.loggedInUserId ? _react2.default.createElement(ChildComponent, this.props) : null;
    }
  }]);

  return Concealer;
}(_react2.default.Component);

},{"../actions/FormActions":33,"../stores/UserStore":71,"react":"react"}],73:[function(require,module,exports){
"use strict";

Object.defineProperty(exports, "__esModule", {
    value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var Helpers = function () {
    function Helpers() {
        _classCallCheck(this, Helpers);
    }

    _createClass(Helpers, null, [{
        key: "formatMovieRating",
        value: function formatMovieRating(score, votes) {
            var rating = score / votes;

            if (isNaN(rating)) {
                rating = 0;
            }

            if (rating % 1 !== 0) {
                rating = rating.toFixed(1);
            }

            return rating;
        }
    }]);

    return Helpers;
}();

exports.default = Helpers;

},{}],74:[function(require,module,exports){
'use strict';

Object.defineProperty(exports, "__esModule", {
    value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var API_KEY = '71aabd79c7082bcacabc96877ac7238b';
var SEARCH_BASE_URL = 'https://api.themoviedb.org/3/search/movie';
var POSTER_BASE_URL = 'https://image.tmdb.org/t/p/w500';
var UNVERIFIED_MOVIE_POSTER_URL = '/images/movie-unverified.png';
var MISSING_DATA_POSTER_URL = '/images/movie-missing-data.jpg';

var RequesterTMDB = function () {
    function RequesterTMDB() {
        _classCallCheck(this, RequesterTMDB);
    }

    _createClass(RequesterTMDB, null, [{
        key: 'getMoviePoster',
        value: function getMoviePoster(movieName) {
            return new Promise(function (resolve, reject) {
                var request = {
                    method: 'get',
                    url: SEARCH_BASE_URL + '?api_key=' + API_KEY + '&query=' + movieName
                };
                $.ajax(request).done(function (tmdbResponse) {
                    console.log('TMDB response', tmdbResponse);
                    if (tmdbResponse.total_results === 0) {
                        resolve({ posterUrl: UNVERIFIED_MOVIE_POSTER_URL });
                        return;
                    }

                    var posterPath = tmdbResponse.results[0].poster_path;
                    if (posterPath === null) {
                        resolve({ posterUrl: MISSING_DATA_POSTER_URL });
                        return;
                    }
                    resolve({ posterUrl: POSTER_BASE_URL + '/' + posterPath });
                }).fail(function (err) {
                    reject({
                        clientMessage: 'Request failed',
                        error: err
                    });
                });
            });
        }
    }]);

    return RequesterTMDB;
}();

exports.default = RequesterTMDB;

},{}]},{},[65])

//# sourceMappingURL=bundle.js.map
