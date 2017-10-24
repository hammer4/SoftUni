import { Injectable } from '@angular/core';
import { HttpService } from '../core/http.service';
@Injectable()
export class StatsService {
  constructor (private httpService: HttpService) { }
  
  get () {
    return this.httpService.get('stats');
  }
}