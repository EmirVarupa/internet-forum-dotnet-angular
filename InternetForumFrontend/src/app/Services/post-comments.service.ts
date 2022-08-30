import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, timer } from 'rxjs';
import { delayWhen, retryWhen, take } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { PostComment } from '../Models/PostComment';
import { UserPostCommentVote } from '../Models/UserPostCommentVote';

@Injectable({
  providedIn: 'root'
})
export class PostCommentsService {

  constructor(private http: HttpClient) { }

  getPostComments(postId: number, userId?: number): Observable<Array<PostComment>> {
    if (userId != null) {
      return this.http.get<Array<PostComment>>(`${environment.API_URL}PostComment/Post/${postId}/${userId}`)
        .pipe(
          retryWhen(error => error.pipe(
            delayWhen(_ => timer(10000)),
            take(3)
          ))
        );
    } else {
      return this.http.get<Array<PostComment>>(`${environment.API_URL}PostComment/Post/${postId}`)
        .pipe(
          retryWhen(error => error.pipe(
            delayWhen(_ => timer(10000)),
            take(3)
          ))
        );
    }
  }

  votePostComment(userPostCommentVote: UserPostCommentVote): Observable<number> {
    return this.http.put<number>(`${environment.API_URL}UserPostCommentVote`, userPostCommentVote)
      .pipe(
        retryWhen(error => error.pipe(
          delayWhen(_ => timer(10000)),
          take(3)
        ))
      );
  }

  addPostComment(postComment: PostComment): Observable<any> {
    const headers = { 'Content-Type': 'application/json' };
    return this.http.post(`${environment.API_URL}PostComment`, postComment, { headers });
  }


  deletePostComment(postCommentId: number): Observable<any> {
    const headers = { 'Content-Type': 'application/json' };
    return this.http.delete(`${environment.API_URL}PostComment/${postCommentId}`);
  }
}
