import { Component, OnInit } from '@angular/core';
import { CommunityType } from '../Models/CommunityType';
import { Community } from '../Models/Community'
import { CommunitiesService } from '../Services/communities.service';
import { CommunityTypesService } from '../Services/community-types.service';
import { MatDialog } from '@angular/material/dialog';


@Component({
  selector: 'app-add-community',
  templateUrl: './add-community.component.html',
  styleUrls: ['./add-community.component.css']
})
export class AddCommunityComponent implements OnInit {

  communityTypes: Array<CommunityType> = [];
  communityName!: string;
  communitySummary!: string;
  newCommunity: Community = new Community();

  constructor(private dialog: MatDialog, private communitiesService: CommunitiesService, private communityTypesService: CommunityTypesService) { }


  ngOnInit(): void {
    this.communityTypesService.getCommunityTypes()
      .subscribe(res => {
        this.communityTypes = res;
      });
  }

  onSubmit() {
    this.communitiesService.addCommunity(this.newCommunity).subscribe();
    this.dialog.closeAll();
  }

  closeContainer() {
    this.dialog.closeAll();
  }

}
