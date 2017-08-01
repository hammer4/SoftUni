import {Component, OnInit} from '@angular/core'
import {DataService} from '../../services/data.service'

@Component({
  selector: 'home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {
  cars: Array<{}>

  constructor (private data: DataService) {}

  ngOnInit () {
    this.data.latestCars().then(data => this.cars = data);
  }
}