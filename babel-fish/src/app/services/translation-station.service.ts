import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import * as english from '../../languages/english.json';

@Injectable({
  providedIn: 'root'
})
export class TranslationStationService {
  TRANSLATION_STATION_URL: string = "http://localhost:8080/api/";
  constructor(
    private http: HttpClient
  ) { }


  getLanguage(language:string): Observable<any> {
    english['newText'] = "new text";
    return new Observable( (obs) => {
      obs.next(english);
      obs.complete();
    });
    //return this.http.get(`${this.TRANSLATION_STATION_URL}translations/${language}`);
  }

  getUnverifiedLanguage(language:string): Observable<any> {
    return this.http.get(`${this.TRANSLATION_STATION_URL}translations/unverified/${language}`);
  }

  sendNewTranslations(newTranslations:any) {
    return this.http.post(`${this.TRANSLATION_STATION_URL}translations/unverified/en`, newTranslations);
  }

  sendVerifiedTranslation(translationObject:translationObj) {
    return this.http.patch(`${this.TRANSLATION_STATION_URL}translations/unverified/en`, translationObject);
  }
}

declare interface translationObj {
  key: string;
  value: string;
}
