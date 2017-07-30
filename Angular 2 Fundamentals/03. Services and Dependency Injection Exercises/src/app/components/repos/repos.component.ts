import {Component} from '@angular/core'
import GitHubData from '../../services/github.data.service'

@Component({
  selector: 'repos',
  templateUrl: './repos.component.html',
  styleUrls: ['./repos.component.css']
})

export class ReposComponent {
  repos: Array<{}>

  constructor (private githubData: GitHubData) {}

  showRepos () {
    this.githubData.repos().then(data => this.repos = data)
  }

  hideRepos () {
    this.repos = null
  }
}