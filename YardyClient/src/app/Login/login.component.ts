import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
//import { User } from '../../interfaces/user';
import { LoginService } from './Services/LoginService';
import { LoginModel } from './Models/LoginModel';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  registerForm: FormGroup;
  private loginService;
  constructor(private loginFormBuilder: FormBuilder, private registerFormBuilder: FormBuilder, loginservice: LoginService) {

    this.loginService = loginservice;

    this.loginForm = this.loginFormBuilder.group(
      {
        username: ['', Validators.required],
        password: ['', Validators.required]
      }
    );

    this.registerForm = this.registerFormBuilder.group(
      {
        username: ['', Validators.required],
        email: ['', Validators.required],
        password: ['', Validators.required],
        repassword: ['', Validators.required]
      }
    );

  }

  loginUser(loginModel: LoginModel) {

    this.loginService.ValidateUserLogin(loginModel).subscribe(
      response => {

      }
    );
  }

  registerUser() {
    
  }

  ngOnInit() {
  }


}
