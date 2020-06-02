import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { TopCollectorsComponent } from './top-collectors/top-collectors.component';
import { FollowingCollectorsComponent } from './following-collectors/following-collectors.component';
import { MessagesComponent } from './messages/messages.component';
import { CollectionsComponent } from './collections/collections.component';
import { AuthGuard } from './_guards/auth.guard';

export const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'collections', component: CollectionsComponent },
      { path: 'top-collectors', component: TopCollectorsComponent },
      { path: 'messages', component: MessagesComponent },
      { path: 'following-collectors', component: FollowingCollectorsComponent },
    ],
  },
  { path: '**', redirectTo: '', pathMatch: 'full' },
];
