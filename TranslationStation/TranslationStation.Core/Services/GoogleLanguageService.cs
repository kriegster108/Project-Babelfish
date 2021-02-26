using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using TranslationStation.Core.Interfaces;
using TranslationStation.Core.Services;
using System;
using Google.Cloud.Translation.V2;
using System.Threading.Tasks;
using System.Linq;
using TranslationStation.DataModel.Models.API;

namespace TranslationStation.Core.Services
{
    public class GoogleLanguageService : LanguageService, ILanguageService
    {
        private TranslationClient translationClient;
        public GoogleLanguageService(IConfiguration config, TranslationClient client) : base(config)
        {
            translationClient = client;
        }

        public string GetValueOfLanguage(TranslationDto translation, string language)
        {
            switch (language)
            {
                case "en":
                    return translation.EnglishWord;
                case "es":
                    return translation.SpanishWord;
                default:
                    throw new Exception($"Failed to get value of langauge {language} from translation.");
            }
        }

        public bool VerifyLanguage(string language)
        {
            var googleLanguages = translationClient.ListLanguages();
            if (SupportedLanguages.Contains(language) && googleLanguages.Any(x => x.Code == language))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
