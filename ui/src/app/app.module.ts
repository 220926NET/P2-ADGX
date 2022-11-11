import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { ProfileService } from "./services/ProfileService";
import { ProfileDetailsComponent } from './profile-details/profile-details.component';
import { PostFeedComponent } from "./components/post-feed/post-feed.component";
import { LoginComponent } from "./components/login/login.component";
import { RegisterComponent } from "./components/register/register.component";
import { ProfileComponent } from "./components/profile/profile.component";
import { HomeComponent } from "./components/home/home.component";
import { UsersPostsComponent } from "./components/profile/users-posts/users-posts.component";
import { PostComponent } from "./components/post/post.component";
import { NavBarComponent } from "./components/nav-bar/nav-bar.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { CommentFeedComponent } from "./components/comment-feed/comment-feed.component";
import { CommentFormComponent } from "./comment-form/comment-form.component";



@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    ProfileComponent,
    PostComponent,
    UsersPostsComponent,
    HomeComponent,
    ProfileDetailsComponent,
    NavBarComponent,
    PostFeedComponent,
    CommentFeedComponent,
    UsersPostsComponent,
    CommentFormComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
  
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
