import {Injectable} from '@angular/core';
import {Http, RequestOptions, Headers} from '@angular/http'
import 'rxjs/add/operator/map'
import currentUser from '../users/currentUser'

const baseUrl = 'http://localhost:5000/'

@Injectable()
export class HttpService {
  constructor (private http: Http) {}

  post (url, data, isAuthenticated = false) {
    let headers;

    if (isAuthenticated) {
      headers = new Headers({
        'Content-Type': 'application/json',
        'Authorization': 'bearer ' + currentUser.token
      });
    } else {
      headers = new Headers({
        'Content-Type': 'application/json'
      });
    }

    const requestOptions = new RequestOptions({
      headers: headers
    })
    return this.http.post(`${baseUrl}${url}`, JSON.stringify(data), requestOptions).map(res => res.json())
  }

  get (url, isAuthenticated = false) {
    let headers
    if (isAuthenticated) {
      headers = new Headers({
        'Content-Type': 'application/json',
        'Authorization': 'bearer ' + currentUser.token
      });
    } else {
      headers = new Headers({
        'Content-Type': 'application/json'
      });
    }

    const requestOptions = new RequestOptions({
      headers: headers
    })
    return this.http.get(`${baseUrl}${url}`, requestOptions).map(res => res.json())
  }
}