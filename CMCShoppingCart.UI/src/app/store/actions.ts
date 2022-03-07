import { createAction, props } from '@ngrx/store';

interface ProductQuantity {
    productId: string;
    quantity: number;
}

interface ProductId {
    productId: string;
}

export const addProductToBasket = createAction(
    '[Shopping Basket] Add product',
    props<ProductQuantity>()
);

export const removeProductFromBasket = createAction(
    '[Shopping Basket] Remove product',
    props<ProductId>()
);

export const clearBasket = createAction(
    '[Shopping Basket] Clear'
);