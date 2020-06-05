import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Gundam } from '../_models/gundam';

@Injectable({
  providedIn: 'root',
})
export class GundamService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getGundams(): Observable<Gundam[]> {
    return this.http.get<Gundam[]>(
      this.baseUrl + 'collectiongundam'
    );
  }

  getGundam(id): Observable<Gundam> {
    return this.http.get<Gundam>(
      this.baseUrl + 'collectiongundam/' + id
    );
  }
}
