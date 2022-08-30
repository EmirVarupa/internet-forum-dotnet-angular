import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { PostCommentsService } from 'src/app/Services/post-comments.service';


@Component({
  selector: 'app-delete-post-comment',
  templateUrl: './delete-post-comment.component.html',
  styleUrls: ['./delete-post-comment.component.css']
})
export class DeletePostCommentComponent implements OnInit {
  commentId!: number;
  constructor(private dialog: MatDialog, @Inject(MAT_DIALOG_DATA) public data: any, private postCommentsService: PostCommentsService) { }

  ngOnInit(): void {
  }


  onSubmit(data: any){
    this.commentId = data.commentId;
    this.postCommentsService.deletePostComment(this.commentId).subscribe();
    this.dialog.closeAll();
  }


}
