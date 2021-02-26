using System;
using System.Collections.Generic;
using System.Text;

namespace TranslationStation.Core.Interfaces
{
    public interface ILanguageService
    {
        bool VerifyLanguage(string language);
    }
}
