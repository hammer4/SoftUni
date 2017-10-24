import {NgModule} from '@angular/core'
import {CommonModule} from '@angular/common'
import {FormsModule} from '@angular/forms'
import {RouterModule} from '@angular/router'
import {UsersService} from './users.service'

import {RegisterComponent} from './register.component'
import {LoginComponent} from './login.component'
import {LogoutComponent} from './logout.component'
import {ProfileComponent} from './profile.component'

@NgModule({
  imports: [FormsModule, RouterModule, CommonModule],
  declarations: [RegisterComponent, LoginComponent, LogoutComponent, ProfileComponent],
  providers: [UsersService],
  exports: []
})

export class UsersModule {}