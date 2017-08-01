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
}
