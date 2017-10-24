import { Injectable } from '@angular/core';
import { NgRedux } from 'ng2-redux';
import { IAppState } from '..';
import { UsersService } from '../../users/users.service';

export const USER_REGISTERED = 'users/REGISTER';
export const USER_LOGGED_IN = 'users/LOGIN';
export const USER_LOGOUT = 'users/LOGOUT';
export const USER_PROFILE = 'users/PROFILE';

@Injectable()
export class UsersActions {
  constructor (
    private UsersService: UsersService,
    private ngRedux: NgRedux<IAppState>
  ) { }
  register (user) {
    this.UsersService
    .register(user)
    .subscribe(result => {
      this.ngRedux.dispatch({
        type: USER_REGISTERED,
        result
      })
    });
  }

  login (user) {
    this.UsersService
      .login(user)
      .subscribe(result => {
        this.ngRedux.dispatch({
          type: USER_LOGGED_IN,
          result
        });
      });
  }

  logout () {
    this.ngRedux.dispatch({
      type: USER_LOGOUT
    });
  }
  
}