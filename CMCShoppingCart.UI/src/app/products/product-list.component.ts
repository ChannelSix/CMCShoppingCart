import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductService } from './product.service';
import { Product } from './product.models';

@Component({
    templateUrl: './product-list.component.html'
})
export class ProductListComponent implements OnInit{
    products$: Observable<Product[]> | undefined;
    constructor(private productService: ProductService) {
    }

    ngOnInit(): void {
        this.products$ = this.productService.getAll();
    }
}