import { Component, OnInit } from '@angular/core';
import { OtherProfileService } from 'src/app/services/other-profile.service';
import { ActivatedRoute } from '@angular/router';
import ProfilePost from 'src/Models/Profile/ProfilePost';



@Component({
  selector: 'app-profile-others',
  templateUrl: './profile-others.component.html',
  styleUrls: ['./profile-others.component.css']
})
export class ProfileOthersComponent implements OnInit {
 
  userId : number = 0; 

  myHobbies : string[]= []; 
  myInterests : string[] = [];
  myAboutMe : string = "";
  myImage : string = "";

  isViewGallery : boolean = false; 

  posts : ProfilePost[]  = []; 

  constructor(private route : ActivatedRoute, private _otherProfileServce : OtherProfileService) { 
    
    this.userId = this.route.snapshot.params['id']
  }

  ngOnInit(): void {
    console.log('user id is ' + this.userId);
    this._otherProfileServce.getUserProfileDetails(this.userId).subscribe(res => {
      this.myHobbies = res.data.hobbies;
      this.myInterests = res.data.interests;
      this.myAboutMe = res.data.aboutMe;
      this.myImage = res.data.image
    })

    this._otherProfileServce.getUserPosts(this.userId).subscribe(res => { 
      console.log(res);
      this.posts = res.data;}
      )
  }
  setView() {
    this.isViewGallery = !this.isViewGallery;
  }

  
}
