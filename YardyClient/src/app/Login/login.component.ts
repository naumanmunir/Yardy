import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
//import { User } from '../../interfaces/user';
import { LoginService } from './Services/LoginService';
import { LoginModel } from './Models/LoginModel';
import { Router } from '@angular/router';
import { debug } from 'util';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  registerForm: FormGroup;
  private loginService;


  ngOnInit(): void {
    localStorage.clear();
  }

  constructor(private loginFormBuilder: FormBuilder, private registerFormBuilder: FormBuilder, loginservice: LoginService, private route: Router) {

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

        console.log(response);
        if (response.Token == null && response.Usertype == "0") {

          this.route.navigate(['/login']);
        }

        if (response.Token != null && response.Usertype == "1") {

          this.route.navigate(['/createsale']);
        }
      }
    );
  }

  registerUser() {
    
  }


}
