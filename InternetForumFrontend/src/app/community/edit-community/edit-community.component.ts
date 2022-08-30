import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Community } from 'src/app/Models/Community';
import { CommunityType } from 'src/app/Models/CommunityType';
import { CommunitiesService } from 'src/app/Services/communities.service';
import { CommunityTypesService } from 'src/app/Services/community-types.service';

@Component({
  selector: 'app-edit-community',
  templateUrl: './edit-community.component.html',
  styleUrls: ['./edit-community.component.css']
})
export class EditCommunityComponent implements OnInit {
  editCommunity: Community = new Community();
  communityTypes: Array<CommunityType> = [];

  constructor(private communitiesService: CommunitiesService, private communityTypesService: CommunityTypesService, private dialog: MatDialog, @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
    console.log(this.data)
    this.communityTypesService.getCommunityTypes()
      .subscribe(res => {
        this.communityTypes = res;
      })
  }


  onSubmit(data: any) {
    console.log(this.data)
    this.editCommunity.communityId = data.communityId;
    this.editCommunity.communityTypeId = data.communityType.typeId;
    this.editCommunity.communityName = data.communityName;
    this.editCommunity.communitySummary = data.communitySummary;


    console.log(this.editCommunity)
    this.communitiesService.updateCommunity(this.editCommunity).subscribe();
    this.dialog.closeAll();
  }

}
