import { Injectable } from '@angular/core';
import { Gundam } from '../_models/gundam';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { GundamService } from '../_services/gundam.service';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class GundamDetailResolver implements Resolve<Gundam> {
  constructor(
    private gundamService: GundamService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Gundam> {
    return this.gundamService.getGundam(route.params.id).pipe(
      catchError((error) => {
        this.alertify.error('Problem retrieving data');
        this.router.navigate(['/collections']);
        return of(null);
      })
    );
  }
}
