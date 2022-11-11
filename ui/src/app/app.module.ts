import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { PostFeedComponent } from "./components/post-feed/post-feed.component";
import { LoginComponent } from "./components/login/login.component";
import { RegisterComponent } from "./components/register/register.component";
import { ProfileComponent } from "./components/profile/profile.component";
import { HomeComponent } from "./components/home/home.component";
import { UsersPostsComponent } from "./components/profile/users-posts/users-posts.component";
import { NavBarComponent } from "./components/nav-bar/nav-bar.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { MatCardModule } from "@angular/material/card";
import { MatSidenavModule } from "@angular/material/sidenav";
import { CommentFeedComponent } from "./components/comment-feed/comment-feed.component";
import { MatDividerModule } from "@angular/material/divider";
import { CommentFormComponent } from "./components/comment-form/comment-form.component";
import { PostFormComponent } from "./components/post-form/post-form.component";

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    ProfileComponent,
    UsersPostsComponent,
    HomeComponent,
    NavBarComponent,
    PostFeedComponent,
    CommentFeedComponent,
    UsersPostsComponent,
    CommentFormComponent,
    PostFormComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatCardModule,
    MatSidenavModule,
    MatDividerModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
