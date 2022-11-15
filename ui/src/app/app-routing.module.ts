import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { LoginComponent } from "./components/login/login.component";
import { RegisterComponent } from "./components/register/register.component";
import { ProfileComponent } from "./components/profile/profile.component";
import { PostComponent } from "./components/post/post.component";
import { PostFeedComponent } from "./components/post-feed/post-feed.component";
import { ProfileOthersComponent } from "./components/profile-others/profile-others.component";

const routes: Routes = [
  { path: "login", component: LoginComponent },
  { path: "register", component: RegisterComponent },
  { path: "profile", component: ProfileComponent },
  { path: "feed", component: PostFeedComponent },
  {path : "feed/profile/:id", component: ProfileOthersComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
