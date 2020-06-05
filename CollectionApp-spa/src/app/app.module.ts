import { BrowserModule, HammerGestureConfig, HAMMER_GESTURE_CONFIG } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { RouterModule } from '@angular/router';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { JwtModule } from '@auth0/angular-jwt';
import { NgxGalleryModule } from '@kolkov/ngx-gallery';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { TopCollectorsComponent } from './top-collectors/top-collectors.component';
import { FollowingCollectorsComponent } from './following-collectors/following-collectors.component';
import { MessagesComponent } from './messages/messages.component';
import { appRoutes } from './routes';
import { GundamComponent } from './collection/gundam/gundam.component';
import { GundamCardComponent } from './collection/gundam-card/gundam-card.component';
import { GundamDetailComponent } from './collection/gundam-detail/gundam-detail.component';
import { GundamDetailResolver } from './_resolvers/gundam-detail.resolver';
import { GundamListResolver } from './_resolvers/gundam-list.resolver';

export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    TopCollectorsComponent,
    FollowingCollectorsComponent,
    MessagesComponent,
    GundamComponent,
    GundamCardComponent,
    GundamDetailComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    NgxGalleryModule,
    TabsModule.forRoot(),
    BsDropdownModule.forRoot(),
    RouterModule.forRoot(appRoutes),
    JwtModule.forRoot({
      config: {
        tokenGetter,
        whitelistedDomains: ['localhost:5000'],
        blacklistedRoutes: ['localhost:5000/api/auth'],
      },
    }),
  ],
  providers: [
    AuthService,
    ErrorInterceptorProvider,
    GundamDetailResolver,
    GundamListResolver
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
