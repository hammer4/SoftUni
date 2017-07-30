import { Component, Input } from '@angular/core'
import GitHubData from '../../services/github.data.service'

@Component({
  selector: 'contributors',
  templateUrl: './contributors.component.html',
  styleUrls: ['./contributors.component.css']
})

export class ContributorsComponent {
  contributors: Array<{}>
  @Input() repoName: string;

  constructor (private githubData: GitHubData) {}

  showContributors () {
    this.githubData.contributors(this.repoName).then(data => this.contributors = data);
  }

  hideContributors () {
    this.contributors = null;
  }
}