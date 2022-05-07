import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { CommunitiesService } from '../Services/communities.service';
import { Community } from '../Models/Community';
import { AddCommunityComponent } from '../add-community/add-community.component';
import { MatDialog } from '@angular/material/dialog';
import { AuthService } from '../Services/auth.service';

@Component({
  selector: 'app-side-menu',
  templateUrl: './side-menu.component.html',
  styleUrls: ['./side-menu.component.css']
})
export class SideMenuComponent implements OnInit {
  @Output() closeSidenav = new EventEmitter<void>();


  communities: Array<Community> = [];
  // TODO: CLEAN UP GET POSTS IN .NET backend (unecessary data is sent)
  // posts: Array<Post> = [];

  constructor(private communitiesService: CommunitiesService, private dialog: MatDialog, private authService: AuthService) { }

  ngOnInit(): void {
    this.communitiesService.getCommunities()
    .subscribe(res => {
      this.communities = res;
    });
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
