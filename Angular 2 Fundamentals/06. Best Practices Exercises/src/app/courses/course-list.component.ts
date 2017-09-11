import { Component, OnInit } from '@angular/core';
import { CourseService } from './course.service';
import { Course } from './course';
import { FilterTextComponent, FilterService } from '../blocks/filter-text';
import { NgRedux, select } from 'ng2-redux';
import { Observable } from 'rxjs/Observable';
import {CourseActions} from './course.actions'
import {IAppState} from '../store'

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.css']
})
export class CourseListComponent implements OnInit {
  @select('filteredCourses') filteredCourses: Observable<Course>;

  constructor(
  private ngRedux: NgRedux<IAppState>,
  private courseActions: CourseActions) {  } 


  filterChanged(searchText: string) {
    console.log('user searched: ', searchText);
    this.courseActions.filterCourses(searchText);
  }
  

  getCourses() {
    this.courseActions.getCourses()
  }

  ngOnInit() {
    this.courseActions.getCourses();
    componentHandler.upgradeDom();
  }
}
