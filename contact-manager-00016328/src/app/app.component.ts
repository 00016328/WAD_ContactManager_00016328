import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { Contact } from './Contact';
import { HomeComponent } from './components/home/home.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, MatButtonModule, HomeComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'contact-manager';
  contacts: Contact[] = [
    {
      id: 1,
      name: 'John Doe',
      email: 'johndoe@example.com',
      phone: '123-456-7890',
      groupID: 1,
      group: {
        id: 1,
        name: 'Friends',
      },
    },
    {
      id: 2,
      name: 'Jane Smith',
      email: 'janesmith@example.com',
      phone: '987-654-3210',
      groupID: 2,
      group: {
        id: 2,
        name: 'Work',
      },
    },
    {
      id: 3,
      name: 'Michael Johnson',
      email: 'michael.johnson@example.com',
      phone: '456-123-7890',
      groupID: 3,
      group: {
        id: 3,
        name: 'Family',
      },
    },
    {
      id: 4,
      name: 'Emily Davis',
      email: 'emilydavis@example.com',
      phone: '789-012-3456',
      groupID: 4,
      group: {
        id: 4,
        name: 'School',
      },
    },
    {
      id: 5,
      name: 'Chris Brown',
      email: 'chrisbrown@example.com',
      phone: '321-654-0987',
      groupID: 5,
      group: {
        id: 5,
        name: 'Other',
      },
    },
  ];
}
