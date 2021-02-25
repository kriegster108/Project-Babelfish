﻿using Google.Cloud.Translation.V2;
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
        // Return translations for a specific language
        [HttpGet("{languageId}")]
        public IActionResult Translations(string languageId)
        {
            return new ContentResult() 
            {
                Content = JsonSerializer.Serialize(new[] { new { key = "button1", value = "Hello" } }),
                ContentType = "application/json"
            };
        }

        // GET api/translations/unverified/{ISO639-1 language id}
        // Return translations for a specific language
        [Route("unverified")]
        [HttpGet("{languageId}")]
        public IActionResult UnverifiedTranslation(string languageId)
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
            return Ok();
        }

        // POST api/translations
        // Translate all english tags into all supported languages
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Ok();
        }
    }
}
