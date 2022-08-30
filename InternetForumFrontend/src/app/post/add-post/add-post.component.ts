import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Community } from 'src/app/Models/Community';
import { Post } from 'src/app/Models/Post';
import { User } from 'src/app/Models/User';
import { CommunitiesService } from 'src/app/Services/communities.service';
import { PostsService } from 'src/app/Services/posts.service';

@Component({
  selector: 'app-add-post',
  templateUrl: './add-post.component.html',
  styleUrls: ['./add-post.component.css']
})
export class AddPostComponent implements OnInit {

  communities: Array<Community> = [];
  users: Array<User> = [];
  postTitle!: string;
  postContent!: string;
  imageUrl?: string;
  link!: string;
  isSpoiler = false;
  newPost: Post = new Post();
  response!: {dbPath: ''};

  // defaultCommunity: number = this.data.communityId;
  // communityDefault: any;

  constructor(private dialog: MatDialog, private postsService: PostsService, private communitiesService: CommunitiesService, @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
    // this.communitiesService.getCommunities().subscribe(res => {
    //   this.communities = res;

      
    //   // this.communityDefault = this.communities.find(c => c.communityId === 3);
    //   // console.log(this.defaultCommunity)
    // });


    // this.addPost.controls
  }

  onSubmit() {
    this.newPost.userId = this.data.userId;
    this.newPost.communityId = this.data.communityId;
    if(this.response != undefined){
      this.newPost.imageUrl = this.response.dbPath;
    }
    
    console.log(this.newPost);
    this.postsService.addPost(this.newPost).subscribe();
    this.dialog.closeAll();
  }

  comparer(o1: any, o2: any): boolean {
    // if possible compare by object's name, and not by reference.
    return o1 && o2 ? o1.label === o2.label : o2 === o2;
  }

  uploadFinished = (event : any) => { 
    this.response = event; 
  }
  
  public createImgPath = (serverPath: string) => { 
    serverPath.replace(/\\/g, "/");
    return `https://localhost:5001/${serverPath}`; 
  }

}
