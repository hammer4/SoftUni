import {Component, OnInit} from '@angular/core'
import {DataService} from '../../services/data.service'
import {ActivatedRoute} from '@angular/router'

@Component({
  selector: 'owner-details',
  templateUrl: './owner.details.component.html',
  styleUrls: ['./owner.details.component.css']
})

export class OwnerDetailsComponent implements OnInit {
  owner: {};
  id: number;

  constructor (private data: DataService, private route: ActivatedRoute) {
    this.id = Number(this.route.snapshot.paramMap.get('id'))
  }

  ngOnInit () {
    this.data.getOwnerById(this.id).then(data => this.owner = data)
  }
}