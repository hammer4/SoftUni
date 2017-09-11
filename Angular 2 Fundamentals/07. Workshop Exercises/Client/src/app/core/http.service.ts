import { Injectable } from '@angular/core';
import { Http, RequestOptions, Headers } from '@angular/http';

import { AuthService } from './auth.service';

import 'rxjs/add/operator/map';

const baseUrl = 'http://localhost:5000/'
const getMethod = 'get';
const postMethod = 'post';


@Injectable()
export class HttpService {
  constructor (
    private http: Http,
    private authService: AuthService) { }

  get (url, authenticated = false) {
    const requestOptions =
     this.getRequestOptions(getMethod, authenticated);

    return this.http
      .get(`${baseUrl}${url}`, requestOptions)
      .map(res => res.json());
  }

  post (url, data, authenticated = false) {
    const requestOptions =
     this.getRequestOptions(postMethod, authenticated);
    return this.http
      .post(`${baseUrl}${url}`, JSON.stringify(data), requestOptions)
      .map(res => res.json());
  }
  
  private getRequestOptions (method, authenticated) {
    const headers = new Headers();

    if (method !== getMethod) {
      headers.append('Content-Type', 'application/json');
    }

    if (authenticated) {
      const token = this.authService.getToken();
      headers.append('Authorization', `bearer ${token}`)
    }
    const requestOptions = new RequestOptions({
      headers: headers
    });

    return requestOptions;
  }
}