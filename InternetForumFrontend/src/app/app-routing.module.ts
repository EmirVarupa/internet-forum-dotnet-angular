import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommunitiesComponent } from './communities/communities.component';
import { SideMenuComponent } from './side-menu/side-menu.component';
import { AddCommunityComponent } from './add-community/add-community.component';
import { PostListComponent } from './post/post-list/post-list.component';
import { PostDetailsComponent } from './post/post-details/post-details.component';
import { ForbiddenComponent } from './error/forbidden/forbidden.component';
import { AuthGuard } from './guards/auth.guard';
import { AdminDashboardComponent } from './admin/admin-dashboard/admin-dashboard.component';
import { UserDetailsComponent } from './user/user-details/user-details.component';

// TODO: IMPLEMENT LAZY LOADING SO THAT POSTS LOAD WITHOUT PAGINATIONS WHEN SCROLLING
const routes: Routes = [
  {path: '', component: CommunitiesComponent},
  {path: 'posts/:id', component: PostListComponent},
  {path: 'user/:username', component: UserDetailsComponent},
  {path: 'addcommunity', component: AddCommunityComponent, canActivate: [AuthGuard]},
  {path: 'details/:communityId/:id', component: PostDetailsComponent},
  {path: 'dashboard', component: AdminDashboardComponent, canActivate: [AuthGuard]},
  {path: 'forbidden', component: ForbiddenComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
