import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import {DetailsComponent} from './details.component';
import {ControlsComponent} from './controls.component';

@NgModule({
  declarations: [
    AppComponent,
    DetailsComponent,
    ControlsComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
