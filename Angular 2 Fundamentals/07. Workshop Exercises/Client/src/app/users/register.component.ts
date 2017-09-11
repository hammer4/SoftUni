import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { RegisterUserModel} from './register-user.model';

import { NgRedux } from 'ng2-redux';
import { IAppState } from '../store';

import { UsersActions } from '../store/users/users.actions';
@Component({
  selector:'register',
  templateUrl:'./register.component.html'
})
export class RegisterComponent {
  user: RegisterUserModel = new RegisterUserModel();

  constructor(
    private UsersActions : UsersActions,
    private router: Router,
    private ngRedux: NgRedux<IAppState>) { }
  register () {
    this.UsersActions.register(this.user);
    this.ngRedux
      .select(state => state.users.userRegistered)
      .subscribe(userRegistered => {
        if (userRegistered) {
          this.router.navigateByUrl('users/login');
        }
      })
  }
}