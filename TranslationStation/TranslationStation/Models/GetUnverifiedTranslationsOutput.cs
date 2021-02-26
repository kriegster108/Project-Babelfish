using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TranslationStation.Models
{
    public class GetUnverifiedTranslationsOutput
    {
        public GetUnverifiedTranslationsOutput(string key, string enVal, string value)
        {
            this.key = key;
            this.enVal = enVal;
            this.value = value;
        }

        public string key { get; set; }
        public string enVal { get; set; }
        public string value { get; set; }
    }
}
