import { NgModule } from '@angular/core';
import { CommonModule } from '../common.module';

import { BasketEmptyComponent } from './basket-empty.component';
import { CheckoutCompleteComponent } from './checkout-complete.component';
import { CheckoutComponent } from './checkout.component';

import { CheckoutService } from './checkout.service';
import { CheckoutHelperService } from './checkout-helper.service';

@NgModule({
    imports: [
        CommonModule
    ],
    declarations: [ 
        BasketEmptyComponent,
        CheckoutCompleteComponent,
        CheckoutComponent,
    ],
    providers: [
        CheckoutService,
        CheckoutHelperService
    ]
  })
  export class CheckoutModule { }