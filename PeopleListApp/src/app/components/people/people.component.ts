import { Component, OnInit } from '@angular/core';
import { PeopleService } from '../../services/people.service';
import { Person } from '../..//Person';

@Component({
  selector: 'app-people',
  templateUrl: './people.component.html',
  styleUrls: ['./people.component.css']
})
export class PeopleComponent {
  people: Person[] = [];

  constructor(private peopleService: PeopleService) {
    this.peopleService.getPeople().subscribe((people) => (this.people = people));
    console.log(this.people);
  }
}
