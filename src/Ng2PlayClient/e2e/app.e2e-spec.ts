import { Ng2PlayClientPage } from './app.po';

describe('ng2-play-client App', function() {
  let page: Ng2PlayClientPage;

  beforeEach(() => {
    page = new Ng2PlayClientPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
