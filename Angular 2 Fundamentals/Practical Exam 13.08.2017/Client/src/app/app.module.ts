import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpModule} from '@angular/http'
import {UsersModule} from './users/users.module'
import {CoreModule} from './core/core.module'
import {RoutesModule} from './routes.module'
import {AnimalsModule} from './animals/animal.module'

import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    RoutesModule,
    UsersModule,
    CoreModule,
    HttpModule,
    AnimalsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
