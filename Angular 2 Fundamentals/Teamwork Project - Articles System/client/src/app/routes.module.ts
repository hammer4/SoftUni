import { NgModule } from '@angular/core';
import { RouterModule, Routes} from '@angular/router';

import { PrivateRoute } from './core/private-route';

import { StatsComponent} from './stats/stats.component';
import { RegisterComponent} from './users/register.component';
import { LoginComponent} from './users/login.component';
import { AddArticleComponent } from './articles/add-article.component';
import { ListArticlesComponent } from './articles/list-articles.component';
import { ArticleDetailsComponent } from './articles/article-details.component';
import { ProfileComponent } from './users/profile.component';
const routes: Routes = [
  { path: '', component: StatsComponent },
  { path: 'users/register', component: RegisterComponent},
  { path: 'users/login', component: LoginComponent},
  { path: 'users/profile', component: ProfileComponent},
  { 
    path: 'articles/add', 
    component: AddArticleComponent,
    canActivate: [PrivateRoute]
   },
  { path: 'articles/all', component: ListArticlesComponent},
  { path: 'articles/details/:id', component: ArticleDetailsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class ArticleRoutesModule { }