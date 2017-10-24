import {Component} from '@angular/core'
import currentUser from '../users/currentUser'

@Component({
  selector: 'navbar',
  templateUrl: './navbar.component.html'
})
export class NavbarComponent {
  user = currentUser
}