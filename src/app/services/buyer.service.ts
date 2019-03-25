import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { catchError} from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BuyerService {

  private headers: HttpHeaders;
  private accessPointUrl: string = 'http://localhost:5000/api/buyers';

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({'Content-Type': 'application/json'});
  }

  public get() {
    // Get all buyers data
    return this.http.get(this.accessPointUrl, {headers: this.headers});
  }

  public getById(id) {
    // Get buyer by id
    return this.http.get(this.accessPointUrl + "/" + id, {headers: this.headers});
  }

  public buy(buyerId, apartmentId)  {
    return this.http.post(this.accessPointUrl + "/" + buyerId + "/buyApartment?apartmentId=" + apartmentId,
    {headers: this.headers}).pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    if (error.status != 201){
      window.alert("Insufficient credits!");
      return throwError('Something bad happened; please try again later.');
    }
  };

}
