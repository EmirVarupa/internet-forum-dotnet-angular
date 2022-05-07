import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, timer } from 'rxjs';
import { delayWhen, retryWhen } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { PostComment } from '../Models/PostComment';

@Injectable({
  providedIn: 'root'
})
export class PostCommentsService {

  constructor(private http: HttpClient) { }

  getPostComments(): Observable<Array<PostComment>> {
    return this.http.get<Array<PostComment>>(`${environment.API_URL}PostComment`)
      .pipe(
        retryWhen(error => error.pipe(
          delayWhen(_ => timer(1000))
        ))
      );
  }
}
