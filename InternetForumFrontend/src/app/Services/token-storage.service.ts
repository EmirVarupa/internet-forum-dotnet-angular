import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

const TOKEN_KEY = 'auth-token';
const REFRESHTOKEN_KEY = 'auth-refreshtoken';
const USER_KEY = 'auth-user';

@Injectable({
  providedIn: 'root'
})
export class TokenStorageService {
  constructor(private snackBar: MatSnackBar) { }
  
  // localStorage.removeItem("RefreshToken");
  // localStorage.getItem('jwt')
  // localStorage.setItem("jwt", token);



  public saveToken(token: string): void {
    localStorage.removeItem("jwt");
    localStorage.setItem("jwt", token);

    const user = this.getUser();
    if (user.id) {
      this.saveUser({ ...user, accessToken: token });
    }
  }

  public getToken(): string | null {
    return localStorage.getItem('jwt')
  }

  public saveRefreshToken(token: string): void {
    localStorage.removeItem("RefreshToken");
    localStorage.setItem("RefreshToken", token);
  }

  public getRefreshToken(): string | null {
    return localStorage.getItem('RefreshToken')
  }

  public saveUser(user: any): void {
    window.sessionStorage.removeItem(USER_KEY);
    window.sessionStorage.setItem(USER_KEY, JSON.stringify(user));
  }

  public getUser(): any {
    const user = window.sessionStorage.getItem(USER_KEY);
    if (user) {
      return JSON.parse(user);
    }

    return {};
  }

  signout() {
    localStorage.removeItem("jwt");
    localStorage.removeItem("RefreshToken");
    this.snackBar.open('Logged out successfully!', '', {
      duration: 3000
    });
  }
}
