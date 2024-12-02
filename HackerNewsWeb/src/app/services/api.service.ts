import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

interface Story {
  title: string;
  url: string;
}

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private baseUrl = 'https://hackernewwebapi-gteaaxdzhzf3e3bm.canadacentral-01.azurewebsites.net/api/stories';

  constructor(private http: HttpClient) {}

  getStories(): Observable<Story[]> {
    return this.http.get<Story[]>(this.baseUrl);
  }

  searchStories(query: string): Observable<Story[]> {
    return this.http.get<Story[]>(`${this.baseUrl}/search?query=${query}`);
  }
}
