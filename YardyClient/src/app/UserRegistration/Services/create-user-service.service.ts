import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CreateUserModel } from '../Models/CreateUserModel';

@Injectable({
  providedIn: 'root'
})
export class CreateUserServiceService {

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(private httpClient: HttpClient)
  {

  }

  CreateUserAccount(createUserModel: CreateUserModel) {

  }
}
