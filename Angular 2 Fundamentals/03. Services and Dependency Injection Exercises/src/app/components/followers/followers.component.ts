import { Component } from '@angular/core'
import GitHubData from '../../services/github.data.service'

@Component({
  selector: 'followers',
  templateUrl: './followers.component.html',
  styleUrls: ['./followers.component.css']
})

export class FollowersComponent {
  followers: Array<{}>

  constructor (private githubData: GitHubData) {}

  showFollowers () {
    this.githubData.followers().then(data => this.followers = data);
  }

  hideFollowers () {
    this.followers = null;
  }
}