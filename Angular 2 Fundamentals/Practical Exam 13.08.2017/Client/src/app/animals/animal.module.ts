import {NgModule} from '@angular/core'
import {CommonModule} from '@angular/common'
import {FormsModule} from '@angular/forms'
import {AnimalsService} from './animal.service'
import {RouterModule} from '@angular/router'

import {CreateAnimalComponent} from './create.animal.component'
import {AnimalDetailsComponent} from './animal.details.component'
import {ListAnimalsComponent} from './list.animals.component'

@NgModule({
  imports: [FormsModule, CommonModule, RouterModule],
  declarations: [CreateAnimalComponent, AnimalDetailsComponent, ListAnimalsComponent],
  providers: [AnimalsService],
  exports: []
})

export class AnimalsModule {}