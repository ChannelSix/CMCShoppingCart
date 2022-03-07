export interface CheckoutTotalRequest {
    lineItems: CheckOutTotalLineItem[];
}

export interface CheckOutTotalLineItem {
    productId: string;
    quantity: number;
}