import { Component, OnInit } from '@angular/core';
import { CreateUserModel } from './Models/CreateUserModel';
import { CreateUserServiceService } from './Services/create-user-service.service';

@Component({
  selector: 'app-user-registration',
  templateUrl: './user-registration.component.html',
  styleUrls: ['./user-registration.component.css']
})
export class UserRegistrationComponent implements OnInit {


  createUserModel: CreateUserModel = new CreateUserModel();


  constructor(private createUserService: CreateUserServiceService) {

    //Is the best way to use a formGroup????

    //fixed
    //testing
  }

  ngOnInit() {
  }


  CreateUser(createUserModel) {

    this.createUserService.CreateUserAccount(createUserModel).subscribe(
      response => {
        //response from server
        console.log(response);



        //if (response.StatusCode == "200") {
          
        //}


      }

    );


  }

}
