import {NgModule} from '@angular/core'
import {CommonModule} from '@angular/common'
import {RouterModule} from '@angular/router'

import {HomeComponent} from './home/home.component'
import {DataService} from '../services/data.service'
import {BorderRadiusDirective} from '../directives/border.radius.directive'

@NgModule({
  imports: [CommonModule, RouterModule],
  declarations: [HomeComponent, BorderRadiusDirective],
  providers: [DataService],
  exports: [HomeComponent]
})

export class HomeModule {}