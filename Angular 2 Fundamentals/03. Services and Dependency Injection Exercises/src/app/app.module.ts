import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HttpModule }from '@angular/http'
import GitHubData from './services/github.data.service'
import {ProfileComponent} from './components/profile/profile.component'
import {FollowersComponent } from './components/followers/followers.component'
import {ReposComponent} from './components/repos/repos.component'
import {ContributorsComponent} from './components/contributors/contributors.component'

@NgModule({
  declarations: [
    AppComponent,
    ProfileComponent,
    FollowersComponent,
    ReposComponent,
    ContributorsComponent
  ],
  imports: [
    BrowserModule,
    HttpModule
  ],
  providers: [GitHubData],
  bootstrap: [AppComponent]
})
export class AppModule { }
