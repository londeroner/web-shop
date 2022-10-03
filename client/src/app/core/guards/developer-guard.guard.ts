import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { map, Observable } from 'rxjs';
import { AccountService } from 'src/app/account/account.service';

@Injectable({
  providedIn: 'root'
})
export class DeveloperGuardGuard implements CanActivate {
  
  constructor(private accountService: AccountService, private router: Router) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> {
    return this.accountService.currentPolicy$.pipe(
      map(policy => {
        if (!policy)
        {
          console.log("navigated 1");
          this.router.navigate(['/'], { queryParams: {returnUrl: state.url}});
        }
        if (!policy.canCheckErrors)
        {
          console.log("navigated 2");
          this.router.navigate(['/'], { queryParams: {returnUrl: state.url}});
        }

        return true;
      })
    );
  }
  
}
