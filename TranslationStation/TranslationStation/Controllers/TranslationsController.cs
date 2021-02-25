using Google.Cloud.Translation.V2;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TranslationStation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslationsController : ControllerBase
    {
        // GET api/translations
        // Return translations for a specific language
        [HttpGet("{languageId}")]
        public string Translations(string languageId)
        {
            return "value";
        }

        // GET api/translations/unverified/{ISO639-1 language id}
        // Return translations for a specific language
        [Route("unverified")]
        [HttpGet("{languageId}")]
        public string UnverifiedTranslation(string languageId)
        {
            return "value";
        }

        // PATCH /api/translations/{ISO639-1 language id}/{translation key}
        // Request to overwrite unverified translation with verified translation
        [HttpPatch("{languageId}/{translationKey}")]
        public string VerifyTranslation([FromBody] string value, string languageId, string translationKey)
        {
            return "value";
        }

        // POST api/translations
        // Translate all english tags into all supported languages
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
