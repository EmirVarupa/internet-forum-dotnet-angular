import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, timer } from 'rxjs';
import { delayWhen, retryWhen, take } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { UserStatus } from '../Models/UserStatus';

@Injectable({
  providedIn: 'root'
})
export class UserStatusesService {

  constructor(private http: HttpClient) { }

  getUserStatuses(): Observable<Array<UserStatus>> {
    return this.http.get<Array<UserStatus>>(`${environment.API_URL}UserStatus`)
      .pipe(
        retryWhen(error => error.pipe(
          delayWhen(_ => timer(10000)),
          take(3)
        ))
      );
  }
}
