import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AddCommunityComponent } from '../add-community/add-community.component';
import { MatDialog } from '@angular/material/dialog';
import { AuthService } from '../Services/auth.service';
import { LoginComponent } from '../auth/login/login.component';
import { RegisterComponent } from '../auth/register/register.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import { User } from '../Models/User';
import { UsersService } from '../Services/users.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  @Output() sidenavToggle = new EventEmitter<void>();
  isLoggedIn!: boolean;
  user!: User;
  role!: string;

  constructor(private dialog: MatDialog, private authService: AuthService, private snackBar: MatSnackBar, private usersService: UsersService) { }

  username = String(this.authService.getUsernameFromJwt());

  ngOnInit(): void {
    this.isLoggedIn = this.authService.isAuthenticated();

    if(this.isLoggedIn){
      this.usersService.getUser(this.username)
      .subscribe(res => {
        this.user = res;
      });
      this.role = this.authService.getRoleFromJwt();
    }
    
  }

  onToggleSidenav() {
    this.sidenavToggle.emit();
  }

  addCommunity(): void {
    this.dialog.open(AddCommunityComponent, {
      width: '40%',
      disableClose: true
    });
  }

  login(): void {
    this.dialog.open(LoginComponent, {
      width: '40%',
      disableClose: true
    }).afterClosed().subscribe(() => {
      this.isLoggedIn = this.authService.isAuthenticated();
    })
  }

  public createImgPath = (serverPath: string) => { 
    serverPath.replace(/\\/g, "/");
    return `https://localhost:5001/${serverPath}`; 
  }

  register(): void {
    this.dialog.open(RegisterComponent, {
      width: '40%',
      disableClose: true
    });
  }

  logout() {
    this.authService.logout();
    this.isLoggedIn = this.authService.isAuthenticated();
  }
}
