import { Component, AfterViewInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { EditCommunityComponent } from 'src/app/community/edit-community/edit-community.component';
import { Community } from 'src/app/Models/Community';
import { User } from 'src/app/Models/User';
import { CommunitiesService } from 'src/app/Services/communities.service';
import { UsersService } from 'src/app/Services/users.service';
import { EditUserComponent } from '../../user/edit-user/edit-user.component';

@Component({
  selector: 'app-user-table',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css']
})
export class AdminDashboardComponent implements AfterViewInit {
  displayedColumns: string[] = ['userId', 'username', 'firstName', 'lastName', 'email', 'dateCreated', 'role', 'status', 'action'];
  displayedColumnsCommunity: string[] = ['communityId', 'communityName', 'typeName', 'communitySummary', 'action'];
  dataSource!: any;
  dataSourceCommunity!: any;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  @ViewChild(MatPaginator) paginatorCommunity!: MatPaginator;
  @ViewChild(MatSort) sortCommunity!: MatSort;

  constructor(private userService: UsersService, private communitiesService: CommunitiesService, private dialog: MatDialog, private snackBar: MatSnackBar) { }

  ngAfterViewInit() {
    this.userService.getUsers()
      .subscribe(res => {
        this.dataSource = new MatTableDataSource(res);

        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });

    this.communitiesService.getCommunities()
      .subscribe(res => {
        this.dataSourceCommunity = new MatTableDataSource(res);

        this.dataSourceCommunity.paginator = this.paginatorCommunity;
        this.dataSourceCommunity.sort = this.sortCommunity;
      })
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  applyFilterCommunity(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSourceCommunity.filter = filterValue.trim().toLowerCase();
    if (this.dataSourceCommunity.paginator) {
      this.dataSourceCommunity.paginator.firstPage();
    }
  }

  editUser(item: User): void {
    console.log(item);
    this.dialog.open(EditUserComponent, {
      data: {
        userId: item.userId,
        role: item.role,
        userStatus: item.userStatus,
        username: item.username,
        password: item.password,
        firstName: item.firstName,
        lastName: item.lastName,
        email: item.email,
        dateCreated: item.dateCreated,
        imageUrl: item.imageUrl
      },
      width: '40%',
      disableClose: true
    }).afterClosed().subscribe(() => {
      this.userService.getUsers()
        .subscribe(res => {
          this.dataSource = new MatTableDataSource(res);

          this.dataSource.paginator = this.paginator;
          this.dataSource.sort = this.sort;
        });
    });
  }

  editCommunity(item: Community): void {
    console.log(item);
    this.dialog.open(EditCommunityComponent, {
      data: {
        communityId: item.communityId,
        communityName: item.communityName,
        communityType: item.communityType,
        communitySummary: item.communitySummary,
      },
      width: '40%',
      disableClose: true
    }).afterClosed().subscribe(() => {
      this.communitiesService.getCommunities()
        .subscribe(res => {
          this.dataSourceCommunity = new MatTableDataSource(res);

          this.dataSourceCommunity.paginator = this.paginatorCommunity;
          this.dataSourceCommunity.sort = this.sortCommunity;
        });
    });
  }


  archiveCommunity(item: Community): void {
    const index = this.dataSourceCommunity.data.indexOf(item);
    this.dataSourceCommunity.data.splice(index, 1);
    this.dataSourceCommunity._updateChangeSubscription();
    this.dataSourceCommunity.paginator = this.paginator;
    this.dataSourceCommunity.sort = this.sort;
    this.communitiesService.archiveCommunity(item.communityId).subscribe(res => {
      this.snackBar.open('Community archived successfully!', '', {
        duration: 3000
      });

    });
  }

  // TODO: check if isArchived
  archiveUser(item: User): void {
    const index = this.dataSource.data.indexOf(item);
    this.dataSource.data.splice(index, 1);
    this.dataSource._updateChangeSubscription();
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    this.userService.archiveUser(item.userId).subscribe(res => {
      this.snackBar.open('User archived successfully!', '', {
        duration: 3000
      });

    });
  }
}
