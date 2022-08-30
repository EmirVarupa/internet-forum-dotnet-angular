import { Component, Inject, OnInit } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { User } from 'src/app/Models/User';
import { UserRole } from 'src/app/Models/UserRole';
import { UserStatus } from 'src/app/Models/UserStatus';
import { RolesService } from 'src/app/Services/roles.service';
import { UserStatusesService } from 'src/app/Services/user-statuses.service';
import { UsersService } from 'src/app/Services/users.service';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit {
  editUser: User = new User();
  roles: Array<UserRole> = [];
  userStatuses: Array<UserStatus> = [];

  constructor(private usersService: UsersService, private rolesService: RolesService, private userStatusesService: UserStatusesService, private dialog: MatDialog, @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
    console.log(this.data)
    this.rolesService.getUserRoles()
    .subscribe(res =>{
      this.roles = res;
    })

    this.userStatusesService.getUserStatuses()
    .subscribe(res => {
      this.userStatuses = res;
    })
    //TODO: this.data.role retuns undefined while userstatus works normally. but even though it returns undefined it works in the edit??!?
    // console.log(this.data.role);
    // console.log(this.data);
  }
  onSubmit(data: any){
    console.log(this.data)
    this.editUser.userId = data.userId;
    this.editUser.statusId = data.userStatus.statusId;
    this.editUser.roleId = data.role;
    this.editUser.username = data.username;
    this.editUser.password = data.password;
    this.editUser.email = data.email;
    this.editUser.firstName = data.firstName;
    this.editUser.lastName = data.lastName;
    this.editUser.imageUrl = data.imageUrl;

    console.log(this.editUser)
    this.usersService.updateUser(this.editUser).subscribe();
    this.dialog.closeAll();
  }
}
