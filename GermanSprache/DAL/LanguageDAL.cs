using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace GermanSprache.DAL
{
    public class LanguageDALContext : DbContext
    {
        public DbSet<LanguageDictionary> LanguageDictionary { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {

                optionsBuilder.UseSqlServer(@"Server=DESKTOP-N04RMD8\SQLEXPRESS;Database=GermanSpracheDB;Trusted_Connection=True;");

            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }

     


        //    protected override void OnModelCreating(ModelBuilder modelBuilder)
        //    {
        //        modelBuilder.Entity<LanguageDictionary>()
        //      .HasKey(c => c.Id);
        //        modelBuilder.Entity<LanguageDictionary>().Property(b => b.LastUpdated)
        //.ValueGeneratedOnAdd();

        //        modelBuilder.Entity<LanguageDictionary>().Property(b => b.English)
        //        .HasMaxLength(4000);
        //        modelBuilder.Entity<LanguageDictionary>().Property(b => b.German)
        //       .HasMaxLength(4000);
        //        modelBuilder.Entity<LanguageDictionary>().Property(b => b.Description)
        //       .HasMaxLength(4000);

        //    }


    }

    public class LanguageDictionary
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(4000)]
        public string English { get; set; }
        [Required]
        [MaxLength(4000)]
        public string German { get; set; }
        [MaxLength(4000)]
        public string Tamil { get; set; }
        public string Description { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastUpdated { get; set; }
    }


 
}
