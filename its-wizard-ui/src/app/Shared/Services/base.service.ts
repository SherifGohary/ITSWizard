import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { tap, map, catchError } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class BaseService {

  protected backendServerUrl: string;

  protected options = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
};

  constructor(
    private _http: HttpClient,
  ) {
    this.backendServerUrl = "https://localhost:44398/api/"
   }



protected get<T>(url: string): Observable<T> {
    let fullUrl: string = `${url}`;
    return this._http.get<T>(fullUrl, this.options);
}

protected postData<T>(url: string, item?: any, headers?: any): Observable<T> {
    if(headers != null) {
        this.options.headers.append(headers.name, headers.value);
    }
    return this._http.post<T>(url, item, this.options);
}

}
