import {NgModule} from '@angular/core'
import {CommonModule} from '@angular/common'
import {RouterModule, Routes} from '@angular/router'

import {HomeComponent} from './components/home/home.component'
import {ListCarsComponent} from './components/cars/list.cars.component'
import {CarDetailsComponent} from './components/cars/car.details.component'
import {ListOwnersComponent} from './components/owners/list.owners.component'
import {OwnerDetailsComponent} from './components/owners/owner.details.component'

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'cars/all', component: ListCarsComponent },
  { path: 'cars/:id', component: CarDetailsComponent },
  { path: 'owners/all', component: ListOwnersComponent },
  { path: 'owners/:id', component: OwnerDetailsComponent }
];

@NgModule({
  declarations: [
    ListCarsComponent,
    CarDetailsComponent,
    ListOwnersComponent,
    OwnerDetailsComponent
  ],
  imports:[RouterModule.forRoot(routes), CommonModule],
  exports: [RouterModule]
})
export class AppRoutesModule {}
