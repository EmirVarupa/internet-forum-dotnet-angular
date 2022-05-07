import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommunitiesComponent } from './communities/communities.component';
import { SideMenuComponent } from './side-menu/side-menu.component';
import { AddCommunityComponent } from './add-community/add-community.component';
import { PostListComponent } from './post/post-list/post-list.component';
import { PostDetailsComponent } from './post/post-details/post-details.component';

// TODO: IMPLEMENT LAZY LOADING SO THAT POSTS LOAD WITHOUT PAGINATIONS WHEN SCROLLING
const routes: Routes = [
  {path: '', component: CommunitiesComponent},
  {path: 'posts', component: PostListComponent},
  {path: 'addcommunity', component: AddCommunityComponent},
  {path: 'details/:id', component: PostDetailsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
