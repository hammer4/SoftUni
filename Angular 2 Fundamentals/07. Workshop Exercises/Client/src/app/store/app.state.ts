import { ICoreState } from './core/core.state';
import { IUsersState } from './users/users.state';
import { IStatsState } from './stats/stats.state';
import { ICarsState } from './cars/cars.state';

export interface IAppState {
  core: ICoreState,
  stats: IStatsState,
  users: IUsersState,
  cars: ICarsState
}

