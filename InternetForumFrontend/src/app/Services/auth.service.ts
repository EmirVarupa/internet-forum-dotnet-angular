import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../Models/User';
import { Observable, of, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { tap, delay } from "rxjs/operators";
import { Router } from '@angular/router';
import { AuthData } from '../Models/AuthData';


@Injectable({
  providedIn: 'root'
})
export class AuthService {
// COPY PASTED isLoggedIn
authChange = new Subject<boolean>();
  isLoggedIn = false;
  // private user: User;

  registerUserData = {}
  constructor(private http: HttpClient, private router: Router) { }

  // TODO: ADD MULTIPART UPLOAD FOR IMAGES
  createUser(user: User): Observable<any> {
    const headers = { 'Content-Type': 'application/json' };
    return this.http.post(`${environment.API_URL}User`, user, { headers })
  }


// COPY PASTED login and logout
  login(authData: AuthData): Observable<boolean> {
    return of(true).pipe(
      delay(1000),
      tap(val => this.isLoggedIn = true)
    );
  }
  
  // logout(): void{
  //   // this.isLoggedIn = false;
  //   this.user = null;
  //   this.authChange.next(false);
  //   this.router.navigate(['/login']);
  // }

  logout(){
    
  }

  private authSuccessfully() {
    this.authChange.next(true);
    this.router.navigate(['/training']);
  }
}
