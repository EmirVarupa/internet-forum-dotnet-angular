import { isNgTemplate } from '@angular/compiler';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { UserCommunity } from 'src/app/Models/UserCommunity';
import { UserPostVote } from 'src/app/Models/UserPostVote';
import { AuthService } from 'src/app/Services/auth.service';
import { CommunitiesService } from 'src/app/Services/communities.service';
import { UsersCommunitiesService } from 'src/app/Services/users-communities.service';
import { Post } from '../../Models/Post';
import { PostsService } from '../../Services/posts.service';
import { AddPostComponent } from '../add-post/add-post.component';
import { ArchivePostComponent } from '../archive-post/archive-post.component';
import { EditPostComponent } from '../edit-post/edit-post.component';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.css']
})
export class PostListComponent implements OnInit {
  posts: Array<Post> = [];
  communityId!: number;
  userPostVote: UserPostVote = new UserPostVote();
  userCommunity: UserCommunity = new UserCommunity();
  postId = Number(this.route.snapshot.paramMap.get('id'));
  isJoined!: boolean;
  communityName!: string;
  communitySummary!: string;
  changeText?: boolean;
  isLoggedIn!: boolean;
  constructor(private route: ActivatedRoute, private dialog: MatDialog, private postsService: PostsService, private userCommunitiesService: UsersCommunitiesService, private communitiesService: CommunitiesService, private authService: AuthService, private snackBar: MatSnackBar) { }

  userId = Number(this.authService.getUserIdFromJwt());


  ngOnInit(): void {
    this.isLoggedIn = this.authService.isAuthenticated();
    this.route.paramMap.subscribe(param => {
      this.communityId = Number(param.get('id'))
      if(this.userId){
        this.postsService.getPosts(this.communityId, this.userId)
        .subscribe(res => {
          this.posts = res;
          console.log(this.posts);
          console.log(res);
        });

        this.userCommunitiesService.getUserCommunity(this.communityId, this.userId)
        .subscribe(response => {
          this.isJoined = response.isJoined;
        }, err => {
          this.isJoined = false;
          console.log(err);
        })
      }else{
        this.postsService.getPosts(this.communityId)
        .subscribe(res => {
          this.posts = res;
          console.log(this.posts);
          console.log(res);
        });
      }
      

      this.communitiesService.getCommunity(this.communityId)
        .subscribe(res => {
          this.communityName = String(res.communityName);
          this.communitySummary = String(res.communitySummary);
        })

    })

  }

  addPost(): void {
    this.dialog.open(AddPostComponent, {
      data: {
        // TODO: Pass current userID
        communityId: this.communityId,
        userId: this.userId
      },
      width: '40%',
      disableClose: true
    }).afterClosed().subscribe(() => {
      this.postsService.getPosts(this.communityId, this.userId)
        .subscribe(res => {
          this.posts = res;
        });
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

  joinOrLeaveCommunity(isJoin: boolean) {
    this.userCommunity.communityId = this.communityId;
    console.log("Community ID: " + this.communityId);
    //TODO: get userID from jwt
    this.userCommunity.userId = this.userId;
    this.userCommunity.isJoined = isJoin;
    console.log(this.userCommunity);
    this.userCommunitiesService.joinOrLeaveCommunity(this.userCommunity).subscribe();
    setTimeout(() => {
      //TODO: get userID from jwt
    
      this.userCommunitiesService.getUserCommunity(this.communityId, this.userId)
        .subscribe(response => {
          this.isJoined = response.isJoined;
          if (isJoin)
            this.snackBar.open('Welcome to ' + this.communityName + "!", '', {
              duration: 2000
            });
        }, err => {
          this.isJoined = false;
        })
    },
      200);


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

  archivePost(post: Post): void {
    this.dialog.open(ArchivePostComponent, {
      data: {
        postId: post.postId,
      },
      width: '40%',
      disableClose: true
    }).afterClosed().subscribe(() => {
        this.postsService.getPosts(this.communityId, this.userId)
          .subscribe(res => {
            this.posts = res;
          });
    });
  }


}
