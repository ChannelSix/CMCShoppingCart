import { NgModule } from '@angular/core';

import { HTTP_INTERCEPTORS } from '@angular/common/http';

import { CommonModule } from './common.module';

import { AppRoutingModule } from './app-routing.module';
import { ProductModule } from './products/product.module';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';

import { StoreModule } from '@ngrx/store';
import { shoppingBasketReducer } from './store/reducers';

import { AddApiUrlInterceptor } from './add-api-url.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent
  ],
  imports: [
    AppRoutingModule,
    CommonModule,
    ProductModule,
    StoreModule.forRoot({
        shoppingBasket: shoppingBasketReducer
    }),
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AddApiUrlInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
