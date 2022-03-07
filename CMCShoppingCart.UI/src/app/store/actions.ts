import { createAction, props } from '@ngrx/store';

export interface ProductQuantity {
    productId: string;
    quantity: bigint;
}

export const addProductToBasket = createAction(
    '[Shopping Basket] Add product',
    props<ProductQuantity>()
);