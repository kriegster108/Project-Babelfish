using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TranslationStation.DataModel.Models.EF
{
    public class TranslationContext : DbContext
    {
        public DbSet<Translation> Translations { get; set; }
        public TranslationContext(DbContextOptions<TranslationContext> options): base(options)
        {
        }
    }

    public class Translation
    {
        [Key]
        // ReSharper disable once UnusedMember.Global
        public string Key { get; set; }
        public string EnglishWord { get; set; }
        public string SpanishWord { get; set; }
        public bool IsVerified { get; set; }
    }
}
