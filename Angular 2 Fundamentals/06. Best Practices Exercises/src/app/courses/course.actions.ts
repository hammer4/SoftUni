import { NgRedux } from 'ng2-redux';
import { IAppState } from '../store';
import { Injectable } from '@angular/core';
export const FILTER_COURSES = 'courses/FILTER';
export const REQUEST_COURSES_SUCCESS = 'courses/ALL'
import {CourseService} from './course.service'

@Injectable() // Add it to the providers array
export class CourseActions {
  constructor (private ngRedux: NgRedux<IAppState>, private courseService: CourseService) { }

  filterCourses(searchText: string) {
    this.ngRedux.dispatch({
      type: FILTER_COURSES,
      searchText
    });
  }

  getCourses() {
    this.courseService.getCourses()
      .subscribe(courses => {
        this.ngRedux.dispatch({
          type: REQUEST_COURSES_SUCCESS,
          courses
        })
      })
  }
}
