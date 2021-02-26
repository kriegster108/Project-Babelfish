using System;
using System.Collections.Generic;
using System.Text;
using TranslationStation.DataModel.Models.API;

namespace TranslationStation.Core.Interfaces
{
    public interface ITranslationService
    {
        List<TranslationDto> GetTranslations();

        List<TranslationDto> GetUnverifiedTranslations();

        void VerifyTranslation();

        void CreateTranslations();
    }
}
