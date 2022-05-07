import { Injectable } from '@angular/core';
import { Observable, timer } from 'rxjs';
import { delayWhen, retryWhen } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { CommunityType } from '../Models/CommunityType';

@Injectable({
  providedIn: 'root'
})
export class CommunityTypesService {

  constructor(private http: HttpClient) { }

    getCommunityTypes(): Observable<Array<CommunityType>> {
      return this.http.get<Array<CommunityType>>(`${environment.API_URL}CommunityType`)
        .pipe(
          retryWhen(error => error.pipe(
            delayWhen(_ => timer(1000))
          ))
        );
    }

  
}
