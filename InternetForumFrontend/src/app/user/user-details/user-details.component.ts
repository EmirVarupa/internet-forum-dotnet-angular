import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { Post } from 'src/app/Models/Post';
import { User } from 'src/app/Models/User';
import { AuthService } from 'src/app/Services/auth.service';
import { PostsService } from 'src/app/Services/posts.service';
import { UsersService } from 'src/app/Services/users.service';
import { EditUserComponent } from '../edit-user/edit-user.component';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css']
})
export class UserDetailsComponent implements OnInit {
  user!: User;
  posts: Array<Post> = [];
  username = String(this.route.snapshot.paramMap.get('username'))

  constructor(public route: ActivatedRoute, private usersService: UsersService, private postsService: PostsService, private authService: AuthService, private dialog: MatDialog) { }

  userId = Number(this.authService.getUserIdFromJwt());

  ngOnInit(): void {

    this.usersService.getUser(this.username)
      .subscribe(res => {
        this.user = res;
      });

      this.postsService.getUserPostsByUsername(this.username)
      .subscribe(res => {
        this.posts = res;
      });
  }

  public createImgPath = (serverPath: string) => { 
    serverPath.replace(/\\/g, "/");
    return `https://localhost:5001/${serverPath}`; 
  }

  editUser(): void {
    this.dialog.open(EditUserComponent, {
      data: {
        userId: this.user.userId,
        role: this.user.role,
        userStatus: this.user.userStatus,
        username: this.user.username,
        password: this.user.password,
        firstName: this.user.firstName,
        lastName: this.user.lastName,
        email: this.user.email,
        dateCreated: this.user.dateCreated,
        imageUrl: this.user.imageUrl
      },
      width: '40%',
      disableClose: true
    });
  }
}
