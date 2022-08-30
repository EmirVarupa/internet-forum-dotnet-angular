import { Component, Inject, OnInit } from '@angular/core';
import {MatDialog, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Post } from 'src/app/Models/Post';
import { PostsService } from 'src/app/Services/posts.service';

@Component({
  selector: 'app-edit-post',
  templateUrl: './edit-post.component.html',
  styleUrls: ['./edit-post.component.css']
})
export class EditPostComponent implements OnInit {
editPost: Post = new Post();
response!: {dbPath: ''};


  constructor(private dialog: MatDialog, @Inject(MAT_DIALOG_DATA) public data: any, private postsService: PostsService) { }

  ngOnInit(): void {
  }




  onSubmit(data: any){
    console.log(this.data)
    this.editPost.postId = data.postId;
    this.editPost.postTitle = data.postTitle;
    this.editPost.postContent = data.postContent;
    if(this.response != null){
      this.editPost.imageUrl = this.response.dbPath;
    }else{
      this.editPost.imageUrl = data.imageUrl;
    }
    this.editPost.link = data.link;
    this.editPost.isSpoiler = data.isSpoiler;


    console.log(this.editPost)
    this.postsService.updatePost(this.editPost).subscribe();
    this.dialog.closeAll();
  }

  uploadFinished = (event : any) => { 
    this.response = event; 
  }

}
