import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, timer } from 'rxjs';
import { delayWhen, retryWhen, take } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { User } from '../Models/User';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private http: HttpClient) { }

  getUsers(): Observable<Array<User>> {
    return this.http.get<Array<User>>(`${environment.API_URL}User`)
    .pipe(
      retryWhen(error => error.pipe(
        delayWhen(_ => timer(10000)),
        take(3)
      ))
    );
  }

  getUser(username: string): Observable<User> {
    return this.http.get<User>(`${environment.API_URL}User/${username}`)
    .pipe(
      retryWhen(error => error.pipe(
        delayWhen(_ => timer(10000)),
        take(3)
      ))
    );
  }

  updateUser(user: User): Observable<any> {
    return this.http.put(`${environment.API_URL}User/${user.userId}`, user);
  }

  archiveUser(userId: number): Observable<any> {
    const headers = { 'Content-Type': 'application/json' };
    return this.http.put(`${environment.API_URL}User/Archive/${userId}`, headers);
  }
}
