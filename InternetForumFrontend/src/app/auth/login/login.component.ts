import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/Services/auth.service';
import { RegisterComponent } from '../register/register.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  invalidLogin?: boolean;
  isLoggedIn?: boolean

  constructor(private route: ActivatedRoute, private router: Router, private dialog: MatDialog, private authService: AuthService, private snackBar: MatSnackBar) { }

  ngOnInit(): void {
      
  }

  onSubmit(form: NgForm) {
    const credentials = {
      'username': form.value.username,
      'password': form.value.password
    }

      this.authService.login(credentials)
      .subscribe(response =>{
        const token = (<any>response).token;
        localStorage.setItem("jwt", token);
        const refreshToken = (<any>response).refreshToken;
        localStorage.setItem("RefreshToken", refreshToken);
        this.invalidLogin = false;
        this.router.navigate(["/"])
        this.snackBar.open('Logged in successfully!', '', {
          duration: 3000
        });
      }, err =>{
        this.invalidLogin = true;
      })
      this.dialog.closeAll();
    }

    register(): void {
      this.dialog.closeAll();
      this.dialog.open(RegisterComponent, {
        width: '40%',
        disableClose: true
      });
    }

    
}
