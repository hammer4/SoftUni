import {Injectable} from '@angular/core'
import {HttpService} from '../core/http.service'

@Injectable()
export class AnimalsService {
  constructor (private httpService: HttpService) {
  }

  create (animal) {
    return this.httpService.post('animals/create', animal, true)
  }

  getAnimal (id) {
    return this.httpService.get('animals/details/' + id, true)
  }

  react (id, reaction) {
    return this.httpService.post('animals/details/' + id + '/reaction', reaction, true)
  }

  submitComment (id, message) {
    return this.httpService.post('animals/details/' + id + '/comments/create', message, true)
  }

  getComments (id) {
    return this.httpService.get('animals/details/' + id + '/comments', true)
  }

  getStats () {
    return this.httpService.get('stats')
  }

  allAnimals (page = 1, search = null) {
    let url = `animals/all?page=${page}`
    if (search) {
      url += `&search=${search}`
    }

    return this.httpService.get(url)
  }
}