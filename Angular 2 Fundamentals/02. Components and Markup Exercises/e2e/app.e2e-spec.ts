import { ComponentsAndMarkupExercisesPage } from './app.po';

describe('components-and-markup-exercises App', () => {
  let page: ComponentsAndMarkupExercisesPage;

  beforeEach(() => {
    page = new ComponentsAndMarkupExercisesPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!');
  });
});
