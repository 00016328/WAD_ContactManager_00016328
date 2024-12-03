import { Component, inject } from '@angular/core';
import { Contact } from '../../Contact';
import { ContactService } from '../../contact.service';
import { ActivatedRoute } from '@angular/router';
import { MatChipsModule } from '@angular/material/chips';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-details',
  imports: [MatChipsModule, MatCardModule],
  templateUrl: './details.component.html',
  styleUrl: './details.component.css'
})
export class DetailsComponent {
  detailsContact: Contact = {
    Id: 0,
    Name: "",
    Email: "",
    Phone: "",
    Group: {
      GroupId: 0,
      GroupName: ""
    }
  }

  contactService = inject(ContactService);
  activatedRoute = inject(ActivatedRoute);

  ngOnInit() {
    this.contactService.getById(this.activatedRoute.snapshot.params["id"]).subscribe((resultedContact) => {
      this.detailsContact = resultedContact;
    });
  }
}
