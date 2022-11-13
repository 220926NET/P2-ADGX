import { ComponentFixture, TestBed } from '@angular/core/testing';

<<<<<<<< HEAD:ui/src/app/components/post-form/post-form.component.spec.ts
import { PostFormComponent } from './post-form.component';

describe('PostFormComponent', () => {
  let component: PostFormComponent;
  let fixture: ComponentFixture<PostFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PostFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PostFormComponent);
========
import { ProfileDetailsComponent } from './profile-details.component';

describe('ProfileDetailsComponent', () => {
  let component: ProfileDetailsComponent;
  let fixture: ComponentFixture<ProfileDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProfileDetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProfileDetailsComponent);
>>>>>>>> a68944bfd72bc077c3533f4575dd00d8363c3d7d:ui/src/app/components/profile-details/profile-details.component.spec.ts
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
