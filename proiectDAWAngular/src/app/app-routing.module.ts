import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterComponent } from './components/register/register.component';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './components/login/login.component';
import { QuestionFormComponent } from './components/question-form/question-form.component';
import { FeedComponent } from './components/feed/feed.component';

const routes: Routes = [
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'add-question', component: QuestionFormComponent },
  { path: 'feed', component: FeedComponent }
];

@NgModule({
  declarations: [],
  imports: [CommonModule ,RouterModule.forRoot(routes)]
})
export class AppRoutingModule { }
