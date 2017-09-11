import {NgModule} from '@angular/core'
import {RouterModule, Routes} from '@angular/router'

import {RegisterComponent} from './users/register.component' 
import {LoginComponent} from './users/login.component'
import {LogoutComponent} from './users/logout.component'

const routes: Routes = [
  { path: 'users/register', component: RegisterComponent },
  { path: 'users/login', component: LoginComponent },
  { path: 'users/logout', component: LogoutComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class CarRoutesModule {}