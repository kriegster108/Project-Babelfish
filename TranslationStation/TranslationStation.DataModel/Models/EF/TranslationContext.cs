using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TranslationStation.DataModel.Models.EF
{
    public class TranslationContext : DbContext
    {
        public DbSet<Translation> Translations { get; set; }
    }

    public class Translation
    {
        [Key]
        public string Key { get; set; }
        public string EnglishWord { get; set; }
        public string SpanishWord { get; set; }
        public bool IsVerified { get; set; }
    }
}
