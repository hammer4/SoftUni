import { ServicesAndDiExercisesPage } from './app.po';

describe('services-and-di-exercises App', () => {
  let page: ServicesAndDiExercisesPage;

  beforeEach(() => {
    page = new ServicesAndDiExercisesPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!');
  });
});
