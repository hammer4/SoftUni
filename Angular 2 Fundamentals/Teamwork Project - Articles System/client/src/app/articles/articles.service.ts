import { Injectable } from '@angular/core';

import { HttpService } from '../core/http.service';

@Injectable()
export class ArticlesService {
  constructor (private httpService: HttpService) { }

  addArticle (article) {
    return this.httpService.post('articles/create', article, true);
  }

  allArticles (page = 1, search = null) {
    let url = `articles/all?page=${page}`;
    if (search) {
      url += `&search=${search}`;
    }
    return this.httpService.get(url);
  }

  details (id) {
    return this.httpService.get(`articles/details/${id}`, true);
  }

  like(id) {
    return this.httpService.post(`articles/details/${id}/like`, {}, true);
  }

  allReviews (id) {
    return this.httpService.get(`articles/details/${id}/reviews`, true);
  }

  submitReview (id, review) {
    return this.httpService.post(
      `articles/details/${id}/reviews/create`,
      review,
      true);
  }

  mine () {
    return this.httpService.get('articles/mine', true);
  }

  delete (id) {
    return this.httpService.post(`articles/delete/${id}`, {}, true);
  }
}