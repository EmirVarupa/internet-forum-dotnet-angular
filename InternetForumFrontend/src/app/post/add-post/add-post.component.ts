import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
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

  constructor(private dialog: MatDialog, private postsService: PostsService, private communitiesService: CommunitiesService) { }

  ngOnInit(): void {
    this.communitiesService.getCommunities().subscribe(res=>{
      this.communities = res;
    });
  }

  onSubmit() {
    console.log(this.newPost);
      this.postsService.addPost(this.newPost).subscribe();
      this.dialog.closeAll();
    }

    // TODO: UNSUBSCRIBE
    closeContainer() {
        this.dialog.closeAll();
      }
  
  // TEST

  // communityTypes: Array<CommunityType> = [];
  // communityName!: string;
  // communitySummary!: string;
  // newCommunity: Community = new Community();

  // constructor(private dialog: MatDialog, private communitiesService: CommunitiesService, private communityTypesService: CommunityTypesService) { }


  // ngOnInit(): void {
  //   this.communityTypesService.getCommunityTypes()
  //     .subscribe(res => {
  //       this.communityTypes = res;
  //     });
  // }

  // onSubmit() {
  //   this.communitiesService.addCommunity(this.newCommunity).subscribe();
  //   this.dialog.closeAll();
  // }

  // closeContainer() {
  //   this.dialog.closeAll();
  // }


// COMMUNITY
// {
//   "communityTypeId": 0,
//   "communityName": "string",
//   "communitySummary": "string"
// }


// POST
// {
//   "communityId": 0,
//   "userId": 0,
//   "postTitle": "string",
//   "postContent": "string",
//   "imageUrl": "string",
//   "link": "string",
//   "isSpoiler": true
// }


}
