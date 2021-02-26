using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TranslationStation.Models
{
    public class VerifyTranslationInput
    {
        public VerifyTranslationInput(string value)
        {
            this.value = value;
        }

        public string value { get; set; }
    }
}
