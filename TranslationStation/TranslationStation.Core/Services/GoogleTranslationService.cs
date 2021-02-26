using Google.Cloud.Translation.V2;
using System;
using System.Collections.Generic;
using System.Text;
using TranslationStation.Core.Interfaces;
using TranslationStation.DataModel;
using TranslationStation.DataModel.Models.API;

namespace TranslationStation.Core.Services
{
    public class GoogleTranslationService : ITranslationService
    {
        private TranslationClient translationClient;
        private TranslationOps translationOps;
        private LanguageService languageService;

        public GoogleTranslationService(TranslationOps xlateOps, LanguageService langService)
        {
            translationOps = xlateOps;
            translationClient = TranslationClient.Create();
            languageService = langService;
        }

        public void CreateTranslations(Dictionary<string, string> values)
        {
            //foreach (string lang in languageService.SupportedLanguages)
            //{
            //    var translations = translationClient.TranslateText(value.Values, lang, "en");
            //}
            foreach (var value in values)
            {
                var translation = translationClient.TranslateText(value.Value, "es", "en");

                var xlateDTO = new TranslationDto
                {
                    EnglishWord = translation.OriginalText,
                    SpanishWord = translation.TranslatedText,
                    IsVerified = false,
                    Key = value.Key
                };
                translationOps.Upsert(xlateDTO);
            }
        }

        public void VerifyTranslation()
        {
            throw new NotImplementedException();
        }
    }
}
