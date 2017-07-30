import { Component, OnInit } from '@angular/core'
import GitHubData from '../../services/github.data.service'

@Component({
  selector: 'profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})

export class ProfileComponent implements OnInit {
  profileData: {}

  constructor (private gitHubData: GitHubData) {}

  ngOnInit () {
    this.gitHubData.profile().then(data => this.profileData = data)
  }
}