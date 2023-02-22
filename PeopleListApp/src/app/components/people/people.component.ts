import { Component } from '@angular/core';
import { Person } from '../../Person';
import { PEOPLE } from '../../mock_people';
@Component({
  selector: 'app-people',
  templateUrl: './people.component.html',
  styleUrls: ['./people.component.css']
})
export class PeopleComponent {
  people: Person[] = PEOPLE;
}
