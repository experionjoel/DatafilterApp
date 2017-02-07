import { DataFilterClientPage } from './app.po';

describe('data-filter-client App', function() {
  let page: DataFilterClientPage;

  beforeEach(() => {
    page = new DataFilterClientPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
