
export interface IArticlesState {
  articleAdded: boolean;
  articleAddedId: number;
  allArticles: Array<object>;
  articleDetails: object;
  articleReviews: Array<object>;
  myArticles: Array<object>;
}

export const initialState: IArticlesState = {
  articleAdded: false,
  articleAddedId: null,
  allArticles: [],
  articleDetails: {},
  articleReviews: [],
  myArticles: []
};
