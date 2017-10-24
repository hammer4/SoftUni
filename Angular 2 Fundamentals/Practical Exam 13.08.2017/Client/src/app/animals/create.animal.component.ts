import {Component, OnInit} from '@angular/core'
import {Animal} from './animal.model'
import {AnimalsService} from './animal.service'
import {Router} from '@angular/router'
import currentUser from '../users/currentUser'

@Component({
  selector: 'create-animal',
  templateUrl: './create.animal.component.html'
})

export class CreateAnimalComponent implements OnInit {
  animal: Animal = new Animal();
  types: Array<string> = ['Cat', 'Dog', 'Bunny', 'Exotic', 'Other'];

  constructor (private animalsService: AnimalsService, private router: Router) {  }

  ngOnInit () {
    if (!currentUser.token) {
      this.router.navigateByUrl('users/login')
    }
  }

  onSubmit () {
    this.animalsService.create(this.animal).subscribe(res => {
      if (res.success) {
        this.router.navigateByUrl('animals/' + res.animal.id)
      } else {
        console.log(res)
      }
    });
  }
}