import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { Contact } from './Contact';
import { NavigationComponent } from './components/navigation/navigation.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, MatButtonModule, NavigationComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'contact-manager';
  // contacts: Contact[] = [
  //   {
  //     Id: 1,
  //     Name: 'John Doe',
  //     Email: 'johndoe@example.com',
  //     Phone: '123-456-7890',
  //     Group: {
  //       GroupId: 1,
  //       GroupName: 'Friends'
  //     }

  //   },
  //   {
  //     Id: 2,
  //     Name: 'Jane Smith',
  //     Email: 'janesmith@example.com',
  //     Phone: '987-654-3210',
  //     Group: {
  //       GroupId: 2,
  //       GroupName: 'Family'
  //     }
  //   },
  //   {
  //     Id: 3,
  //     Name: 'Alice Brown',
  //     Email: 'alicebrown@example.com',
  //     Phone: '456-789-1234',
  //     Group: {
  //       GroupId: 3,
  //       GroupName: 'Work'
  //     }
  //   },
  //   {
  //     Id: 4,
  //     Name: 'Bob White',
  //     Email: 'bobwhite@example.com',
  //     Phone: '321-654-9870',
  //     Group: {
  //       GroupId: 4,
  //       GroupName: 'Colleagues'
  //     }
  //   },
  //   {
  //     Id: 5,
  //     Name: 'Emily Green',
  //     Email: 'emilygreen@example.com',
  //     Phone: '789-123-4567',
  //     Group: {
  //       GroupId: 5,
  //       GroupName: 'Neighbors'
  //     }
  //   },
  // ];
}
