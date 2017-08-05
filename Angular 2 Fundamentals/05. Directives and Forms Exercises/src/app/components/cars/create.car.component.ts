import {Component, OnInit} from '@angular/core'
import {Car} from '../../models/Car'
import {DataService} from '../../services/data.service'

@Component({
  selector: 'create-car',
  templateUrl: './create.car.component.html',
  styleUrls: ['./create.car.component.css']
})

export class CreateCarComponent implements OnInit {
  car: Car;
  owners: Array<{}>

  constructor (private data: DataService) {
    this.car = new Car (null, '', '', '', '', null, null, '', null, '', [])
  }

  ngOnInit () {
    this.data.allOwners().then(owners => this.owners = owners);
  }

  onSubmit () {
    this.data.createCar(this.car).then(car => console.log('Car created'));
  }
}