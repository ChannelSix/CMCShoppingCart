import { NgModule } from '@angular/core';
import { CommonModule } from '../common.module';

import { ProductItemComponent } from './product-item.component';
import { ProductListComponent } from './product-list.component';

import { ProductService } from './product.service';

@NgModule({
    imports: [
        CommonModule
    ],
    declarations: [ 
        ProductItemComponent,
        ProductListComponent
    ],
    providers: [
        ProductService
    ]
  })
  export class ProductModule { }