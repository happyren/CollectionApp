import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { TopCollectorsComponent } from './top-collectors/top-collectors.component';
import { FollowingCollectorsComponent } from './following-collectors/following-collectors.component';
import { MessagesComponent } from './messages/messages.component';
import { AuthGuard } from './_guards/auth.guard';
import { GundamComponent } from './collection/gundam/gundam.component';
import { GundamDetailComponent } from './collection/gundam-detail/gundam-detail.component';
import { GundamDetailResolver } from './_resolvers/gundam-detail.resolver';
import { GundamListResolver } from './_resolvers/gundam-list.resolver';

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
      { path: 'top-collectors', component: TopCollectorsComponent },
      { path: 'messages', component: MessagesComponent },
      { path: 'following-collectors', component: FollowingCollectorsComponent },
    ],
  },
  { path: '**', redirectTo: '', pathMatch: 'full' },
];
