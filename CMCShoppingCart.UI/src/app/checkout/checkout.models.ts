export interface CheckoutRequest {
    lineItems: CheckOutRequestLineItem[];
}

export interface CheckOutRequestLineItem {
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

export interface CheckoutCompleteDto {
    orderNo: string;
}