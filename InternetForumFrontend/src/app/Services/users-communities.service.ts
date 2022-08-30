import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, timer } from 'rxjs';
import { delayWhen, retry, retryWhen, take } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { UserCommunity } from '../Models/UserCommunity';

@Injectable({
  providedIn: 'root'
})
export class UsersCommunitiesService {

  constructor(private http: HttpClient) { }


  getUserCommunity(communityId : number, userId : number): Observable<UserCommunity> {
    return this.http.get<UserCommunity>(`${environment.API_URL}UserCommunity/${communityId}/${userId}`)
  }

  joinOrLeaveCommunity(userCommunity: UserCommunity): Observable<UserCommunity> {
    return this.http.put<UserCommunity>(`${environment.API_URL}UserCommunity`, userCommunity)
    .pipe(
      retryWhen(error => error.pipe(
        delayWhen(_ => timer(10000)),
        take(3)
      ))
    );
  }


  getUserCommunities(userId : number): Observable<Array<UserCommunity>> {
    return this.http.get<Array<UserCommunity>>(`${environment.API_URL}UserCommunity/User/${userId}`)
    .pipe(
      retryWhen(error => error.pipe(
        delayWhen(_ => timer(10000)),
        take(3)
      ))
    );
  }

  getUserAdminCommunities(userId : number): Observable<Array<UserCommunity>> {
    return this.http.get<Array<UserCommunity>>(`${environment.API_URL}UserCommunity/Admin/${userId}`)
    .pipe(
      retryWhen(error => error.pipe(
        delayWhen(_ => timer(10000)),
        take(3)
      ))
    );
  }
}
