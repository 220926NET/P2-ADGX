import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
<<<<<<< Updated upstream
import { LoginComponent } from "./login/login.component";
import { RegisterComponent } from "./register/register.component";
import { ProfileComponent } from "./profile/profile.component";
import { HomeComponent } from "./home/home.component";
import { PostFeedComponent } from './post-feed/post-feed.component';
=======
import { LoginComponent } from "./components/login/login.component";
import { RegisterComponent } from "./components/register/register.component";
import { ProfileComponent } from "./components/profile/profile.component";
import { HomeComponent } from "./components/home/home.component";
import { UsersPostsComponent } from "./components/profile/users-posts/users-posts.component";
import { PostComponent } from "./components/post/post.component";
import { NavBarComponent } from "./components/nav-bar/nav-bar.component";
>>>>>>> Stashed changes
import { UsersPostsComponent } from "./profile/users-posts/users-posts.component";
import { ProfileService } from "./services/ProfileService";
import { PostComponent } from "./post/post.component";

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    ProfileComponent,
    PostComponent,
    UsersPostsComponent,
    HomeComponent,
    NavBarComponent,
    PostFeedComponent,
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
