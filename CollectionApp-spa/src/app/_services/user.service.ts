import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  baseurl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.baseurl + 'users');
  }

  getUser(id): Observable<User> {
    console.log('triggered');
    return this.http.get<User>(this.baseurl + 'users/' + id);
  }

  updateUser(id: number, user: User) {
    return this.http.put(this.baseurl + 'users/' + id, user);
  }
}
