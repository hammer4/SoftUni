import { Component, OnInit } from '@angular/core';

import { NgRedux } from 'ng2-redux';
import { IAppState } from '../store';


import { ArticlesActions } from '../store/articles/articles.actions';

@Component({
  selector: 'profile',
  templateUrl: './profile.component.html'
})

export class ProfileComponent implements OnInit{
  articles: Array<object> = [];
  constructor (
    private ngRedux: NgRedux<IAppState>,
    private articlesActions: ArticlesActions
  ) { }

  ngOnInit () {
    this.articlesActions.mine();
    this.ngRedux
      .select(state => state.articles.myArticles)
      .subscribe(articles => this.articles = articles);
  }
  
  delete (id) {
    this.articlesActions.delete(id);
  }
}