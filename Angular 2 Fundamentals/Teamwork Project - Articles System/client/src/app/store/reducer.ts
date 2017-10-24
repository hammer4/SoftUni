import { combineReducers } from 'redux';
import { IAppState } from './app.state';

import { coreReducer} from './core/core.reducer';
import { statsReducer } from './stats/stats.reducer';
import { usersReducer } from './users/users.reducer';
import { articlesReducer } from './articles/articles.reducer';

export const reducer = combineReducers<IAppState>({
  core: coreReducer,
  stats: statsReducer,
  users: usersReducer,
  articles: articlesReducer
});