import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { FollowingCollectorsComponent } from './following-collectors/following-collectors.component';
import { MessagesComponent } from './messages/messages.component';
import { AuthGuard } from './_guards/auth.guard';
import { GundamComponent } from './collection/gundam/gundam.component';
import { GundamDetailComponent } from './collection/gundam-detail/gundam-detail.component';
import { GundamDetailResolver } from './_resolvers/gundam-detail.resolver';
import { GundamListResolver } from './_resolvers/gundam-list.resolver';
import { UserListResolver } from './_resolvers/user-list.resolver';
import { MemberComponent } from './members/member/member.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { UserDetailResolver } from './_resolvers/user-detail.resolver';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { UserEditResolver } from './_resolvers/user-edit.resolver';
import { PreventUnsavedChangesGuard } from './_guards/prevent-unsaved-changes.guard';

export const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {
        path: 'collections',
        component: GundamComponent,
        resolve: { gundams: GundamListResolver },
      },
      {
        path: 'collections/:id',
        component: GundamDetailComponent,
        resolve: { gundam: GundamDetailResolver },
      },
      {
        path: 'members',
        component: MemberComponent,
        resolve: { users: UserListResolver },
      },
      {
        path: 'members/:id',
        component: MemberDetailComponent,
        resolve: { user: UserDetailResolver },
      },
      {
        path: 'member/edit',
        component: MemberEditComponent,
        resolve: { user: UserEditResolver },
        canDeactivate: [PreventUnsavedChangesGuard]
      },
      { path: 'messages', component: MessagesComponent },
      { path: 'following-collectors', component: FollowingCollectorsComponent },
    ],
  },
  { path: '**', redirectTo: '', pathMatch: 'full' },
];
