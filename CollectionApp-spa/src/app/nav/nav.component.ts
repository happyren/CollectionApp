import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  model: any = {};
  jwtHelper = new JwtHelperService();
  userName: string;

  constructor(
    private authService: AuthService,
    private alertify: AlertifyService,
    private router: Router
  ) {}

  ngOnInit() {}

  login() {
    this.authService.login(this.model).subscribe(
      (next) => {
        this.alertify.success('Logged in successfully.');
      },
      (error) => {
        this.alertify.error(error);
      },
      () => {
        this.router.navigate(['/collections']);
      }
    );
  }

  loggedIn() {
    if (this.authService.loggedIn()) {
      const decodedToken = this.jwtHelper.decodeToken(
        localStorage.getItem('token')
      );
      this.userName = decodedToken.unique_name;
      return true;
    }
    return false;
  }

  logout() {
    localStorage.removeItem('token');
    this.alertify.success('logged out');
    this.router.navigate(['/home']);
    this.userName = null;
  }
}
