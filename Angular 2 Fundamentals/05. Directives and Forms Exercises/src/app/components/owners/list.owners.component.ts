import {Component, OnInit} from '@angular/core'
import {DataService} from '../../services/data.service'

@Component({
  selector: 'all-owners',
  templateUrl: './list.owners.component.html',
  styleUrls: ['./list.owners.component.css']
})

export class ListOwnersComponent implements OnInit {
  owners: Array<any>;

  constructor (private data: DataService) {}

  ngOnInit () {
    this.data.allOwners().then(data => this.owners = data);
  }

  sort (event) {
    let criteria = event.target.value;

    switch (criteria) {
      case 'ascending': this.owners = this.owners.sort((a, b) => a.name.localeCompare(b.name)); break;
      case 'descending': this.owners = this.owners.sort((a, b) => b.name.localeCompare(a.name)); break;
    }
  }
}