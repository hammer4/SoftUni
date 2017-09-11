import {Injectable} from '@angular/core'
import {HttpService} from '../core/http.service'

@Injectable()
export class UsersService {
  constructor (private httpService: HttpService) {

  }
  
  register (user) {
    return this.httpService.post('auth/signup', user)
  }

  login (user) {
    return this.httpService.post('auth/login', user)
  }
}