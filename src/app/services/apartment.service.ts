import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApartmentService {

  private headers: HttpHeaders;
  private accessPointUrl: string = 'http://localhost:5000/api/apartments';

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({'Content-Type': 'application/json'});
  }

  public get() {
    // Get all apartments data
    return this.http.get(this.accessPointUrl, {headers: this.headers});
  }

  public getById(id) {
    // Get an apartment by id
    return this.http.get(this.accessPointUrl + "/" + id, {headers: this.headers});
  }

  public add(payload) {
    return this.http.post(this.accessPointUrl, payload, {headers: this.headers});
  }

  public remove(payload) {
    return this.http.delete(this.accessPointUrl + '/' + payload.id, {headers: this.headers});
  }

  public update(payload) {
    return this.http.put(this.accessPointUrl + '/' + payload.id, payload, {headers: this.headers});
  }
}
