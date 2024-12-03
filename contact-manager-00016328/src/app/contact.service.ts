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
    return this.httpClient.get<Contact[]>("http://localhost:5246/api/Contacts/GetAll/");
  }
  
  getById(id: number) {
    return this.httpClient.get<Contact>(`http://localhost:5246/api/Contacts/${id}`);
  }

  create(contact: Contact) {
    return this.httpClient.post<Contact>("http://localhost:5246/api/Contacts/", contact);
  }  
  
  edit(contact: Contact) {
    return this.httpClient.put("http://localhost:5246/api/Contacts/", contact);
  }
  
  delete(id: number) {
    return this.httpClient.delete(`http://localhost:5246/api/Contacts/${id}`);
  }
  getAllGroups() {
    return this.httpClient.get<Contact[]>("http://localhost:5246/api/Groups/GetAll/");
  }
  
}