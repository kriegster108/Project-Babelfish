using System;
using System.Collections.Generic;
using System.Text;
using TranslationStation.DataModel.Models.API;

namespace TranslationStation.Core.Interfaces
{
    public interface ILanguageService
    {
        bool VerifyLanguage(string language);
        string GetValueOfLanguage(TranslationDto translation, string language);
    }
}
