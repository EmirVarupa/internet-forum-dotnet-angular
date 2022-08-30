import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../Models/User';
import { Observable, of, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { tap, delay } from "rxjs/operators";
import { Router } from '@angular/router';
import { AuthData } from '../Models/AuthData';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  // COPY PASTED isLoggedIn
  authChange = new Subject<boolean>();
  isLoggedIn = false;
  userId!: number;
  username!: string;
  role!: string;
  // private user: User;

  registerUserData = {}

  constructor(private http: HttpClient, private router: Router, private snackBar: MatSnackBar) {
    const token = localStorage.getItem('jwt');
    this.authChange.next(!!token);
  }

  // TODO: ADD MULTIPART UPLOAD FOR IMAGES
  register(user: any): Observable<any> {
    const headers = { 'Content-Type': 'application/json' };
    return this.http.post(`${environment.API_URL}User/Register`, user, { headers })
  }


  login(credentials: any): Observable<any> {
    const headers = { 'Content-Type': 'application/json' };
    return this.http.post(`${environment.API_URL}User/Login`, credentials, { headers })
  }

  refreshToken(refreshToken: any): Observable<any> {
    const headers = { 'Content-Type': 'application/json' };
    return this.http.post(`${environment.API_URL}User/RefreshToken`, refreshToken, { headers })
  }

  logout() {
    localStorage.removeItem("jwt");
    localStorage.removeItem("RefreshToken");
    this.snackBar.open('Logged out successfully!', '', {
      duration: 3000
    });
  }

  isAuthenticated() {

    if (localStorage.getItem('jwt') == null) {
      this.isLoggedIn = false;
      return this.isLoggedIn;
    }
    else {
      return true;
    }
  }

  getUserIdFromJwt() {
    if (localStorage.getItem('jwt') != null) {
      //let decoded = this.getDecodedAccessToken(String(localStorage.getItem('jwt')));
      let decoded = JSON.parse(window.atob(String(localStorage.getItem('jwt')).split('.')[1]))["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"]
      this.userId = decoded;
    }
    return this.userId;
  }

  getUsernameFromJwt() {
    if (localStorage.getItem('jwt') != null) {
      let decoded = JSON.parse(window.atob(String(localStorage.getItem('jwt')).split('.')[1]))["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"]
      this.username = decoded;
    }
    return this.username;
  }

  getRoleFromJwt() {
    if (localStorage.getItem('jwt') != null) {
      let decoded = JSON.parse(window.atob(String(localStorage.getItem('jwt')).split('.')[1]))["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]
      this.role = decoded;
    }
    return this.role;
  }

  // NOTE: from npm install jwt-decode which is removed right now
  // getDecodedAccessToken(token: string): any {
  //   try {
  //     return jwt_decode(token);
  //   } catch(Error) {
  //     return null;
  //   }
  // }
}
