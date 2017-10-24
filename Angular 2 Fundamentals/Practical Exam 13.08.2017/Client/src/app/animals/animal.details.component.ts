import {Component, OnInit} from '@angular/core'
import {ActivatedRoute, Router} from '@angular/router'
import {AnimalsService} from './animal.service'
import currentUser from '../users/currentUser'

@Component({
  selector: 'animal-details',
  templateUrl: './animal.details.component.html'
})

export class AnimalDetailsComponent implements OnInit {
  animal = {};
  id: string;
  reactions = ['like', 'love', 'haha', 'wow', 'sad', 'angry']
  reaction: string;
  message: string = '';
  comments: Array<{}> = null;

  constructor (private animalsService: AnimalsService, private route: ActivatedRoute, private router: Router) {
    this.id = this.route.snapshot.paramMap.get('id')
  }

  ngOnInit () {
    if (!currentUser.token) {
      this.router.navigateByUrl('users/login')
      return
    }
    this.animalsService.getAnimal(this.id).subscribe(res => this.animal = res);
    this.animalsService.getComments(this.id).subscribe(res => this.comments = res)
  }

  reactionSubmit () {
    this.animalsService.react(this.id, {type: this.reaction})
      .subscribe(res => this.animalsService.getAnimal(this.id)
        .subscribe(res => this.animal = res));
  }

  commentSubmit () {
    this.animalsService.submitComment(this.id, {message: this.message})
      .subscribe(res => this.animalsService.getComments(this.id).subscribe(comm => this.comments = comm));
  }
}