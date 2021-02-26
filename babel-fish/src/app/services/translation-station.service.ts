import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TranslationStationService {
  TRANSLATION_STATION_URL: string = "http://localhost:8888/api/";
  constructor(
    private http: HttpClient
  ) { }


  getLanguage(language:string): Observable<any> {
    return this.http.get(`${this.TRANSLATION_STATION_URL}translations?lang=${language}`);
  }

  getUnverifiedLanguage(language:string): Observable<any> {
    return this.http.get(`${this.TRANSLATION_STATION_URL}translations/unverified?lang=${language}`);
  }

  sendNewTranslations(newTranslations:any) {
    return this.http.post(`${this.TRANSLATION_STATION_URL}translations/`, newTranslations);
  }

  sendVerifiedTranslation(translationObject:translationObj, language, key) {
    return this.http.patch(`${this.TRANSLATION_STATION_URL}translations/${language}/${key}`, translationObject);
  }
}

declare interface translationObj {
  value: string;
}
