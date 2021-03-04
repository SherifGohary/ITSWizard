import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/Shared/Services/base.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Item, Step } from '../Models/wizard.models';

@Injectable({
  providedIn: 'root'
})
export class WizardService extends BaseService{

  private stepsController: string = `${this.backendServerUrl}steps`;
  private itemsController: string = `${this.backendServerUrl}items`;

  constructor(
    http: HttpClient
  ) {
    super(http);
   }


  getAllSteps(): Observable<Step[]> {
    let url: string = `${this.stepsController}/get-all`;
    return this.get<Step[]>(url);
  }

  getAllStepItems(stepId: number): Observable<Item[]> {
    let url: string = `${this.itemsController}/get-step-items/${stepId}`;
    return this.get<Item[]>(url);
  }


  addStep(item: Step): Observable<Step> {
    let url: string = `${this.stepsController}/add`;
    return this.postData<Step>(url, item);
  }

  addItem(item: Item): Observable<Item> {
    let url: string = `${this.stepsController}/add`;
    return this.postData<Item>(url, item);
  }

  updateItem(item: Item): Observable<Item> {
    let url: string = `${this.itemsController}/update`;
    return this.postData<Item>(url, item);
  }

  deleteStep(id: number): Observable<any> {
    let url: string = `${this.stepsController}/delete/${id}`;
    return this.postData<any>(url);
  }

  deleteItem(id: number): Observable<any> {
    let url: string = `${this.itemsController}/delete/${id}`;
    return this.postData<any>(url);
  }
}
