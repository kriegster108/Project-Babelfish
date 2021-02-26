using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TranslationStation.Models
{
    public class GetTranslationsOutput
    {
        public GetTranslationsOutput (string key, string value)
        {
            this.key = key;
            this.value = value;
        }
        string key { get; set; }
        string value { get; set; }
    }
}
