import { ComponentFixture, TestBed} from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { UsersPostsComponent } from './users-posts.component';

describe('UsersPostsComponent', () => {
  let component: UsersPostsComponent;
  let fixture: ComponentFixture<UsersPostsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      declarations: [ UsersPostsComponent ]
    })
    .compileComponents();
    fixture = TestBed.createComponent(UsersPostsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should create a grid container', ()=> {
    const userPostGridContainer = document.querySelector(".grid-container")
    expect(userPostGridContainer).toBeTruthy();
  })
});
