import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CheckoutRequest, CheckoutTotalDto, CheckoutCompleteDto } from './checkout.models';

@Injectable()
export class CheckoutService{
    private readonly controller = "checkout";

    constructor(private httpClient: HttpClient) {
    }

    getTotals(request: CheckoutRequest): Observable<CheckoutTotalDto>{
        return this.httpClient.post<CheckoutTotalDto>(this.controller, request);
    }

    checkoutComplete(request: CheckoutRequest): Observable<CheckoutCompleteDto>{
        return this.httpClient.post<CheckoutCompleteDto>(`${this.controller}/complete`, request);
    }
}