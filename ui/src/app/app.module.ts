import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { ProfileDetailsComponent } from "./components/profile-details/profile-details.component";
import { PostFeedComponent } from "./components/post-feed/post-feed.component";
import { LoginComponent } from "./components/login/login.component";
import { RegisterComponent } from "./components/register/register.component";
import { ProfileComponent } from "./components/profile/profile.component";
import { HomeComponent } from "./components/home/home.component";
import { UsersPostsComponent } from "./components/profile/users-posts/users-posts.component";
import { NavBarComponent } from "./components/nav-bar/nav-bar.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { CommentFeedComponent } from "./components/comment-feed/comment-feed.component";
import { CommentFormComponent } from "./components/comment-form/comment-form.component";
import { MatDividerModule } from "@angular/material/divider";
import { MatCardModule } from "@angular/material/card";
import { MatSidenavModule } from "@angular/material/sidenav";
import { PostComponent } from "./components/post/post.component";
import { PostLikeComponent } from './components/like/post-like/post-like.component';
import { PostLikeCounterComponent } from './components/like/post-like-counter/post-like-counter.component';
import { PostLikeButtonComponent } from './components/like/post-like-button/post-like-button.component';
import { ProfileOthersComponent } from './components/profile-others/profile-others.component';
import { httpInterceptorProviders } from "./http-interceptors";
import { PostFeedItemComponent } from './components/post-feed-item/post-feed-item.component';
import { PostCommentButtonComponent } from './components/post-comment-button/post-comment-button.component';
import { PostDeleteButtonComponent } from './components/post-delete-button/post-delete-button.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    ProfileComponent,
    UsersPostsComponent,
    HomeComponent,
    ProfileDetailsComponent,
    NavBarComponent,
    PostFeedComponent,
    CommentFeedComponent,
    UsersPostsComponent,
    CommentFormComponent,
    PostComponent,
    PostComponent,
    PostLikeComponent,
    PostLikeCounterComponent,
    PostLikeButtonComponent,
    ProfileOthersComponent,
    PostFeedItemComponent,
    PostCommentButtonComponent,
    PostDeleteButtonComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatDividerModule,
    MatCardModule,
    MatSidenavModule,
  ],
  providers: [httpInterceptorProviders],
  bootstrap: [AppComponent],
})
export class AppModule {}
