import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { LoginModel } from '../Models/LoginModel';
import { catchError, tap } from 'rxjs/operators'
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class LoginService {
  public token: string;
  private apiUrl = "https://localhost:44300/api/authenticate";
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
      //'Authorization': 'my-auth-token'
    })
  };

  constructor(private httpClient: HttpClient, private router: Router) {

  }

  public ValidateUserLogin(loginModel: LoginModel) {

    return this.httpClient.post<any>(this.apiUrl, loginModel, this.httpOptions)
      .pipe(tap(data => {

        //console.log(data);

        if (data.Token != null) {
          //store username and JWT token in localstorage
          if (data.UserTypeID == "1") {
            localStorage.setItem("currentUser", JSON.stringify({ username: loginModel.Username, token: data.Token }));
          }
          else if (data.UserTypeID == "2") {
            localStorage.setItem("adminUser", JSON.stringify({ username: loginModel.Username, token: data.Token }));
          }
        }
        else
          return null;
      }),
        catchError(this.handleError)
      );


  }

  LogoutUser() {
    localStorage.removeItem("currentUser");
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
