import { Injectable }from '@angular/core';
import { Http }from '@angular/http';
import 'rxjs/add/operator/toPromise';

const username = 'ivaylokenov'
const baseUrl = 'https://api.github.com/'

@Injectable()
export default class GitHubData {
  constructor (private http: Http) {}

  profile (): Promise<{}> {
    let url = `${baseUrl}users/${username}`;

    return this.http
      .get(url)
      .toPromise()
      .then(resp => resp.json())
      .catch(err => { console.log(err); return {} })
  }

  followers (): Promise<Array<{}>> {
    let url = `${baseUrl}users/${username}/followers`;

    return this.http
      .get(url)
      .toPromise()
      .then(resp => resp.json())
      .catch(err => { console.log(err); return {} })
  }

  repos (): Promise<Array<{}>> {
    let url = `${baseUrl}users/${username}/repos`;

    return this.http
      .get(url)
      .toPromise()
      .then(resp => resp.json())
      .catch(err => { console.log(err); return {} })
  }

  contributors (repoName): Promise<Array<{}>> {
    let url = `${baseUrl}repos/${username}/${repoName}/contributors`

    return this.http
      .get(url)
      .toPromise()
      .then(resp => resp.json())
      .catch(err => { console.log(err); return {} })
  }
}
