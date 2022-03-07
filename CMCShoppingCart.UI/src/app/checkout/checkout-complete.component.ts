import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { first } from 'rxjs';
import { AppState, clearBasket, ShoppingBasket } from '../store/exports';
import { CheckoutService } from './checkout.service';
import { CheckoutHelperService } from './checkout-helper.service';
import { CheckoutCompleteDto } from './checkout.models';

@Component({
    templateUrl: './checkout-complete.component.html'
})
export class CheckoutCompleteComponent implements OnInit{

    isEmpty: boolean|undefined;
    response: CheckoutCompleteDto|undefined;

    constructor(private checkoutHelperService: CheckoutHelperService, private checkoutService: CheckoutService, private store: Store<AppState>){        
    }

    ngOnInit(): void {
        this.store.select(s => s.shoppingBasket).pipe(
            first()
        ).subscribe(sb => this.checkForEmptyBasket(sb))
    }

    private checkForEmptyBasket(sb: ShoppingBasket): void{
        const isEmpty = this.checkoutHelperService.isBasketEmpty(sb);
        if (isEmpty){
            this.isEmpty = true;
        } else {
            this.isEmpty = false;
            this.completeCheckout(sb);
        }
    }

    private completeCheckout(sb: ShoppingBasket): void{
        const request = this.checkoutHelperService.toCheckoutRequest(sb);
        this.checkoutService.checkoutComplete(request)
            .subscribe(dto => this.onCheckoutComplete(dto));
    }

    private onCheckoutComplete(response: CheckoutCompleteDto): void{
        this.response = response;
        this.store.dispatch(clearBasket());
    }
}