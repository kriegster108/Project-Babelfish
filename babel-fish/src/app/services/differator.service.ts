import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LanguageService } from './language.service';

@Injectable({
  providedIn: 'root'
})
export class DifferatorService {
  private _http: HttpClient;
  public LangObj;
  constructor(http: HttpClient, language: LanguageService) {
    this._http = http;
  }

  private submitChanges() {
    return this._http.post('google.com', {foo: 'bar'});
  }

    public differator(originObject: any, localObject: any) {

    }
}
