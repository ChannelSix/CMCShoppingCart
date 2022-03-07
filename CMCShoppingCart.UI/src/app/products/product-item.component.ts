import { Component, Input } from '@angular/core';
import { AbstractControl, FormControl, ValidationErrors } from '@angular/forms';
import { Store } from '@ngrx/store';
import { Product } from './product.models';
import { addProductToBasket, AppState } from '../store/exports';

@Component({    
    selector: 'product-item',
    styleUrls: ['./product-item.component.scss'],
    templateUrl: './product-item.component.html'
})
export class ProductItemComponent{
    @Input() product: Product|undefined;
    // readonly quantityControl = new FormControl(1, this.quantityControlValidator);
    // isBuying = false;

    constructor(private store: Store<AppState>){        
    }

    // onInitialBuy(): void{
    //     this.isBuying = true;
    // }

    // onBuyCancel(): void{
    //     this.quantityControl.setValue(1);
    //     this.isBuying = false;
    // }

    onBuy(): void{
        if (this.product){
            const action = addProductToBasket({ productId: this.product.id, quantity: 1 });
            this.store.dispatch(action);
        }
        // if (this.product){
        //     const quantity = Number(this.quantityControl.value);        
        //     const action = addProductToBasket({ productId: this.product.id, quantity });
        //     this.store.dispatch(action);
        //     this.quantityControl.setValue(1);
        //     this.isBuying = false;
        // }
    }

    // private quantityControlValidator(control: AbstractControl): ValidationErrors | null{
    //     const message = 'Quantity must be a whole number between 1 & 1000';
    //     const formControl = control as FormControl;
    //     const value = formControl.value;
    //     const isNan = isNaN(value);
    //     if (isNan) return { quantity: message };
    //     const number = Number(value);
    //     const result = number >= 1 && number <= 1000 && Number.isInteger(number) ? null : { quantity: message };
    //     return result;
    // }
}