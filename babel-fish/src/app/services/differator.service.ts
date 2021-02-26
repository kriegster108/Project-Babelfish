import { Injectable } from '@angular/core';
import { TranslationStationService } from './translation-station.service';
import englishObj from '../../languages/english.json';
import { LanguageService } from './language.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DifferatorService {
  private translationStation: TranslationStationService;
  private langGang: LanguageService;

  constructor( translationStation: TranslationStationService, langGang: LanguageService) {
    this.translationStation = translationStation;
    this.langGang = langGang;
  }

  private postChanges(localObject, originObject): Observable<any> {
    return this.translationStation.sendNewTranslations(this.differator(localObject, originObject));
  }

  private differator(localObject: any, originObject: any): any {
      const differencesObj: any = {};
      // tslint:disable-next-line: forin
      for (const key in localObject) {
        if (!(key in originObject)) {
          differencesObj[key] = localObject[key];
        }
        if (localObject[key] !== originObject[key]) {
          differencesObj[key] = localObject[key];
        }
      }
      return differencesObj;
    }
    // possible lang strings are: 'en', 'es'
    public differentiateItBroSki(lang: string): Observable<any> {
      return new Observable((obs) => {
        this.langGang.getLanguageObject(lang).subscribe((langObj) => {
          obs.next(this.postChanges(englishObj, langObj));
          obs.complete();
        })
      });
    }
}
