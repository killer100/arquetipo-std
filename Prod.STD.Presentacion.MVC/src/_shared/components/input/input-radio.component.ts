import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-input-radio',
  template: `  
      <label class="radio-inline" *ngFor="let option of options">
          <input type="radio" 
           name="{{Name}}" 
          [value]="option.value" 
          (ngModelChange)="handleChange(option.value)"
          [(ngModel)]="Model">{{option.label}}
      </label>`,
})
export class InputRadioComponent implements OnInit {

  @Input() options?: Array<any> = [];
  @Input() Model?: any;
  @Input() Name?: any;
  @Output() ModelChange = new EventEmitter();

  constructor() { }

  ngOnInit() {
    
  }
  handleChange = (value) => {
    this.Model = value;
    this.ModelChange.emit(this.Model);
  };

}
