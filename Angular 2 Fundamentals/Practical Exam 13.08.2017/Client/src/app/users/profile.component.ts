import {Component, OnInit} from '@angular/core'
import {UsersService} from './users.service'
import currentUser from './currentUser'

@Component({
  selector: 'profile-page',
  templateUrl: './profile.component.html',
  styles: [`img {
      max-width: 300px;
  }`]
})

export class ProfileComponent implements OnInit {
  animals: Array<any> = null;

  constructor (private usersService: UsersService) {}

  ngOnInit () {
    if (!currentUser.token) {
      return
    }
    this.usersService.profile().subscribe(res => this.animals = res);
  }

  deleteAnimal (id) {
    this.usersService.deleteAnimal(id).subscribe(res => this.usersService.profile().subscribe(animals => this.animals = animals))
  }
}