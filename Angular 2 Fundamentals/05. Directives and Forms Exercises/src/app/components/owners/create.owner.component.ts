import {Component} from '@angular/core'
import {Owner} from '../../models/Owner'
import {DataService} from '../../services/data.service'

@Component({
  selector: 'create-owner',
  templateUrl: './create.owner.component.html',
  styleUrls: ['./create.owner.component.css']
})

export class CreateOwnerComponent {
  owner: Owner;

  constructor (private data: DataService) {
    this.owner = {
      id: null,
      name: '',
      image: '',
      carsLength: 0,
      cars: []
    };
  }

  onSubmit () {
    this.data.createOwner(this.owner).then(owner => console.log('Owner created'));
  }
}