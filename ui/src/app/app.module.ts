<<<<<<< HEAD
<<<<<<< HEAD
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ProfileComponent } from './profile/profile.component';
import { PostComponent } from './post/post.component';
=======
=======
>>>>>>> 1775a9f6d90054658dd1c0672ff840cafa86c6d7
import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
<<<<<<< HEAD
import { LoginComponent } from "./login/login.component";
import { RegisterComponent } from "./register/register.component";
import { ProfileComponent } from "./profile/profile.component";
import { HomeComponent } from "./home/home.component";
import { UsersPostsComponent } from "./profile/users-posts/users-posts.component";
import { ProfileService } from "./services/ProfileService";
<<<<<<< HEAD
>>>>>>> b49bba95910a6d7dd9ab934618437e208b0ca6c8
=======
import { PostComponent } from "./post/post.component";
>>>>>>> 1775a9f6d90054658dd1c0672ff840cafa86c6d7
=======
import { PostFeedComponent } from "./components/post-feed/post-feed.component";
import { LoginComponent } from "./components/login/login.component";
import { RegisterComponent } from "./components/register/register.component";
import { ProfileComponent } from "./components/profile/profile.component";
import { HomeComponent } from "./components/home/home.component";
import { UsersPostsComponent } from "./components/profile/users-posts/users-posts.component";
import { PostComponent } from "./components/post/post.component";
import { NavBarComponent } from "./components/nav-bar/nav-bar.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { MatCardModule } from "@angular/material/card";
import { MatSidenavModule } from "@angular/material/sidenav";
import { CommentFeedComponent } from "./components/comment-feed/comment-feed.component";
import { MatDividerModule } from "@angular/material/divider";
>>>>>>> d0e4a1bad83b9d4b80caf50fba097a17a18f060f

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    ProfileComponent,
<<<<<<< HEAD
<<<<<<< HEAD
    PostComponent
=======
    UsersPostsComponent,
    HomeComponent,
>>>>>>> b49bba95910a6d7dd9ab934618437e208b0ca6c8
=======
    PostComponent,
    UsersPostsComponent,
    HomeComponent,
<<<<<<< HEAD
>>>>>>> 1775a9f6d90054658dd1c0672ff840cafa86c6d7
=======
    NavBarComponent,
    PostFeedComponent,
    CommentFeedComponent,
    UsersPostsComponent,
>>>>>>> d0e4a1bad83b9d4b80caf50fba097a17a18f060f
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
