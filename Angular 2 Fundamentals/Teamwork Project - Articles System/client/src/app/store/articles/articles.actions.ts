import { Injectable } from '@angular/core';

import { NgRedux } from 'ng2-redux';
import { IAppState } from '..';

import { ArticlesService } from '../../articles/articles.service';

export const ADD_ARTICLE = 'articles/ADD';
export const ALL_ARTICLES = 'articles/ALL';
export const ARTICLE_DETAILS = 'articles/DETAILS';
export const ARTICLE_DELETE = 'articles/DELETE';
export const ARTICLE_LIKE = 'articles/LIKE';
export const MINE_ARTICLES = 'articles/MINE';
export const ARTICLE_ADD_REVIEW = 'articles/ADD_REVIEW';
export const ARTICLE_ALL_REVIEWS = 'articles/ALL_REVIEWS';


@Injectable()
export class ArticlesActions {
  constructor (
    private ngRedux: NgRedux<IAppState>,
    private articlesService: ArticlesService) { }

  addArticle (article) {
    this.articlesService
      .addArticle(article)
      .subscribe(result => {
        this.ngRedux.dispatch({
          type: ADD_ARTICLE,
          result
        });
      });
  }

  allArticles (page = 1, search= null) {
    this.articlesService
      .allArticles(page, search)
      .subscribe(articles => {
        this.ngRedux.dispatch({
          type: ALL_ARTICLES,
          articles
        });
      });
  }

  details (id) {
    this.articlesService
      .details(id)
      .subscribe(article => {
        this.ngRedux.dispatch({
          type: ARTICLE_DETAILS,
          article
        });
      });
  }

  like (id) {
    this.articlesService
      .like(id)
      .subscribe(result => {
        this.ngRedux.dispatch({
          type: ARTICLE_LIKE,
          result
        });
      });
  }

  mine () {
    this.articlesService
      .mine()
      .subscribe(articles => {
        this.ngRedux.dispatch({
          type: MINE_ARTICLES,
          articles
        });
      });
  }

  allReviews (id) {
    this.articlesService
      .allReviews(id)
      .subscribe(reviews => {
        this.ngRedux.dispatch({
          type: ARTICLE_ALL_REVIEWS,
          reviews
        })
      })
  }

  submitReview (id, review) {
    this.articlesService
      .submitReview(id, review)
      .subscribe(result => {
        this.ngRedux.dispatch({
          type: ARTICLE_ADD_REVIEW,
          result
        });
      });
  } 

  delete (id) {
    this.articlesService
      .delete(id)
      .subscribe(result => {
        this.ngRedux.dispatch({
          type: ARTICLE_DELETE,
          result,
          id
        });
      });
  }
}