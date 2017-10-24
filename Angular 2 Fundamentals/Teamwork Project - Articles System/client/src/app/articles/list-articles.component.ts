import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { NgRedux } from 'ng2-redux';
import { IAppState} from '../store';

import { ArticlesActions } from '../store/articles/articles.actions';

@Component({
  selector: 'list-articles',
  templateUrl: './list-articles.component.html'
  
})
export class ListArticlesComponent implements OnInit{
  page: number = 1;
  searchText: string = '';
  articles: Array<object> = [];

  constructor (
    private ngRedux: NgRedux<IAppState>,
    private route: ActivatedRoute,
    private router: Router,
    private articlesActions: ArticlesActions
  ) { }

  ngOnInit() {
    this.route.queryParams
      .subscribe(params => {
        this.page = +params['page'] || 1;
        this.searchText = params['search'];
        this.articlesActions.allArticles(this.page, this.searchText);
        this.ngRedux
        .select(state => state.articles.allArticles)
        .subscribe(articles => this.articles = articles);
      })
  }

  search () {
    this.router.navigateByUrl(`articles/all?search=${this.searchText}`);
  }

  prevPage () {
    if (this.page === 1) {
      return;
    }

    const url = this.getUrl(this.page - 1);
    this.router.navigateByUrl(url);
  }

  nextPage () {
    if (this.articles.length === 0 || this.articles.length < 10) {
      return;
    }
    const url = this.getUrl(this.page + 1);
    this.router.navigateByUrl(url);
  }

  private getUrl(page) {
    let url = `articles/all?page=${page}`;
    if (this.searchText) {
      url += `^search=${this.searchText }`;
    }
    
    return url;
  }
}