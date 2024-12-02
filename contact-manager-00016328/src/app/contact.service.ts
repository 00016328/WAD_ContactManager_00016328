import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Contact } from './Contact';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  httpClient = inject(HttpClient);

  constructor() {}

  getAllContacts() {
    return this.httpClient.get<Contact[]>("http://localhost:5246/api/Contact/GetAll/");
  }

  getById(id: number) {
    return this.httpClient.get<Contact>(`http://localhost:5246/api/Contact/GetById/${id}`);
  }

  // create(contact: Contact) {
  //   return this.httpClient.post<Contact>("http://localhost:5246/api/Contact/Create/", contact);
  // }

  update(id: number, contact: Contact) {
    return this.httpClient.put(`http://localhost:5246/api/Contact/Update/${id}`, contact);
  }

  delete(id: number) {
    return this.httpClient.delete(`http://localhost:5246/api/Contact/Delete/${id}`);
  }
}