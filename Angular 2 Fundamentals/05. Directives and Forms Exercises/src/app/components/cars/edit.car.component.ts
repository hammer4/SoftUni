import {Component, OnInit} from '@angular/core'
import {Car} from '../../models/Car'
import {DataService} from '../../services/data.service'
import {ActivatedRoute} from '@angular/router'

@Component({
  selector: 'edit-car',
  templateUrl: './edit.car.component.html',
  styleUrls: []
})

export class EditCarComponent implements OnInit {
  car: Car;
  owners: Array<{}>;
  id: number;

  constructor (private data: DataService, private route: ActivatedRoute) {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
  }

  ngOnInit () {
    this.data.getCarById(this.id).then(data => this.car = data)
    this.data.allOwners().then(owners => this.owners = owners);
  }

  onSubmit () {
    this.data.updateCar(this.car).then(car => console.log('Car updated'));
  }
}