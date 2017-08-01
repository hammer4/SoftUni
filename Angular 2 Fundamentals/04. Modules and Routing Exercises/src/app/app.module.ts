import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HomeModule} from './components/home.module'
import {AppRoutesModule} from './routes.module'

import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HomeModule,
    AppRoutesModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
