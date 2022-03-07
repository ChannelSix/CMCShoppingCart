import { Component, Input } from '@angular/core';
import { Product } from './product.models';

@Component({    
    selector: 'product-item',
    templateUrl: './product-item.component.html'
})
export class ProductItemComponent{
    @Input() product: Product|undefined;
}