import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {STEPPER_GLOBAL_OPTIONS} from '@angular/cdk/stepper';
import { WizardService } from '../../Services/wizard.service';
import { Item, Step } from '../../Models/wizard.models';

@Component({
  selector: 'app-wizard',
  templateUrl: './wizard.component.html',
  styleUrls: ['./wizard.component.scss'],
  providers: [{
    provide: STEPPER_GLOBAL_OPTIONS, useValue: {showError: true}
  }]
})
export class WizardComponent implements OnInit {
  firstFormGroup!: FormGroup;
  secondFormGroup!: FormGroup;
  steps!: Step[];
  activeStepId!: number;
  activeStepItems!: Item[];

  constructor(
    private wizardService: WizardService,
    private _formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.firstFormGroup = this._formBuilder.group({
      firstCtrl: ['', Validators.required]
    });
    this.secondFormGroup = this._formBuilder.group({
      secondCtrl: ['', Validators.required]
    });
    this.getAllSteps();
  }

  getAllSteps(){
    this.wizardService.getAllSteps().subscribe(response=>{
      this.steps = response;
    });
  }

  addStep(){
    let step = new Step();
    step.id = 0;
    this.wizardService.addStep(step).subscribe(response=>{
      console.log(response);
      this.getAllSteps();
    });
  }

  deleteStep(step: Step){
    this.wizardService.deleteStep(step.id).subscribe(response=>{
      this.getAllSteps();
    });
  }

  stepperSelectionChange(selectedIndex: any){
    this.activeStepId = this.steps[selectedIndex].id;
    // this.wizardService.getAllStepItems(this.activeStepId).subscribe(response=>{
    //   this.activeStepItems = response;
    // });
  }

}
