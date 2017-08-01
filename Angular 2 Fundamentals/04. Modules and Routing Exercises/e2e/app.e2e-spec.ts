import { ModulesAndRoutingExercisesPage } from './app.po';

describe('modules-and-routing-exercises App', () => {
  let page: ModulesAndRoutingExercisesPage;

  beforeEach(() => {
    page = new ModulesAndRoutingExercisesPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!');
  });
});
