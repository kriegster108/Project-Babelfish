import { Injectable } from '@angular/core';
import { TranslationStationService } from './translation-station.service';
import * as englishObj from '../../languages/english.json';
import { LanguageService } from './language.service';

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

  private postChanges(localObject, originObject): void {
    this.translationStation.sendNewTranslations(this.differator(localObject, originObject));
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
    public differentiateItBroSki(lang: string): void {
      this.langGang.getLanguageObject(lang).subscribe((langObj) => {
        this.postChanges(englishObj, langObj);
      });
    }
}
