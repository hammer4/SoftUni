import {NgModule} from '@angular/core'
import {CommonModule} from '@angular/common'
import {RouterModule, Routes} from '@angular/router'
import {FormsModule} from '@angular/forms'

import {HomeComponent} from './components/home/home.component'
import {ListCarsComponent} from './components/cars/list.cars.component'
import {CarDetailsComponent} from './components/cars/car.details.component'
import {ListOwnersComponent} from './components/owners/list.owners.component'
import {OwnerDetailsComponent} from './components/owners/owner.details.component'
import {CreateOwnerComponent} from './components/owners/create.owner.component'
import {CreateCarComponent} from './components/cars/create.car.component'
import {EditOwnerComponent} from './components/owners/edit.owner.component'
import {EditCarComponent} from './components/cars/edit.car.component'
import {EditCommentComponent} from './components/comments/edit.comment.component'

import {TurboPipe} from './pipes/turbo.pipe'

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'cars/all', component: ListCarsComponent },
  { path: 'cars/create', component: CreateCarComponent },
  { path: 'cars/edit/:id', component: EditCarComponent },
  { path: 'cars/:id', component: CarDetailsComponent },
  { path: 'owners/all', component: ListOwnersComponent },
  { path: 'owners/create', component: CreateOwnerComponent },
  { path: 'owners/edit/:id', component: EditOwnerComponent },
  { path: 'owners/:id', component: OwnerDetailsComponent },
  { path: 'comments/edit/:id', component: EditCommentComponent }
];

@NgModule({
  declarations: [
    ListCarsComponent,
    CarDetailsComponent,
    ListOwnersComponent,
    OwnerDetailsComponent,
    CreateOwnerComponent,
    CreateCarComponent,
    EditOwnerComponent,
    EditCarComponent,
    EditCommentComponent,
    TurboPipe
  ],
  imports:[RouterModule.forRoot(routes), CommonModule, FormsModule],
  exports: [RouterModule]
})
export class AppRoutesModule {}
