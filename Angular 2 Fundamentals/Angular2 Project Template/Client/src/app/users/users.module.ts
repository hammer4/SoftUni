import {NgModule} from '@angular/core'
import {CommonModule} from '@angular/common'
import {FormsModule} from '@angular/forms'
import {UsersService} from './users.service'

import {RegisterComponent} from './register.component'
import {LoginComponent} from './login.component'
import {LogoutComponent} from './logout.component'

@NgModule({
  imports: [FormsModule],
  declarations: [RegisterComponent, LoginComponent, LogoutComponent],
  providers: [UsersService],
  exports: []
})

export class UsersModule {}