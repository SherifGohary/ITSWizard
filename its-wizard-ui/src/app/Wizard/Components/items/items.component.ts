import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Item } from '../../Models/wizard.models';
import { WizardService } from '../../Services/wizard.service';

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.scss']
})
export class ItemsComponent implements OnInit {

  step = 0;
  items!: Item[];
  stepId!: number;

  @Input('items')
  set _items(value: Item[]){
    this.items = value;
  }

  @Input('stepId')
  set _stepId(value: number){
    if(value){
      this.stepId = value;
      this.items = this.getStepItems(value);
    }
  }

  constructor(
    private wizardService: WizardService,
    private _formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {
  }


  setStep(index: number) {
    this.step = index;
  }

  nextStep() {
    this.step++;
  }

  prevStep() {
    this.step--;
  }

  getStepItems(stepId: number): Item[]{
    let items:Item[] = [];
    this.wizardService.getAllStepItems(stepId).subscribe(response=>{
      console.log(response);
      items = response? response: items;
    });
    return items;
  }


}
