import { InMemoryDbService, createErrorResponse, HttpMethodInterceptorArgs, createObservableResponse } from 'angular-in-memory-web-api';


export class InMemoryStoryService implements InMemoryDbService {
  // uncomment this function to force an error
  // protected get(interceptorArgs: HttpMethodInterceptorArgs) {
  //   let resp = createErrorResponse(500, 'this is a forced error from the in-memory api');
  //   return createObservableResponse(resp);
  // }

  /**
  * Creates fresh copy of data each time.
  * Safe for consuming service to morph arrays and objects.
  */
  createDb() {
    let courses = [
      {
        "id": 1,
        "name": "Building Apps with React",
        "topic": "ReactJS"
      },
      {
        "id": 2,
        "name": "Building Apps with Angular",
        "topic": "AngularJS"
      },
      {
        "id":3,
        "name": "Building Apps with Angular and Redux",
        "topic": "Angular and Redux"
      }
    ];

    return { courses };
  }
}