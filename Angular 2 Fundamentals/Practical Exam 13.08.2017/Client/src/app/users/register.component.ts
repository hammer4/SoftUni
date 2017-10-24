import {Component} from '@angular/core'
import {RegisterUser} from './register-user.model'
import {UsersService} from './users.service'
import {Router} from '@angular/router'

@Component({
  selector: 'register',
  templateUrl: './register.component.html'
})
export class RegisterComponent {
  user: RegisterUser = new RegisterUser();

  constructor (private usersService: UsersService, private router: Router) {}

  register () {
    this.usersService
      .register(this.user)
      .subscribe(res => {
        if (res.success) {
          this.router.navigateByUrl('users/login');
        }
      })
  }
}