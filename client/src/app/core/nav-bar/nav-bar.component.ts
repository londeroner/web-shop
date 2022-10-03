import { Component, OnInit } from '@angular/core';
import { map, Observable } from 'rxjs';
import { AccountService } from 'src/app/account/account.service';
import { BasketService } from 'src/app/basket/basket.service';
import { IBasket } from 'src/app/shared/models/basket';
import { IUser } from 'src/app/shared/models/user';
import { IPolicy } from 'src/app/shared/models/userpolicy';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {
  basket$: Observable<IBasket>;
  currentUser$: Observable<IUser>;
  userPolicy$: Observable<IPolicy>;

  constructor(private basketService: BasketService, private accountService: AccountService) { }

  ngOnInit(): void {
    this.basket$ = this.basketService.basket$;
    this.currentUser$  = this.accountService.currentUser$;
    this.userPolicy$ = this.accountService.currentPolicy$;
  }

  logout() {
    this.accountService.logout();
  }

}
