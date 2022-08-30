import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, NgForm, ValidatorFn, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/Services/auth.service';
import { LoginComponent } from '../login/login.component';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  invalidRegister?: boolean;
  formGroup!: FormGroup;
  response!: {dbPath: ''};

  constructor(private router: Router, private dialog: MatDialog, private authService: AuthService) { }

  ngOnInit(): void {
  }

  confirmEquals(): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } | null =>
      control.value?.toLowerCase() === this.passwordValue.toLowerCase()
        ? null : { noMatch: true };
  }

  get passwordValue() {
    return this.password.value;
  }

  onSubmit() {
    const register = {
      'roleId': 1,
      'statusId': 1,
      'username': this.username.value,
      'password': this.password.value,
      'firstName': this.firstName.value,
      'lastName': this.lastName.value,
      'email': this.email.value,
      'imageUrl': this.response.dbPath
    }
    console.log(register)
    this.authService.register(register)
      .subscribe(response => {
        const token = (<any>response).token;
        localStorage.setItem("jwt", token);
        this.invalidRegister = false;
        this.router.navigate([`/user/${this.username.value}`])
      }, err => {
        this.invalidRegister = true;
      })
    this.dialog.closeAll();
  }

  login(): void {
    this.dialog.closeAll();
    this.dialog.open(LoginComponent, {
      width: '40%',
      disableClose: true
    });
  }

  username = new FormControl("", [
    Validators.required,
  ]);
  password = new FormControl("", [
    Validators.required,
    Validators.pattern(
      "^((?=\\S*?[A-Z])(?=\\S*?[a-z])(?=\\S*?[0-9]).{8,255})\\S$"
    )
  ]);
  confirmPassword = new FormControl("", [
    Validators.required,
    this.confirmEquals()
  ]);
  password2 = new FormControl("", [
    Validators.required,
  ]);
  firstName = new FormControl("", [
    Validators.required,
  ]);
  lastName = new FormControl("", [
    Validators.required,
  ]);
  email = new FormControl("", [
    Validators.required,
  ]);
  imageUrl = new FormControl("", [
    Validators.required
  ]);


  uploadFinished = (event : any) => { 
    this.response = event; 
  }

  public createImgPath = (serverPath: string) => { 
    return `https://localhost:5001/${serverPath}`; 
  }
}
