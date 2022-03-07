import { Injectable } from '@angular/core';
import { ShoppingBasket } from '../store/reducers';
import { CheckoutRequest, CheckOutRequestLineItem} from './checkout.models';

@Injectable()
export class CheckoutHelperService {
    public isBasketEmpty(sb: ShoppingBasket): boolean{
        const result = Object.keys(sb).length === 0;
        return result;
    }

    public toCheckoutRequest(sb: ShoppingBasket): CheckoutRequest{
        const lineItems: CheckOutRequestLineItem[] = Object.keys(sb)
            .map<CheckOutRequestLineItem>(k => ({ productId: k, quantity: sb[k] }));

        const result: CheckoutRequest = { lineItems };
        return result;
    }
}