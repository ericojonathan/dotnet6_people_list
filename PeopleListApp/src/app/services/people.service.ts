import { Injectable } from '@angular/core';
import { Observable, observable, of } from 'rxjs';
import { Person } from '../Person';
import { PEOPLE } from '../mock_people';

@Injectable({
  providedIn: 'root'
})
export class PeopleService {

  constructor() { }

  getPeople(): Observable<Person[]> {
    const people = of(PEOPLE);
    return people;
  }
}
