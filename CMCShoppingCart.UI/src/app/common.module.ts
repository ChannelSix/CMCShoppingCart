import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';

@NgModule({
    exports: [
        BrowserModule,
        FlexLayoutModule,
        MatButtonModule,
        MatCardModule
    ],
  })
  export class CommonModule { }