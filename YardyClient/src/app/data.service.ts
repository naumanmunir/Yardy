import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Userprofile } from './interfaces/userprofile';
import { Observable } from 'rxjs';
import { YardSale } from './interfaces/yardsale';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
      //'Authorization': 'my-auth-token'
    })
  };

  constructor(private http: HttpClient) {}

  //API calls go here
  CreateUserProfile(userData: Userprofile): Observable<Userprofile> {

    //console.log(userData);
    //this.http.get("https://localhost:44300/api/userprofiles/").subscribe(data => { userData });

    return this.http.post<Userprofile>("https://localhost:44300/api/userprofiles", userData, this.httpOptions);


  }

  GetUserProfiles(): Observable<Userprofile> {

    return this.http.get<Userprofile>("https://localhost:44300/api/userprofiles", this.httpOptions);


  }

  CreateYardSale(newYardSaleData: YardSale): Observable<YardSale> {


    return this.http.post<YardSale>("https://localhost:44300/api/YardSales/", newYardSaleData, this.httpOptions);

  }

  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    // return an observable with a user-facing error message
    return 'Something bad happened; please try again later.';
  };
  
}
