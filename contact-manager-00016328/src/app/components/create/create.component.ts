import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { ContactService } from '../../contact.service';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatChipsModule } from '@angular/material/chips';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create',
  standalone: true,
  imports: [
    FormsModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatButtonModule,
    MatChipsModule,
  ],
  templateUrl: './create.component.html',
  styleUrl: './create.component.css'
})
export class CreateComponent {
  router = inject(Router);
  groups: any = [];
  ContactService = inject(ContactService);
  gId: number = 0;

  newContact: any = {
    Name: '',
    Email: '',
    Phone: '',
    GroupId: 0
  };

  ngOnInit() {
    this.ContactService.getAllGroups().subscribe((result) => {
      this.groups = result;
    });
  }

  toHome() {
    this.router.navigateByUrl("home")
  }

  create() {
    this.newContact.GroupId = this.gId;

    this.ContactService.create(this.newContact).subscribe(() => {
      alert('Contact Saved');
      this.router.navigateByUrl('/home');
    });
  }
}
