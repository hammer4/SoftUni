import { CourseLibraryPage } from './app.po';

describe('course-library App', function() {
  let page: CourseLibraryPage;

  beforeEach(() => {
    page = new CourseLibraryPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
