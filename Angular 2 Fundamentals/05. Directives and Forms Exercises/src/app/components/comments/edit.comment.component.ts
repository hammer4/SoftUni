import {Component, OnInit} from '@angular/core'
import {DataService} from '../../services/data.service'
import {ActivatedRoute} from '@angular/router'

@Component({
  selector: 'edit-comment',
  templateUrl: './edit.comment.component.html',
  styleUrls: []
})

export class EditCommentComponent implements OnInit {
  content: string;
  id: number;

  constructor (private data: DataService, private route: ActivatedRoute) {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
  }

  ngOnInit () {
    this.data.getCommentById(this.id).then(data => this.content = data.content);
  }

  onSubmit () {
    this.data.updateComment(this.id, this.content).then(data => console.log('Comment updated'));
  }
}