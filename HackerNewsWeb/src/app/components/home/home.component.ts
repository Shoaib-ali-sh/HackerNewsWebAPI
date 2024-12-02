import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { NgxPaginationModule } from 'ngx-pagination';
import { ApiService } from '../../services/api.service';

interface Story {
  title: string;
  url: string;
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  standalone: true,
  imports: [CommonModule, HttpClientModule, FormsModule, NgxPaginationModule],
  providers: [ApiService], // Add ApiService if not provided globally
})

export class HomeComponent implements OnInit {
  stories: Story[] = [];
  currentPage: number = 1;
  searchQuery: string = '';

  constructor(private apiService: ApiService) {}

  ngOnInit(): void {
    this.fetchStories();
  }

  fetchStories(): void {
    this.apiService.getStories().subscribe((data) => {
      this.stories = data;
    });
  }

  searchStories(): void {
    if (this.searchQuery.trim()) {
      this.apiService.searchStories(this.searchQuery).subscribe((data) => {
        this.stories = data;
      });
    } else {
      this.fetchStories();
    }
  }

  onPageChange(page: number): void {
    this.currentPage = page;
  }
}
