export class UserProfile {
  firstName: string;
  lastName: string;
  email: string;
  dob: string;
  street: string;
  city: string;
  zip: string;

  constructor(response: any)
  {
    this.firstName = response.firstName;
    this.lastName = response.lastName;
    this.email = response.email;
    this.dob = response.dob;
    this.street = response.street;
    this.city = response.city;
    this.zip = response.zip;
  }
}
