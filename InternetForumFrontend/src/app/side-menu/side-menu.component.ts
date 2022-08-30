import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { CommunitiesService } from '../Services/communities.service';
import { Community } from '../Models/Community';
import { AddCommunityComponent } from '../add-community/add-community.component';
import { MatDialog } from '@angular/material/dialog';
import { AuthService } from '../Services/auth.service';
import { UsersCommunitiesService } from '../Services/users-communities.service';
import { UserCommunity } from '../Models/UserCommunity';

@Component({
  selector: 'app-side-menu',
  templateUrl: './side-menu.component.html',
  styleUrls: ['./side-menu.component.css']
})
export class SideMenuComponent implements OnInit {
  @Output() closeSidenav = new EventEmitter<void>();


  communities: Array<Community> = [];

  userCommunities: Array<UserCommunity> = [];

  userAdminCommunities: Array<UserCommunity> = [];
  // TODO: CLEAN UP GET POSTS IN .NET backend (unecessary data is sent)
  // posts: Array<Post> = [];

  constructor(private communitiesService: CommunitiesService, private userCommunitiesService: UsersCommunitiesService, private dialog: MatDialog, private authService: AuthService) { }

  userId = Number(this.authService.getUserIdFromJwt());

  ngOnInit(): void {
    if(this.userId){
      this.userCommunitiesService.getUserCommunities(this.userId)
      .subscribe(res => {
        this.userCommunities = res;
      });
  
      this.userCommunitiesService.getUserAdminCommunities(this.userId)
      .subscribe(res => {
        this.userAdminCommunities = res;
      });
    }
    this.communitiesService.getCommunities()
    .subscribe(res => {
      this.communities = res;
    });
    console.log(this.communities);
    //TODO: get userId from JWT

    
  }

  addCommunity(): void {
    this.dialog.open(AddCommunityComponent);
    }

    onClose(){
      this.closeSidenav.emit();
    }

    onLogout() {
      this.onClose();
      // TODO: uncomment logout when you fix logout();
      // this.authService.logout();
    }
}
