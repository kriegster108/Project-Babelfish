using Google.Cloud.Translation.V2;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TranslationStation.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TranslationStation.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class TranslationsController : ControllerBase
    {
        private readonly ITranslationService _translationService;
        public TranslationsController(ITranslationService translationService)
        {
            _translationService = translationService;
        }

        // GET api/translations
        // Return translations for a specific language
        [HttpGet("{languageId}")]
        public string Translations(string languageId)
        {
            var translations = _translationService.GetTranslations(languageId);
            return "value";
        }

        // GET api/translations/unverified/{ISO639-1 language id}
        // Return translations for a specific language
        [Route("unverified")]
        [HttpGet("{languageId}")]
        public string UnverifiedTranslation(string languageId)
        {
            var translations = _translationService.GetUnverifiedTranslations(languageId);
            return "value";
        }

        // PATCH /api/translations/{ISO639-1 language id}/{translation key}
        // Request to overwrite unverified translation with verified translation
        [HttpPatch("{languageId}/{translationKey}")]
        public string VerifyTranslation([FromBody] string value, string languageId, string translationKey)
        {
            var translations = _translationService.VerifyTranslation(languageId);
            return "value";
        }

        // POST api/translations
        // Translate all english tags into all supported languages
        [HttpPost]
        public void Post([FromBody] string value)
        {
            var translations = _translationService.Translate(value);
        }
    }
}
