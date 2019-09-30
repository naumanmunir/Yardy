import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { CreateUserModel } from '../Models/CreateUserModel';
import { tap, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CreateUserServiceService {

  private apiUrl = "https://localhost:44300/api/user";

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(private httpClient: HttpClient)
  {

  }

  CreateUserAccount(createUserModel: CreateUserModel) {

    return this.httpClient.post<any>(this.apiUrl, createUserModel, this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );

  }

  DeleteUser() {

  }

  EditUser() {

  }

  GetAllUsers() {

  }

  GetUserByName() {

  }

  GetUserByID() {

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
