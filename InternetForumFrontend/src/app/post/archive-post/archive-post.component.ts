import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { PostsService } from 'src/app/Services/posts.service';

@Component({
  selector: 'app-archive-post',
  templateUrl: './archive-post.component.html',
  styleUrls: ['./archive-post.component.css']
})
export class ArchivePostComponent implements OnInit {
  postId!: number;
  constructor(private dialog: MatDialog, @Inject(MAT_DIALOG_DATA) public data: any, private postsService: PostsService) { }

  ngOnInit(): void {
  }


  onSubmit(data: any){
    this.postId = data.postId;
    this.postsService.archivePost(this.postId).subscribe();
    this.dialog.closeAll();
  }


}
