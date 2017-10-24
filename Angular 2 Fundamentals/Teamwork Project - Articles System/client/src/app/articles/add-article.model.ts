export class AddArticleModel {
  constructor (
    public name?: string,
    public author?: string,
    public year?: number,
    public image?: string,
    public text?: string
  ) { }
}
