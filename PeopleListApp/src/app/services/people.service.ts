import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, observable, of } from 'rxjs';
import { Person } from '../Person';
import { PEOPLE } from '../mock_people';

@Injectable({
  providedIn: 'root'
})
export class PeopleService {

  private apiUrl: string = "https://localhost:7179/api/people";

  constructor(private http: HttpClient) { }

  getPeople(): Observable<Person[]> {
    return this.http.get<Person[]>(this.apiUrl);
  }
}
