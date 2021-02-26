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

        public GoogleTranslationService()
        {
            translationClient = TranslationClient.Create();
        }

        public IEnumerable<TranslationDto> CreateTranslations(Dictionary<string, string> values)
        {
            var returnValue = new List<TranslationDto>();
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
                returnValue.Add(xlateDTO);
            }
            return returnValue;
        }
    }
}
