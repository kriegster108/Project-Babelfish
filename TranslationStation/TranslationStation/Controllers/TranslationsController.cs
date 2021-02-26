using Google.Cloud.Translation.V2;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using TranslationStation.Core.Interfaces;
using TranslationStation.Models;
using TranslationStation.DataModel;
using TranslationStation.DataModel.Models.API;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TranslationStation.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class TranslationsController : ControllerBase
    {
        private readonly ITranslationService translationService;
        private readonly ILanguageService languageService;
        private readonly ITranslationOps translationRepository;

        public TranslationsController(ITranslationService translation, ILanguageService language, ITranslationOps translationOps)
        {
            translationService = translation;
            languageService = language;
            translationRepository = translationOps;
        }

        // GET api/translations
        /// <summary>
        /// Return translations for a specific language.
        /// Return all unverified translations for a specific language
        /// </summary>
        /// <param name="languageId">The language ID of the translation to get.</param>
        /// <param name="unverified">Whether or not to filter out verified translations.</param>
        /// <returns>A list of translations in the specified language.</returns>
        [HttpGet()]
        public async Task<IActionResult> Translations([FromQuery] string lang)
        {
            var translations = await translationRepository.GetAllAsync();
            var returnVal = new List<GetTranslationsOutput>();
            foreach (var translation in translations)
            {
                returnVal.Add(new GetTranslationsOutput(translation.Key, languageService.GetValueOfLanguage(translation, lang)));
            }
            return new ContentResult() 
            {
                Content = JsonSerializer.Serialize(returnVal),
                ContentType = "application/json"
            };
        }

        [HttpGet("/unverified")]
        public async Task<IActionResult> UnverifiedTranslations([FromQuery] string lang)
        {
            var translations = await translationRepository.GetAllAsync();
            var returnVal = new List<GetUnverifiedTranslationsOutput>();
            foreach (var translation in translations.Where(x => x.IsVerified == false))
            {
                returnVal.Add(new GetUnverifiedTranslationsOutput(translation.Key, translation.EnglishWord, languageService.GetValueOfLanguage(translation, lang)));
            }
            return new ContentResult()
            {
                Content = JsonSerializer.Serialize(returnVal),
                ContentType = "application/json"
            };
        }

        // PATCH /api/translations/{ISO639-1 language id}/{translation key}
        // Request to overwrite unverified translation with verified translation
        [HttpPatch("{languageId}/{translationKey}")]
        public async Task<IActionResult> VerifyTranslation([FromBody] VerifyTranslationInput value, string languageId, string translationKey)
        {
            var upsertObject = new TranslationDto();
            upsertObject.Key = translationKey;
            upsertObject.SpanishWord = value.value;
            upsertObject.IsVerified = true;
            await translationRepository.UpsertAsync(upsertObject);
            return Ok(JsonSerializer.Serialize(new { value = value.value, languageId = languageId, translationKey = translationKey }));
        }

        // POST api/translations
        // Translate all english tags into all supported languages
        [HttpPost]
        public async Task<IActionResult> CreateTranslations([FromBody] Dictionary<string, string> values)
        {
            var translations = translationService.CreateTranslations(values);
            await translationRepository.UpsertAllAsync(translations);
            return Ok();
        }
    }
}
