import { Component, OnInit } from '@angular/core';
import { Userprofile } from '../../interfaces/userprofile'
import { DataService } from 'src/app/data.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-create-user-profile',
  templateUrl: './create-user-profile.component.html',
  styleUrls: ['./create-user-profile.component.css']
})
export class CreateUserProfileComponent implements OnInit {

  userProfile: object;
  profileForm: FormGroup;
  submitted = false;
  success = false;


  //constructor(private data: DataService) { }
  constructor(private formBuilder: FormBuilder, private data: DataService) {

    //Replace this with a model perhaps?

    this.profileForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', Validators.required],
      dob: [''],
      street: [''],
      city: [''],
      zip: ['']
    });

  }

  createUserProfile(model: Userprofile) {

    this.submitted = true;

    if (this.profileForm.invalid) {
      return;
    }
    else {
      this.success = true;
      this.data.CreateUserProfile(model).subscribe();
    }
    
  }

  getUserProfiles() {

    this.data.GetUserProfiles().subscribe();

  }

  ngOnInit() {


  }

}
