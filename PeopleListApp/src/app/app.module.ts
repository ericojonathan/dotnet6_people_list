import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { ButtonComponent } from './components/button/button.component';
import { PeopleComponent } from './components/people/people.component';
import { PersonItemComponent } from './components/person-item/person-item.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,    
    ButtonComponent,
    PeopleComponent,
    PersonItemComponent    
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
