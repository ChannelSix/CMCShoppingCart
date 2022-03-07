import { Component, OnDestroy, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Subject, takeUntil, tap } from 'rxjs';
import { AppState, removeProductFromBasket, ShoppingBasket } from '../store/exports';
import { CheckoutService } from './checkout.service';
import { CheckoutTotalDto, CheckoutTotalLineItemDto, CheckOutTotalLineItem, CheckoutTotalRequest } from './checkout.models';

@Component({
    templateUrl: './checkout.component.html'
})
export class CheckoutComponent implements OnInit, OnDestroy {

    private readonly unsubscribe = new Subject<unknown>();

    isEmpty: boolean|undefined;
    totals: CheckoutTotalDto|undefined;    

    constructor(private checkoutService: CheckoutService, private store: Store<AppState>){        
    }

    ngOnInit(): void {
        this.store.select(s => s.shoppingBasket).pipe(
            takeUntil(this.unsubscribe)
        ).subscribe(sb => this.checkForEmptyBasket(sb))
    }

    ngOnDestroy(): void {
        this.unsubscribe.next(undefined);
    }

    remove(lineItem: CheckoutTotalLineItemDto): void{
        const action = removeProductFromBasket({ productId: lineItem.productId });
        this.store.dispatch(action);
    }

    private checkForEmptyBasket(sb: ShoppingBasket): void{
        if (Object.keys(sb).length === 0){
            this.isEmpty = true;
        } else {
            this.isEmpty = false;
            this.getTotals(sb);
        }
    }

    private getTotals(sb: ShoppingBasket): void{
        const lineItems: CheckOutTotalLineItem[] = Object.keys(sb)
            .map<CheckOutTotalLineItem>(k => ({ productId: k, quantity: sb[k] }));

        const request: CheckoutTotalRequest = { lineItems };

        this.checkoutService.getTotals(request)
            .subscribe(dto => this.totals = dto);
    }
}