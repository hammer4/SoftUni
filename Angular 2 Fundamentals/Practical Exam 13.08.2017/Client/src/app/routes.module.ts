import {NgModule} from '@angular/core'
import {RouterModule, Routes} from '@angular/router'

import {RegisterComponent} from './users/register.component' 
import {LoginComponent} from './users/login.component'
import {LogoutComponent} from './users/logout.component'
import {ProfileComponent} from './users/profile.component'

import {CreateAnimalComponent} from './animals/create.animal.component'
import {AnimalDetailsComponent} from './animals/animal.details.component'
import {ListAnimalsComponent} from './animals/list.animals.component'

const routes: Routes = [
  { path: 'users/register', component: RegisterComponent },
  { path: 'users/login', component: LoginComponent },
  { path: 'users/logout', component: LogoutComponent },
  { path: 'profile', component: ProfileComponent },
  { path: 'animals/create', component: CreateAnimalComponent },
  { path: 'animals/:id', component: AnimalDetailsComponent },
  { path: '', component: ListAnimalsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class RoutesModule {}