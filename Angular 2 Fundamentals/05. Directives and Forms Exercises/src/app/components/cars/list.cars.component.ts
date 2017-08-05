import {Component, OnInit} from '@angular/core'
import {DataService} from '../../services/data.service'

@Component({
  selector: 'all-cars',
  templateUrl: './list.cars.component.html',
  styleUrls: ['./list.cars.component.css']
})

export class ListCarsComponent implements OnInit {
  cars: Array<any>

  constructor (private data: DataService) {}

  ngOnInit () {
    this.data.allCars().then(data => this.cars = data)
  }

  sort (event) {
    let sortBy = event.target.value

    switch(sortBy) {
      case 'owner': this.cars = this.cars.sort((a, b) => a.ownerName.localeCompare(b.ownerName)); break;
      case 'make': this.cars = this.cars.sort((a, b) => a.make.localeCompare(b.make)); break;
      case 'date': this.cars = this.cars.sort((a, b) => new Date(b.date).getTime() - new Date(a.date).getTime())
    }
  }
}