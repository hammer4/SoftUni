import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { CONFIG } from '../shared';
import {Observable} from 'rxjs/Rx';
import '../rxjs-operators';
import { Course } from './course';
import { SpinnerService } from '../blocks/spinner';
import { ExceptionService } from '../blocks/exception.service';

// import { /* ExceptionService, */ SpinnerService } from '../blocks/blocks';
// import { CONFIG, MessageService } from '../shared/shared';


let coursesUrl = CONFIG.baseUrls.courses;


@Injectable()
export class CourseService {
  constructor(
    private _http: Http,
    private _spinnerService: SpinnerService,
    private _exceptionService: ExceptionService
  ) { }

  addCourse(course: Course) {
    let body = JSON.stringify(course);
    this._spinnerService.show();
    return this._http
      .post(`${coursesUrl}`, body)
      .map(res => res.json().data)
      .catch(this._exceptionService.catchBadResponse)
      .finally(() => this._spinnerService.hide());
  }

  deleteCourse(course: Course) {
    this._spinnerService.show();
    return this._http
      .delete(`${coursesUrl}/${course.id}`)
      .catch(this._exceptionService.catchBadResponse)
      .finally(() => this._spinnerService.hide());
  }

  getCourses() {
    this._spinnerService.show();

    return this._http.get('/api/courses')
      .map((response: Response) => <Course[]>response.json().data)
      .catch(this._exceptionService.catchBadResponse)
      .finally(() => this._spinnerService.hide());
  }

  getCourse(id: number) {
    this._spinnerService.show();
    return this._http.get(`${coursesUrl}/${id}`)
      .map((response: Response) => response.json().data)
      .catch(this._exceptionService.catchBadResponse)
      .finally(() => this._spinnerService.hide());
  }


  updateCourse(course: Course) {
    let body = JSON.stringify(course);
    this._spinnerService.show();

    return this._http
      .put(`${coursesUrl}/${course.id}`, body)
      .catch(this._exceptionService.catchBadResponse)
      .finally(() => this._spinnerService.hide());
  }
}
