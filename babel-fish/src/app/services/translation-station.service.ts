import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TranslationStationService {
  TRANSLATION_STATION_URL: string = "/api/";
  constructor(
    private http: HttpClient
  ) { }


  getLanguage(language:string): Observable<any> {
    return this.http.get(`${this.TRANSLATION_STATION_URL}translations/${language}/es`)
  }
}
