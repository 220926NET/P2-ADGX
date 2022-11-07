import { ComponentFixture, TestBed, fakeAsync, tick } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ProfileComponent } from './profile.component';
import { ProfileService } from '../services/ProfileService';
import Profile from 'src/Models/Profile';
import { Observable } from 'rxjs';
import ResponseMessage from 'src/Models/ResponseMessage';
import { By } from '@angular/platform-browser';


describe('ProfileComponent', () => {

  const mockHobbies : string[] = ["run", "code", "game"]
  const mockInterest : string[] = ["skateboarding", "swimming"]; 
  const mockAboutMe : string = "13 time WWE Champion"
  const mockImageUrl : string = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRED0Wfr3ScQFESoWpiyZ1yBk1rFAj2laVCiQ&usqp=CAU"

  const mockProfile :Profile = {
    aboutMe : mockAboutMe, 
    hobbies : mockHobbies,
    interests : mockInterest,
    image : mockImageUrl
  }

  const mockSuccesfulResponseMessage : ResponseMessage = {
    data : mockProfile,
    message : "successfully retrieves profile details",
    success : true
  }

  const mockRes : Observable<ResponseMessage> = new Observable((subscriber) => {
    setTimeout(()=> {
      subscriber.next(mockSuccesfulResponseMessage);
      subscriber.complete();
    })
  })

  let component: ProfileComponent;
  let fixture: ComponentFixture<ProfileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      declarations: [ ProfileComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('profile component renders', () => {
    fixture = TestBed.createComponent(ProfileComponent)
    component = fixture.componentInstance;
    fixture.detectChanges()
    expect(component).toBeTruthy()
  })


  // this method tests the class variable userProfile : Profile has been correctly set 
  it('getProfileDetails shoulds return a userProfile object', fakeAsync (() => {
    fixture = TestBed.createComponent(ProfileComponent);
    component = fixture.componentInstance;
    let profileService = fixture.debugElement.injector.get(ProfileService);
    // spy allows you to return fake objects or values defined in a class method 
    let spy = spyOn(profileService, 'getProfileDetails').and.returnValue(mockRes); 
    fixture.detectChanges()
    // use fake async and tick to make a fake asynchonous subsciption finish
    tick();
    expect(component.userProfile).toBe(mockProfile)
  }));

  
  it('profile renders about me div', () => {
    const {debugElement} = fixture;
    // Another way of selecting tags  
    const divAboutMe =  debugElement.query(By.css('.profile-about-me-title'));
    expect(divAboutMe).toBeTruthy();
  })

  it('profile renders profile-hobbies div', () => {
    const divProfileHobbies = document.querySelector(".profile-hobbies")
    expect(divProfileHobbies).toBeTruthy();
  })

  it('profile renders profile-interests div', () => {
    const divProfileInterests = document.querySelector(".profile-interests")
    expect(divProfileInterests).toBeTruthy();
  })

  it('profile renders an image container', () => {
    const {debugElement} = fixture;
    // Another way of testing is by settign a data-testid attribute 
    // this enables loose coupling since classes may change 
    const imageContainer =  debugElement.query(By.css('[data-testid=profile-image-container]'));
    expect(imageContainer).toBeTruthy()

  });

  it('profile renders a container for user posts', () => {
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('.app-user-posts-container')).toBeTruthy()
  });
 
});
