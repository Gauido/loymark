import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IUser } from '../models/IUserModel';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  baseUri: string;

  constructor(private http: HttpClient) {
    this.baseUri = 'api/user';
  }

  async getAll() {
    let url = `${this.baseUri}/getAll`;
    return this.http.get<IUser[]>(url);
  }

  getById(id: number) {
    let url = `${this.baseUri}/${id}`;
    return this.http.get(url);
  }

  create(user: any) {
    let url = `${this.baseUri}/create`;
    return this.http.post(url, user);
  }

  update(user: any, id: number) {
    let url = `${this.baseUri}/${id}`;
    return this.http.put(url, user);
  }

  delete(id: number) {
    let url = `${this.baseUri}/${id}`;
    return this.http.delete(url);
  }

  getTasks() {
    let url = `${this.baseUri}/getTasks`;
    return this.http.get(url);
  }
}
