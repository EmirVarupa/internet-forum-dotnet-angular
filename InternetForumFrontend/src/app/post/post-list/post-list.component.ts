import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Post } from '../../Models/Post';
import { PostsService } from '../../Services/posts.service';
import { AddPostComponent } from '../add-post/add-post.component';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.css']
})
export class PostListComponent implements OnInit {
  posts: Array<Post> = [];

  constructor(private dialog: MatDialog,private postsService: PostsService) { }

  ngOnInit(): void {
    this.postsService.getPosts()
    .subscribe(res => {
      this.posts = res;
    });
  }

  addPost(): void {
    this.dialog.open(AddPostComponent,{
      width: '40%',
    });
  }
}
