import {Component, OnInit} from '@angular/core'
import {Owner} from '../../models/Owner'
import {DataService} from '../../services/data.service'
import {ActivatedRoute} from '@angular/router'

@Component({
  selector: 'edit-owner',
  templateUrl: './edit.owner.component.html',
  styleUrls: []
})

export class EditOwnerComponent {
  owner: Owner;
  id: number;

  constructor (private data: DataService, private route: ActivatedRoute) {
    this.id = Number(this.route.snapshot.paramMap.get('id'))
  }

  ngOnInit () {
    this.data.getOwnerById(this.id).then(data => this.owner = data)
  }

  onSubmit () {
    this.data.updateOwner(this.owner).then(owner => console.log('Owner updated'));
  }
}