using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using TranslationStation.Core.Interfaces;
using TranslationStation.Core.Services;
using System;
using Google.Cloud.Translation.V2;
using System.Threading.Tasks;
using System.Linq;

namespace TranslationStation.Core.Services
{
    public class GoogleLanguageService : LanguageService, ILanguageService
    {
        private TranslationClient translationClient;
        public GoogleLanguageService(IConfiguration config, TranslationClient client) : base(config)
        {
            translationClient = client;
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
