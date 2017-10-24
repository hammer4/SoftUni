import {Component} from '@angular/core'
import {LoginUserModel} from './login-user.model'
import {UsersService} from './users.service'
import {Router} from '@angular/router'
import currentUser from './currentUser'

@Component({
  selector: 'login',
  templateUrl: './login.component.html'
})

export class LoginComponent {
  user: LoginUserModel = new LoginUserModel()

  constructor (private usersService: UsersService, private router: Router) {}

  login () {
    this.usersService
      .login(this.user)
      .subscribe(res => {
        if (res.success) {
          currentUser.name = res.user.name;
          currentUser.token = res.token;
          currentUser.userLoggedIn = true;
          this.router.navigateByUrl('/');
        }
      })
  }
}