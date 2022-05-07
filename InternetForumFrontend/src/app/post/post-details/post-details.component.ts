import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Post } from 'src/app/Models/Post';
import { PostComment } from 'src/app/Models/PostComment';
import { PostCommentsService } from 'src/app/Services/post-comments.service';
import { PostsService } from 'src/app/Services/posts.service';

@Component({
  selector: 'app-post-details',
  templateUrl: './post-details.component.html',
  styleUrls: ['./post-details.component.css']
})
export class PostDetailsComponent implements OnInit {
  post!: Post;
  postComments: Array<PostComment> = [];

  postComment = this.postComments[0];

  constructor(private router: Router, public route: ActivatedRoute, public postsService: PostsService, public postCommentsService: PostCommentsService) { }

  ngOnInit(): void {
    const postId = this.route.snapshot.paramMap.get('id');
    this.postsService.getPost(postId)
      .subscribe(res => {
        this.post = res;
      });

    this.postCommentsService.getPostComments()
      .subscribe(res => {
        this.postComments = res;
      });
  }

}

