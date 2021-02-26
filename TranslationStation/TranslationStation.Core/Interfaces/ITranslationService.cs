using System;
using System.Collections.Generic;
using System.Text;
using TranslationStation.DataModel.Models.API;

namespace TranslationStation.Core.Interfaces
{
    public interface ITranslationService
    {
        IEnumerable<TranslationDto> CreateTranslations(Dictionary<string, string> values);
    }
}
