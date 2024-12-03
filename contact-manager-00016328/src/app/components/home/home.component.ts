import { Component, inject } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { ContactService } from '../../contact.service';
import { Contact } from '../../Contact';
import { Router } from '@angular/router';



@Component({
  selector: 'app-home',
  standalone: true,
  imports: [MatTableModule, MatButtonModule],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  router = inject(Router);
  contacts: Contact[] = [];
  contactService = inject(ContactService);
  ngOnInit() {
    this.contactService.getAllContacts().subscribe((result) => {
      this.contacts = result;
    });
  }
  displayedColumns: string[] = ['ID', 'Name', 'Email', 'Phone', 'Group', 'Actions'];

  onCreate() {
    console.log("Create clicked");
    this.router.navigateByUrl("/create");
  }
  onEdit(id: number) {
    console.log("Edit: ", id);
    this.router.navigateByUrl("/edit/" + id);
  }
  onDetails(id: number) {
    console.log("Details: ", id);
    this.router.navigateByUrl("/details/" + id);
  }
  onDelete(id: number) {
    console.log("Delete: ", id);
    this.router.navigateByUrl("/delete/" + id);
  }
}
