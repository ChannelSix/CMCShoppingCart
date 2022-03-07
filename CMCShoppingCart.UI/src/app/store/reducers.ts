import { createReducer, on } from '@ngrx/store';
import * as Actions from './actions';

export interface ShoppingBasket {
    [productId: string]: bigint;
}

export const initialState: ShoppingBasket = {};

export const shoppingBasketReducer = createReducer(
    initialState,
    on(Actions.addProductToBasket, (state, productQuantity) => {
        const currentQuantity = state[productQuantity.productId] ?? BigInt(0);
        const result = { 
            ...state, 
            [productQuantity.productId]: currentQuantity + productQuantity.quantity
        }
        return result
    }),
  );