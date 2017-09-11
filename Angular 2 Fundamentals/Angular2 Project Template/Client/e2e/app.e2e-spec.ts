import { ClientPage } from './app.po';

describe('client App', () => {
  let page: ClientPage;

  beforeEach(() => {
    page = new ClientPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!');
  });
});
