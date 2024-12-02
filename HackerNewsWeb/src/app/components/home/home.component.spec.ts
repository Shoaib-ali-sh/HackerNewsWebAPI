import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { HomeComponent } from './home.component';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ApiService } from '../../services/api.service';

describe('HomeComponent', () => {
  let component: HomeComponent;
  let fixture: ComponentFixture<HomeComponent>;
  let apiService: ApiService;

  const mockStories = [
    { title: 'Story 1', url: 'https://example.com/story1' },
    { title: 'Story 2', url: 'https://example.com/story2' },
    { title: 'Story 3', url: '' }, // Story without URL
  ];

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule,HomeComponent,FormsModule,CommonModule],
      providers: [ApiService],
    })
    .compileComponents();

    fixture = TestBed.createComponent(HomeComponent);
    component = fixture.componentInstance;
    apiService = TestBed.inject(ApiService);
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render stories in the template', () => {
    component.stories = mockStories; 
    fixture.detectChanges(); 

    const compiled = fixture.nativeElement;
    const storyElements = compiled.querySelectorAll('li');

    expect(storyElements.length).toBe(7);
    expect(storyElements[0].textContent).toContain('Story 1');
    expect(storyElements[2].textContent).toContain('Story 3');
  });

  it('should handle pagination', () => {
    component.currentPage = 1;
    component.onPageChange(2); 

    expect(component.currentPage).toBe(2); 
  });

});
