import { Component, OnInit } from '@angular/core';
import { CommunitiesService } from '../Services/communities.service';
import { isNgTemplate } from '@angular/compiler';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { UserCommunity } from 'src/app/Models/UserCommunity';
import { UserPostVote } from 'src/app/Models/UserPostVote';
import { AuthService } from 'src/app/Services/auth.service';
import { UsersCommunitiesService } from 'src/app/Services/users-communities.service';
import { Post } from '../Models/Post';
import { PostsService } from '../Services/posts.service';
import { EditPostComponent } from '../post/edit-post/edit-post.component';
import { AddPostComponent } from '../post/add-post/add-post.component';

@Component({
  selector: 'app-communities',
  templateUrl: './communities.component.html',
  styleUrls: ['./communities.component.css']
})
export class CommunitiesComponent implements OnInit {
  posts: Array<Post> = [];
  userPostVote: UserPostVote = new UserPostVote();
  userCommunity: UserCommunity = new UserCommunity();
  postId = Number(this.route.snapshot.paramMap.get('id'));
  isJoined!: boolean;
  communityName!: string;
  changeText?: boolean;
  isLoggedIn!: boolean;
  constructor(private route: ActivatedRoute, private dialog: MatDialog, private postsService: PostsService, private userCommunitiesService: UsersCommunitiesService, private communitiesService: CommunitiesService, private authService: AuthService, private snackBar: MatSnackBar) { }

  userId = Number(this.authService.getUserIdFromJwt());


  ngOnInit(): void {
    this.isLoggedIn = this.authService.isAuthenticated();

      this.postsService.getPosts()
        .subscribe(res => {
          this.posts = res;
          console.log(this.posts);
          console.log(res);
        });
  }

  likePost(post: any): void {
    this.userPostVote.userId = this.userId;
    this.userPostVote.postVoteId = post.postVote.voteId;
    this.userPostVote.postVoteDirection = 1;
    this.postsService.votePost(this.userPostVote)
      .subscribe(res => {
        post.postVote.voteCount = res;
      });
  }

  dislikePost(post: any): void {
    this.userPostVote.userId = this.userId;
    this.userPostVote.postVoteId = post.postVote.voteId;
    this.userPostVote.postVoteDirection = -1;
    this.postsService.votePost(this.userPostVote)
      .subscribe(res => {
        post.postVote.voteCount = res;
      });
  }

  public createImgPath = (serverPath: string) => {
    serverPath.replace(/\\/g, "/");
    return `https://localhost:5001/${serverPath}`;
  }

  showSpoiler(post: Post) {
    post.isSpoiler = false;
  }

  editPost(post: Post): void {
    this.dialog.open(EditPostComponent, {
      data: {
        postId: post.postId,
        postTitle: post.postTitle,
        postContent: post.postContent,
        imageUrl: post.imageUrl,
        link: post.link,
        isSpoiler: post.isSpoiler
      },
      width: '40%',
      disableClose: true
    }).afterClosed().subscribe(() => {
        this.postsService.getPost(post.postId)
          .subscribe(res => {
            
            this.posts[this.posts.indexOf(post)] = res;
          });
      //   setTimeout(() => {
      //     this.postsService.getPosts(this.communityId, this.userId)
      //   .subscribe(res => {
      //     this.posts = res;
      //   });
      // },
      // 200);
    });
  }
}

