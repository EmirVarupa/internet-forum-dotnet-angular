import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, timer } from 'rxjs';
import { delayWhen, retryWhen, take } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Post } from '../Models/Post';
import { UserPostVote } from '../Models/UserPostVote';

@Injectable({
  providedIn: 'root'
})
export class PostsService {

  constructor(private http: HttpClient) { }

  getPosts(communityId?: number, userId?: number): Observable<Array<Post>> {
    if(communityId != null && userId != null){
      return this.http.get<Array<Post>>(`${environment.API_URL}Post/Community/${communityId}/${userId}`)
      .pipe(
        retryWhen(error => error.pipe(
          delayWhen(_ => timer(10000)),
          take(3)
        ))
      );
    }else if(communityId != null && userId == null){
      return this.http.get<Array<Post>>(`${environment.API_URL}Post/Community/${communityId}`)
      .pipe(
        retryWhen(error => error.pipe(
          delayWhen(_ => timer(10000)),
          take(3)
        ))
      );
    }else{
      return this.http.get<Array<Post>>(`${environment.API_URL}Post/Community`)
      .pipe(
        retryWhen(error => error.pipe(
          delayWhen(_ => timer(10000)),
          take(3)
        ))
      );
    }
  }

  getUserPostsByUsername(username: string): Observable<Array<Post>> {
    return this.http.get<Array<Post>>(`${environment.API_URL}Post/User/${username}`)
      .pipe(
        retryWhen(error => error.pipe(
          delayWhen(_ => timer(10000)),
          take(3)
        ))
      );
  }


  addPost(post: Post): Observable<any> {
    const headers = { 'Content-Type': 'application/json' };
    return this.http.post(`${environment.API_URL}Post`, post, { headers });
  }

  getPost(postId: number): Observable<Post> {
    return this.http.get<Post>(`${environment.API_URL}Post/${postId}`)
      .pipe(
        retryWhen(error => error.pipe(
          delayWhen(_ => timer(10000)),
          take(3)
        ))
      );
  }

  votePost(userPostVote: UserPostVote): Observable<number> {
    return this.http.put<number>(`${environment.API_URL}UserPostVote`, userPostVote)
      .pipe(
        retryWhen(error => error.pipe(
          delayWhen(_ => timer(10000)),
          take(3)
        ))
      );
  }

  viewPost(postId: number): Observable<Post> {
    return this.http.put<Post>(`${environment.API_URL}Post/View/${postId}`, postId)
      .pipe(
        retryWhen(error => error.pipe(
          delayWhen(_ => timer(10000)),
          take(3)
        ))
      );
  }

  updatePost(post: Post): Observable<any> {
    return this.http.put(`${environment.API_URL}Post/${post.postId}`, post);
  }

  archivePost(postId: number): Observable<any> {
    const headers = { 'Content-Type': 'application/json' };
    return this.http.put(`${environment.API_URL}Post/Archive/${postId}`, headers);
  }
}
