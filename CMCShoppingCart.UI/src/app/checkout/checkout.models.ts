export interface CheckoutTotalRequest {
    lineItems: CheckOutTotalLineItem[];
}

export interface CheckOutTotalLineItem {
    productId: string;
    quantity: number;
}

export interface CheckoutTotalDto {
    lineItems: CheckoutTotalLineItemDto[];
    shipping: number;
    total: number;
}

export interface CheckoutTotalLineItemDto {
    productId: string;
    name: string;
    quantity: number;
    unitPrice: number;
    totalPrice: number;
}