import { Component, OnInit } from '@angular/core';
import { NgForm, NumberValueAccessor } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Post } from 'src/app/Models/Post';
import { PostComment } from 'src/app/Models/PostComment';
import { UserCommunity } from 'src/app/Models/UserCommunity';
import { UserPostVote } from 'src/app/Models/UserPostVote';
import { AuthService } from 'src/app/Services/auth.service';
import { PostCommentsService } from 'src/app/Services/post-comments.service';
import { PostsService } from 'src/app/Services/posts.service';
import { UsersCommunitiesService } from 'src/app/Services/users-communities.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { AddPostComponent } from '../add-post/add-post.component';
import { UserPostCommentVote } from 'src/app/Models/UserPostCommentVote';
import { EditPostComponent } from '../edit-post/edit-post.component';
import { ArchivePostComponent } from '../archive-post/archive-post.component';
import { DeletePostCommentComponent } from '../delete-post-comment/delete-post-comment.component';

@Component({
  selector: 'app-post-details',
  templateUrl: './post-details.component.html',
  styleUrls: ['./post-details.component.css']
})
export class PostDetailsComponent implements OnInit {
  post!: Post;
  postComments: Array<PostComment> = [];
  userPostVote: UserPostVote = new UserPostVote();
  userPostCommentVote: UserPostCommentVote = new UserPostCommentVote();
  userCommunity: UserCommunity = new UserCommunity();
  voteCounter!: number;
  postComment = this.postComments[0];
  isJoined!: boolean;
  isLoggedIn!: boolean;
  changeText?: boolean;
  postId = Number(this.route.snapshot.paramMap.get('id'))
  communityId = Number(this.route.snapshot.paramMap.get('communityId'))
  newPostComment: PostComment = new PostComment();


  constructor(private router: Router, public route: ActivatedRoute, private dialog: MatDialog, public postsService: PostsService, public postCommentsService: PostCommentsService, private userCommunitiesService: UsersCommunitiesService ,private authService: AuthService, private snackBar: MatSnackBar) { }

  userId = Number(this.authService.getUserIdFromJwt());

  ngOnInit(): void {
    this.isLoggedIn = this.authService.isAuthenticated();

    this.postsService.getPost(this.postId)
      .subscribe(res => {
        this.post = res;
      });
      
      this.postsService.viewPost(this.postId).subscribe();
      if(this.userId){
    this.postCommentsService.getPostComments(this.postId, this.userId)
      .subscribe(res => {
        this.postComments = res;
        console.log(this.postComments);
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
      this.postCommentsService.getPostComments(this.postId)
      .subscribe(res => {
        this.postComments = res;
        console.log(this.postComments);
        console.log(res);
      });
    }
  }

  likePost(): void {
    this.userPostVote.userId = this.userId;
    this.userPostVote.postVoteId = this.post.postVote.voteId;
    this.userPostVote.postVoteDirection = 1;
    this.postsService.votePost(this.userPostVote)
    .subscribe(res => {
      this.post.postVote.voteCount = res;
    });
  }

  dislikePost(): void {
    this.userPostVote.userId = this.userId;
    this.userPostVote.postVoteId = this.post.postVote.voteId;
    this.userPostVote.postVoteDirection = -1;
    this.postsService.votePost(this.userPostVote)
    .subscribe(res => {
      this.post.postVote.voteCount = res;
    });
  }

  likePostComment(postComment: any): void {
    this.userPostCommentVote.userId = this.userId;
    this.userPostCommentVote.postCommentVoteId = postComment.postCommentVote.voteId;
    this.userPostCommentVote.postCommentVoteDirection = 1;
    this.postCommentsService.votePostComment(this.userPostCommentVote)
    .subscribe(res => {
      postComment.postCommentVote.voteCount = res;
    });
  }

  dislikePostComment(postComment: any): void {
    this.userPostCommentVote.userId = this.userId;
    this.userPostCommentVote.postCommentVoteId = postComment.postCommentVote.voteId;
    this.userPostCommentVote.postCommentVoteDirection = -1;
    this.postCommentsService.votePostComment(this.userPostCommentVote)
    .subscribe(res => {
      postComment.postCommentVote.voteCount = res;
    });
  }

  public createImgPath = (serverPath: string) => { 
    serverPath.replace(/\\/g, "/");
    return `https://localhost:5001/${serverPath}`; 
  }

  onSubmit(form: NgForm){
    this.newPostComment.postId = this.postId;
    this.newPostComment.userId = this.userId;
    this.newPostComment.commentContent = form.value.commentContent;
    console.log(this.newPostComment);

    this.postCommentsService.addPostComment(this.newPostComment).subscribe();
    form.reset();
    form.controls['commentContent'].setErrors(null);
      setTimeout(() => {
        this.postCommentsService.getPostComments(this.postId, this.userId)
      .subscribe(res => {
        this.postComments = res;
        res
      });
      },
        200);
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
            this.snackBar.open('Welcome to ' + this.post.community.communityName + "!", '', {
              duration: 2000
            });
        }, err => {
          this.isJoined = false;
        })
    },
      200);


  }

  addPost(): void {
    this.dialog.open(AddPostComponent, {
      data: {
        communityId: this.communityId,
        userId: this.userId
      },
      width: '40%',
      disableClose: true
    });
  }

  editPost(): void {
    this.dialog.open(EditPostComponent, {
      data: {
        postId: this.post.postId,
        postTitle: this.post.postTitle,
        postContent: this.post.postContent,
        imageUrl: this.post.imageUrl,
        link: this.post.link,
        isSpoiler: this.post.isSpoiler
      },
      width: '40%',
      disableClose: true
    }).afterClosed().subscribe(() => {
      this.postsService.getPost(this.postId)
      .subscribe(res => {
        this.post = res;
      });
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
        // TODO: Route back to other posts
    });
  }

  deletePostComment(postComment: PostComment): void {
    this.dialog.open(DeletePostCommentComponent, {
      data: {
        commentId: postComment.commentId,
      },
      width: '40%',
      disableClose: true
    }).afterClosed().subscribe(() => {
      this.postCommentsService.getPostComments(this.postId, this.userId)
          .subscribe(res => {
            this.postComments = res;
          });
    });
  }



  showSpoiler(post: Post){
    post.isSpoiler = false;
  }
}

