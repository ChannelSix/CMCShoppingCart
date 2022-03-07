import { Component, Input } from '@angular/core';
import { AbstractControl, FormControl, ValidationErrors } from '@angular/forms';
import { Product } from './product.models';

@Component({    
    selector: 'product-item',
    styleUrls: ['./product-item.component.scss'],
    templateUrl: './product-item.component.html'
})
export class ProductItemComponent{
    @Input() product: Product|undefined;
    readonly quantityControl = new FormControl(1, this.quantityControlValidator);
    isBuying = false;

    onInitialBuy(): void{
        this.isBuying = true;
    }

    onBuyCancel(): void{
        this.quantityControl.setValue(1);
        this.isBuying = false;
    }

    onBuy(): void{
        this.isBuying = false;
        this.quantityControl.setValue(1);
    }

    private quantityControlValidator(control: AbstractControl): ValidationErrors | null{
        const message = 'Value muse be between 1 & 1000';
        const formControl = control as FormControl;
        const value = formControl.value;
        const isNan = isNaN(value);
        if (isNan) return { quantity: message };
        const number = Number(value);
        const result = number >= 1 && number <= 1000 ? null : { quantity: message };
        return result;
    }
}