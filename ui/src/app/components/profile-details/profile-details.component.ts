import { Component, Input, OnInit } from '@angular/core';
import { ProfileService } from '../../services/ProfileService';

@Component({
  selector: 'app-profile-details',
  templateUrl: './profile-details.component.html',
  styleUrls: ['./profile-details.component.css']
})
export class ProfileDetailsComponent implements OnInit {

  isAboutMeEditable : boolean = false; 
  isMyHobbiesEditable : boolean = false; 
  isMyInterestsEditable : boolean = false; 

  
  

 @Input() myHobbies : string[]= []; 
  @Input() myInterests : string[] = [];
 @Input() myAboutMe : string = "";

 _mockUserId = 2; 

  constructor(private _profileService : ProfileService) { }

  ngOnInit(): void {
   
  }
  
  setAboutMeEditable() {
    
    this.isAboutMeEditable = !this.isAboutMeEditable; 
    
  }

  setMyHobbiesEditable(){
    this.isMyHobbiesEditable = !this.isMyHobbiesEditable
  }
  setMyInterestsEditable(){
    this.isMyInterestsEditable = !this.isMyInterestsEditable
  }

  
  addHobbyItem(){
    // if previous array is empty dont add
    if(this.myHobbies.length < 6){
      this.myHobbies.push("");
    }
  
  }

  deleteHobbyItem(){
    this.myHobbies.pop();
  }

  addInterestItem(value : any){
    if(this.myInterests.length < 6){
      this.myInterests.push("");
    }
    
  }

  deleteInterestItem(){
    this.myInterests.pop();
  }
  //TODO: on save exit edit view and set a timemout

  saveAboutMe(aboutMe : HTMLElement){
    this.setAllEditablesToFalse();
    console.log(aboutMe.textContent)
    this._profileService.postProfileAboutMe(aboutMe.textContent!).subscribe(res => {
      console.log(res);
    });
  }
  //TODO: on save exit edit view and set a timemout

  saveInterests(list : HTMLElement){
    this.setAllEditablesToFalse();
    const interests : string[] = [];
    for(let i = 0; i < list.childNodes.length - 1; i++){
      let element = list.childNodes[i];
      if(element.textContent?.trim() != ""){
        interests.push(element.textContent as string);
      }
    }
    this._profileService.postProfileInterests(interests, this._mockUserId).subscribe(res => {
      console.log(res);
    })

  
  }

  //TODO: on save exit edit view and set a timemout
  saveHobbies(list :HTMLElement){
    this.setAllEditablesToFalse();
    const hobbies : string[] = [];
    for(let i = 0; i < list.childNodes.length - 1; i++){
      let element = list.childNodes[i];
      if(element.textContent?.trim() != ""){
        hobbies.push(element.textContent as string);
      }
    }
    this._profileService.postProfileHobbies(hobbies, this._mockUserId).subscribe(res => {
      console.log(res);
    })
    
  }

  setAllEditablesToFalse(){
    this.isAboutMeEditable = false;
    this.isMyHobbiesEditable = false; 
    this.isMyInterestsEditable = false; 
  }
}
