import {NgModule} from '@angular/core'
import {RouterModule} from '@angular/router'
import {CommonModule} from '@angular/common'
import {NavbarComponent} from './navbar.component'
import {HttpService} from './http.service'

@NgModule({
  declarations: [NavbarComponent],
  imports: [RouterModule, CommonModule],
  providers: [HttpService],
  exports: [NavbarComponent]
})

export class CoreModule {}