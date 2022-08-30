import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, timer } from 'rxjs';
import { delayWhen, retryWhen, take } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { UserRole } from '../Models/UserRole';

@Injectable({
  providedIn: 'root'
})
export class RolesService {

  constructor(private http: HttpClient) { }

  getUserRoles(): Observable<Array<UserRole>> {
    return this.http.get<Array<UserRole>>(`${environment.API_URL}Role`)
      .pipe(
        retryWhen(error => error.pipe(
          delayWhen(_ => timer(10000)),
          take(3)
        ))
      );
  }
}
