import {Injectable} from '@angular/core'
import data from '../Data'

@Injectable()
export class DataService {
  latestCars (): Promise<Array<{}>> {
    return data.getLatestCars()
  }

  allCars (): Promise<any> {
    return data.getAllCars()
  }

  getCarById (id): Promise<any> {
    return data.getCarById(id)
  }

  allOwners (): Promise<Array<{}>> {
    return data.getAllOwners()
  }

  getOwnerById (id): Promise<any> {
    return data.getOwnerById(id)
  }

  createOwner (owner): Promise<any> {
    return data.createOwner(owner)
  }

  createCar (car): Promise<any> {
    return data.createCar(car)
  }

  createComment (car, content) {
    return data.createComment(car, content)
  }

  updateOwner (owner): Promise<any> {
    return data.updateOwner(owner)
  }

  updateCar (car): Promise<any> {
    return data.updateCar(car)
  }

  getCommentById (id): Promise<any> {
    return data.getCommentById(id)
  }

  updateComment (id, content): Promise<any> {
    return data.updateComment(id, content)
  }
}
