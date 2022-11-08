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
>>>>>>> 1775a9f6d90054658dd1c0672ff840cafa86c6d7
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
