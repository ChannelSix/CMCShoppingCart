import { createReducer, on } from '@ngrx/store';
import * as Actions from './actions';

export interface ShoppingBasket {
    [productId: string]: number;
}

export const initialState: ShoppingBasket = {};

export const shoppingBasketReducer = createReducer(
    initialState,
    on(Actions.addProductToBasket, (state, productQuantity) => {
        const currentQuantity = state[productQuantity.productId] ?? 0;
        const result = { 
            ...state, 
            [productQuantity.productId]: currentQuantity + productQuantity.quantity
        }
        return result
    }),
    on(Actions.removeProductFromBasket, (state, productIdProps) => {
        const result: ShoppingBasket = {};
        Object.keys(state)
            .filter(key => key !== productIdProps.productId)
            .forEach(key => result[key] = state[key]);
        return result;
    }),
    on(Actions.clearBasket, () => {
        const result: ShoppingBasket = {};
        return result;
    }),
  );