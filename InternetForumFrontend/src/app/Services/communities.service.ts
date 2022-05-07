import { Injectable } from '@angular/core';
import { Observable, timer } from 'rxjs';
import { delayWhen, retryWhen } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Community } from '../Models/Community';

@Injectable({
  providedIn: 'root'
})
export class CommunitiesService {

  constructor(private http: HttpClient) { }

  getCommunities(): Observable<Array<Community>> {
    return this.http.get<Array<Community>>(`${environment.API_URL}Community`)
      .pipe(
        retryWhen(error => error.pipe(
          delayWhen(_ => timer(1000))
        ))
      );
  }

  addCommunity(community: Community): Observable<any> {
    const headers = { 'Content-Type': 'application/json' };
    return this.http.post(`${environment.API_URL}Community`, community, { headers });
  }

  updateTask(community: Community): Observable<any> {
    return this.http.put(`${environment.API_URL}Community/${community.communityId}`, community);
  }
}
