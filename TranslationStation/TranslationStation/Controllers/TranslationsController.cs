using Google.Cloud.Translation.V2;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TranslationStation.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class TranslationsController : ControllerBase
    {
        // GET api/translations
        /// <summary>
        /// Return translations for a specific language.
        /// Return all unverified translations for a specific language
        /// </summary>
        /// <param name="languageId">The language ID of the translation to get.</param>
        /// <param name="unverified">Whether or not to filter out verified translations.</param>
        /// <returns>A list of translations in the specified language.</returns>
        [HttpGet()]
        public IActionResult Translations([FromQuery] string lang)
        {
            return new ContentResult() 
            {
                Content = JsonSerializer.Serialize(new[] { new { key = "button1", value = "Hola" } }),
                ContentType = "application/json"
            };
        }

        [HttpGet("/unverified")]
        public IActionResult UnverifiedTranslations([FromQuery] string lang)
        {
            return new ContentResult()
            {
                Content = JsonSerializer.Serialize(new[] { new { key = "button1", enVal = "Hello", value = "Hola" } }),
                ContentType = "application/json"
            };
        }

        // PATCH /api/translations/{ISO639-1 language id}/{translation key}
        // Request to overwrite unverified translation with verified translation
        [HttpPatch("{languageId}/{translationKey}")]
        public IActionResult VerifyTranslation([FromBody] string value, string languageId, string translationKey)
        {
            return Ok(JsonSerializer.Serialize(new { value = value, languageId = languageId, translationKey = translationKey }));
        }

        // POST api/translations
        // Translate all english tags into all supported languages
        [HttpPost]
        public IActionResult CreateTranslations([FromBody] string value)
        {
            return Ok(JsonSerializer.Serialize(new { value = value }));
        }
    }
}
