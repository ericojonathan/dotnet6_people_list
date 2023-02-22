import { Component, Input } from '@angular/core';
import { Person } from '../../Person';

@Component({
  selector: 'app-person-item',
  templateUrl: './person-item.component.html',
  styleUrls: ['./person-item.component.css']
})
export class PersonItemComponent {
  @Input() person?: Person;

  constructor() {
    console.log(this.person);
  }
}
