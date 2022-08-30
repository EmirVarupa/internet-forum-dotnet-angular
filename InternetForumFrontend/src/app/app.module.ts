import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatSliderModule } from '@angular/material/slider';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatList, MatListModule } from '@angular/material/list';
import { HttpClientModule } from '@angular/common/http';
import { MatDialogActions, MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatRadioModule } from '@angular/material/radio';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatTabsModule } from '@angular/material/tabs';
import { MatChipsModule } from '@angular/material/chips';
import {MatTooltipModule} from '@angular/material/tooltip';
import { JwtModule } from '@auth0/angular-jwt';
import { TimeagoModule } from 'ngx-timeago';

import { CommunitiesComponent } from './communities/communities.component';
import { SideMenuComponent } from './side-menu/side-menu.component';
import { AddCommunityComponent } from './add-community/add-community.component';
import { HeaderComponent } from './header/header.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { PostListComponent } from './post/post-list/post-list.component';
import { PostDetailsComponent } from './post/post-details/post-details.component';
import { AddPostComponent } from './post/add-post/add-post.component';
import { MatMenuModule } from '@angular/material/menu';
import { ForbiddenComponent } from './error/forbidden/forbidden.component';
import { LoginComponent } from './auth/login/login.component';
import { AdminDashboardComponent } from './admin/admin-dashboard/admin-dashboard.component';
import { EditUserComponent } from './user/edit-user/edit-user.component';
import { ShortNumberPipe } from './Pipes/short-number.pipe';
import { RegisterComponent } from './auth/register/register.component';
import { UploadComponent } from './upload/upload.component';
import { UserDetailsComponent } from './user/user-details/user-details.component';

import { authInterceptorProviders } from './Interceptors/auth.interceptor';
import { EditPostComponent } from './post/edit-post/edit-post.component';
import { EditCommunityComponent } from './community/edit-community/edit-community.component';
import { ArchivePostComponent } from './post/archive-post/archive-post.component';
import { DeletePostCommentComponent } from './post/delete-post-comment/delete-post-comment.component';



export function tokenGetter() {
  return localStorage.getItem("jwt");
}

@NgModule({
  declarations: [
    AppComponent,
    CommunitiesComponent,
    SideMenuComponent,
    AddCommunityComponent,
    HeaderComponent,
    PostListComponent,
    PostDetailsComponent,
    AddPostComponent,
    ForbiddenComponent,
    LoginComponent,
    AdminDashboardComponent,
    EditUserComponent,
    ShortNumberPipe,
    RegisterComponent,
    UploadComponent,
    UserDetailsComponent,
    EditPostComponent,
    EditCommunityComponent,
    ArchivePostComponent,
    DeletePostCommentComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatSliderModule,
    MatButtonModule,
    MatToolbarModule,
    MatIconModule,
    MatSidenavModule,
    MatListModule,
    HttpClientModule,
    MatFormFieldModule,
    MatDialogModule,
    MatInputModule,
    MatSelectModule,
    FormsModule,
    MatRadioModule,
    MatCardModule,
    MatCheckboxModule,
    FormsModule,
    ReactiveFormsModule,
    MatMenuModule,
    FlexLayoutModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatSnackBarModule,
    MatTabsModule,
    MatChipsModule,
    MatTooltipModule,
    TimeagoModule.forRoot(),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:5001"],
        disallowedRoutes: []
      }
    })
  ],
  providers: [authInterceptorProviders],
  bootstrap: [AppComponent]
})
export class AppModule { }
