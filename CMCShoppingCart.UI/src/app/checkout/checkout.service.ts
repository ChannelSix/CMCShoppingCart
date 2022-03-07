import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CheckoutTotalRequest, CheckoutTotalDto } from './checkout.models';

@Injectable()
export class CheckoutService{
    private readonly controller = "checkout";

    constructor(private httpClient: HttpClient) {
    }

    getTotals(request: CheckoutTotalRequest): Observable<CheckoutTotalDto>{
        return this.httpClient.post<CheckoutTotalDto>(this.controller, request);
    }
}