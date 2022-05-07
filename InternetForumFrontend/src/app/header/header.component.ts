import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AddCommunityComponent } from '../add-community/add-community.component';
import { MatDialog } from '@angular/material/dialog';
import { AuthService } from '../Services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
@Output() sidenavToggle = new EventEmitter<void>();


  constructor(private dialog: MatDialog, private authService: AuthService) { }

  ngOnInit(): void {
  }

  onToggleSidenav(){
    this.sidenavToggle.emit();
  }

  addCommunity(): void {
    this.dialog.open(AddCommunityComponent);
    }

    onLogout(){
      this.authService.logout();
    } 
}
