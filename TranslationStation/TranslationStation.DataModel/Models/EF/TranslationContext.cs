using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace TranslationStation.DataModel.Models.EF
{
    public class TranslationContext : DbContext
    {
        public DbSet<Translation> Translations { get; set; }
        public TranslationContext(DbContextOptions<TranslationContext> options): base(options)
        {
            // try
            // {
            //     var databaseCreator = base.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            //     databaseCreator.CreateTables();
            // }
            // catch (Npgsql.NpgsqlException)
            // {
            //     //A SqlException will be thrown if tables already exist. So simply ignore it.
            // }
            // catch (Exception)
            // {
            //     // failsafe
            // }
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
