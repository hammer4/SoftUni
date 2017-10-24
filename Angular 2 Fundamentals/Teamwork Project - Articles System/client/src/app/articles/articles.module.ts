import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule} from '@angular/router';
import { FormsModule } from '@angular/forms';

import { AddArticleComponent } from './add-article.component';
import { ListArticlesComponent } from './list-articles.component';
import { ArticleDetailsComponent } from './article-details.component';

import { ArticlesService } from './articles.service';

import { ArticlesActions } from '../store/articles/articles.actions';

@NgModule({
  imports: [
    FormsModule,
    RouterModule,
    CommonModule
  ],
  declarations: [
    AddArticleComponent,
    ListArticlesComponent,
    ArticleDetailsComponent
  ],
  providers: [
    ArticlesService,
    ArticlesActions
  ]
})
export class ArticlesModule { }