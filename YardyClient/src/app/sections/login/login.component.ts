import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { User } from '../../interfaces/user';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  registerForm: FormGroup;

  constructor(private loginFormBuilder: FormBuilder, private registerFormBuilder: FormBuilder) {

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

  loginUser(userModel: User) {
    
    console.log(userModel.username);
    console.log(userModel.password);
  }

  registerUser() {
    
  }

  ngOnInit() {
  }


}
