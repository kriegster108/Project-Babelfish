using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace TranslationStation.Core.Services
{
    public abstract class LanguageService
    {
        protected readonly IConfiguration configuration;
        public readonly List<string> SupportedLanguages;
        public LanguageService(IConfiguration config)
        {
            configuration = config;
            SupportedLanguages = configuration.GetValue<List<string>>("SupportedLanguages");
            if (SupportedLanguages.Count == 0)
            {
                throw new Exception("Failed to retreive supported languages from SupportedLanguages environment variable.");
            };
        }
    }
}
