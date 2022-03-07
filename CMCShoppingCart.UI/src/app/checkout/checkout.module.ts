import { NgModule } from '@angular/core';
import { CommonModule } from '../common.module';

import { CheckoutComponent } from './checkout.component';

import { CheckoutService } from './checkout.service';

@NgModule({
    imports: [
        CommonModule
    ],
    declarations: [ 
        CheckoutComponent,
    ],
    providers: [
        CheckoutService
    ]
  })
  export class CheckoutModule { }