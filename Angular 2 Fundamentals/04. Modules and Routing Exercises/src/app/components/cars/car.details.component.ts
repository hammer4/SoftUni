import {Component, OnInit} from '@angular/core'
import {DataService} from '../../services/data.service'
import {ActivatedRoute} from '@angular/router'

@Component({
  selector: 'car-details',
  templateUrl: './car.details.component.html',
  styleUrls: ['./car.details.component.css']
})

export class CarDetailsComponent implements OnInit {
  car: {};
  id: number;

  constructor (private data: DataService, private route: ActivatedRoute) {
    this.id = Number(this.route.snapshot.paramMap.get('id'))
  }

  ngOnInit () {
    this.data.getCarById(this.id).then(data => this.car = data)
  }
}