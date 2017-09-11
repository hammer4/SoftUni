import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule} from '@angular/router';
import { FormsModule } from '@angular/forms';

import { AddCarComponent } from './add-car.component';
import { ListCarsComponent } from './list-cars.component';
import { CarDetailsComponent } from './car-details.component';

import { CarsService } from './cars.service';

import { CarsActions } from '../store/cars/cars.actions';

@NgModule({
  imports: [
    FormsModule,
    RouterModule,
    CommonModule
  ],
  declarations: [
    AddCarComponent,
    ListCarsComponent,
    CarDetailsComponent
  ],
  providers: [
    CarsService,
    CarsActions
  ]
})
export class CarsModule { }