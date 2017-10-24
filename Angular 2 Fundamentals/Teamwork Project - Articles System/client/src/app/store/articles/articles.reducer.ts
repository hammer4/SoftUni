import { initialState } from './articles.state';

import {
  ADD_ARTICLE,
  ALL_ARTICLES,
  MINE_ARTICLES,
  ARTICLE_DETAILS,
  ARTICLE_DELETE,
  ARTICLE_LIKE,
  ARTICLE_ALL_REVIEWS,
  ARTICLE_ADD_REVIEW
} from './articles.actions';

function addArticle(state, action) {
  const result = action.result;
  return Object.assign({}, state, {
    articleAdded: result.success,
    articleAddedId: result.success ? result.article.id : null
  });
}
function allArticles(state, action) {
  return Object.assign({}, state, {
    allArticles: action.articles
  });
}

function mineArticles(state, action) {
  return Object.assign({}, state, {
    myArticles: action.articles
  });
}

function articleDetails(state, action) {
  console.log(action);
  return Object.assign({}, state, {
    articleDetails: action.article
  });
}
function articleLike(state, action) {
  if (action.result.success) {
      const currentArticleLikes = state.articleDetails.likes;
      const articleDetails = Object.assign({}, state.articleDetails, {
      likes: currentArticleLikes + 1
      });

      return Object.assign({}, state, {
        articleDetails
    });
  }
  return state;
}

function addReview(state, action) {
  const result = action.result;
  if (result.success) {
    const review = result.review;
    const articleReviews = state.articleReviews;
    return Object.assign({}, state, {
      articleReviews: [...articleReviews, review]
    });
  }
  return state;
}

function allReviews(state, action) {
  return Object.assign({}, state, {
    articleReviews: action.reviews
  });
}

function articleDelete(state, action) {
  const result = action.result;
  if (result.success) {
    const id = action.id;
    const articleIndex = state.myArticles.findIndex(c => c.id === id);

    if (articleIndex >= 0) {
      const myArticles = state.myArticles.slice(0);
      myArticles.slice(0).splice(articleIndex, 1);
      return Object.assign({}, state, {
        myArticles
      });
    }
  }
  return state;
}


export function articlesReducer (state = initialState, action) {
  switch (action.type) {
    case ADD_ARTICLE:
      return addArticle(state, action);
    case ALL_ARTICLES:
      return allArticles(state, action);
    case MINE_ARTICLES:
      return mineArticles(state, action);
    case ARTICLE_DETAILS:
      return articleDetails(state, action);
    case ARTICLE_DELETE:
      return articleDelete(state, action);
    case ARTICLE_LIKE:
      return articleLike(state, action);
    case ARTICLE_ADD_REVIEW:
      return addReview(state, action);
    case ARTICLE_ALL_REVIEWS:
      return allReviews(state, action);
    default:
      return state;
  }
}
