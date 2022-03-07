import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ProductListComponent } from './products/product-list.component';
import { CheckoutComponent } from './checkout/checkout.component';

const routes: Routes = [    
    { path: 'products', component: ProductListComponent },
    { path: 'checkout', component: CheckoutComponent },
    { path: '', redirectTo: 'products', pathMatch: 'full' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
