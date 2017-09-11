import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'app works!';
  public menuItems = [
    { caption: 'Courses', link: '/courses' },
  ];

  resetDb() {
    console.log('resetting DB!!!!');
  }
}
