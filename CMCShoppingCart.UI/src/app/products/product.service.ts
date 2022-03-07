import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from './product.models';

@Injectable()
export class ProductService{
    private readonly controller = "product";

    constructor(private httpClient: HttpClient) {
    }

    getAll(): Observable<Product[]>{
        return this.httpClient.get<Product[]>(this.controller);
    }
}