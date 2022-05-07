import { Component } from '@angular/core';
import { AddCommunityComponent } from './add-community/add-community.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'InternetForumFrontend';

  constructor(private dialog: MatDialog) { }

  addCommunity(): void {
    this.dialog.open(AddCommunityComponent);
    }
}
