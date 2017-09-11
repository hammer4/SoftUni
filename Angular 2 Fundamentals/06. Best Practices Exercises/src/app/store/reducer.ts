import { Course } from '../courses/course';
import { IAppState } from './IAppState';
import {CourseActions, REQUEST_COURSES_SUCCESS, FILTER_COURSES} from '../courses/course.actions'

const allCourses = []

const initialState: IAppState = {
  courses: allCourses,
  filteredCourses: allCourses
}

function filterCourses(state, action) : IAppState {
  return Object.assign({}, state, {
    filteredCourses: state.courses.filter(c => {
      return c.name.toLowerCase()
        .indexOf(action.searchText.toLowerCase()) > -1;
    })
  })
}
function getCourses(state, action): IAppState {
  return Object.assign({}, state, {
    courses: action.courses,
    filteredCourses: action.courses
  });
}
export function reducer(state = initialState, action) {
  switch (action.type) {
    case FILTER_COURSES:
      return filterCourses(state, action);
    case REQUEST_COURSES_SUCCESS:
      return getCourses(state, action);
    default: 
      return state;
  }
}


