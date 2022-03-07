import { Component, OnDestroy, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Subject, takeUntil } from 'rxjs';
import { AppState, removeProductFromBasket, ShoppingBasket } from '../store/exports';
import { CheckoutService } from './checkout.service';
import { CheckoutHelperService } from './checkout-helper.service';
import { CheckoutTotalDto, CheckoutTotalLineItemDto } from './checkout.models';

@Component({
    styleUrls: ['./checkout.component.scss'],
    templateUrl: './checkout.component.html'
})
export class CheckoutComponent implements OnInit, OnDestroy {

    private readonly unsubscribe = new Subject<unknown>();

    isEmpty: boolean|undefined;
    totals: CheckoutTotalDto|undefined;    

    constructor(private checkoutHelperService: CheckoutHelperService, private checkoutService: CheckoutService, private store: Store<AppState>){        
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
        const isEmpty = this.checkoutHelperService.isBasketEmpty(sb);
        if (isEmpty){
            this.isEmpty = true;
        } else {
            this.isEmpty = false;
            this.getTotals(sb);
        }
    }

    private getTotals(sb: ShoppingBasket): void{
        const request = this.checkoutHelperService.toCheckoutRequest(sb);
        this.checkoutService.getTotals(request)
            .subscribe(dto => this.totals = dto);
    }
}