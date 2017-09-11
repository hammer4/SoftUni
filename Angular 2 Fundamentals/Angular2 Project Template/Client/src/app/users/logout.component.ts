import {Component, OnInit} from '@angular/core'
import {Router} from '@angular/router'
import currentUser from './currentUser'

@Component({
  selector: 'logout',
  template: '<span></span>'
})

export class LogoutComponent implements OnInit {
  constructor (private router: Router) {}
  
  ngOnInit () {
    currentUser.name = '';
    currentUser.userLoggedIn = false;
    currentUser.token = null;
    this.router.navigateByUrl('/');
  }
}