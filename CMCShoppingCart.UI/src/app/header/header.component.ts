import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { map, Observable, tap } from 'rxjs';
import { AppState, ShoppingBasket } from '../store/exports';

@Component({
    selector: 'basket-header',
    styleUrls: ['./header.component.scss'],
    templateUrl: './header.component.html'
})
export class HeaderComponent implements OnInit{

    itemCount$: Observable<number>|undefined;
    isCheckoutDisabled$: Observable<boolean>|undefined;

    constructor(private store: Store<AppState>){        
    }

    ngOnInit(): void {
        this.itemCount$ = this.store.select(s => s.shoppingBasket).pipe(
            map(this.getSumOfQuantity)
        )
        this.isCheckoutDisabled$ = this.itemCount$.pipe(
            map(count => count === 0)
        )
    }

    private getSumOfQuantity(sb: ShoppingBasket): number{
        if (sb == null) return 0;
        const result = Object.keys(sb)
            .map(key => sb[key])
            .reduce((previous, current) => previous + current, 0);
        return result;
    }
}