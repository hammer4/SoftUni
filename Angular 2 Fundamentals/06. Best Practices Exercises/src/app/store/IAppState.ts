import { Course } from '../courses/course';

export interface IAppState {
  courses: Course[]
  filteredCourses: Course[]
}
