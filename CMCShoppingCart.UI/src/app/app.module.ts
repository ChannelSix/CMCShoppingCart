import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { CommonModule } from './common.module';

import { AppRoutingModule } from './app-routing.module';
import { ProductModule } from './products/product.module';

import { AppComponent } from './app.component';

import { AddApiUrlInterceptor } from './add-api-url.interceptor';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    // infrastructure
    BrowserAnimationsModule,
    //BrowserModule,
    CommonModule,
    HttpClientModule,

    // custom
    AppRoutingModule,
    ProductModule
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
