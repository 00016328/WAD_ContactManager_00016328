import { Component, OnInit, inject } from '@angular/core';
import { ContactService } from '../../contact.service';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { ActivatedRoute } from '@angular/router';
import { Contact } from '../../Contact';
import { Router } from '@angular/router';

function findIndexById(jsonArray: any[], indexToFind: number): number {
  return jsonArray.findIndex((contact) => contact.id === indexToFind);
}

@Component({
  selector: 'app-edit',
  imports: [FormsModule, MatFormFieldModule, MatSelectModule, MatInputModule, MatButtonModule],
  templateUrl: './edit.component.html',
  styleUrl: './edit.component.css'
})
export class EditComponent implements OnInit {
  contactService = inject(ContactService);
  activatedRoute = inject(ActivatedRoute);
  router = inject(Router);
  editContact: Contact = {
    Id: 0,
    Name: "",
    Email: "",
    Phone: "",
    Group: {
      GroupId: 0,
      GroupName: ""
    }
  }
  groupObject: any;
  selected: any
  gId: number = 0;
  ngOnInit() {
    this.contactService.getById(this.activatedRoute.snapshot.params["id"]).subscribe(result => {
      this.editContact = result;
      this.selected = this.editContact.Group.GroupId;
    });
    this.contactService.getAllGroups().subscribe((result) => {
      this.groupObject = result;
    })
  }

  toHome() {
    this.router.navigateByUrl("home")
  }

  edit() {
    this.editContact.Group.GroupId = this.gId;
    this.editContact.Group = this.groupObject[findIndexById(this.groupObject, this.gId)];
    this.contactService.edit(this.editContact).subscribe(res=>{
      alert("Changes has been updated")
      this.router.navigateByUrl("home");
    })
  }

}
