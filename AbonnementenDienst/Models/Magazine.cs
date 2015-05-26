using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Data.Entity;

namespace AbonnementenDienst.Models
{
    /// <summary>
    /// This class represents a magazine.
    /// </summary>
    [MetadataType(typeof(MagazineMetaData))]
    public partial class Magazine
    {
        public int ID { get; set; }

        public string name { get; set; }

        public int publisherID {get; set; }
        public virtual Publisher publisher { get; set; }

        public int categoryID {get; set; }
        public virtual Category category { get; set; }

        public decimal price { get; set; } 
    }

    /// <summary>
    /// Metadata about the Magazine class
    /// </summary>
    [Table("Magazine")]
    public class MagazineMetaData
    {
        [Key]
        [Column("MagazineId", Order = 1)]
        public int ID { get; set; }

        [Column("MagazineName")]
        [Required]
        [Display(Name = "Naam")]
        public string name { get; set; }

        [Required]
        [Display(Name = "Uitgever")]
        public int publisherID {get; set; }

        [ForeignKey("publisherID")]
        [Display(Name = "Uitgever")]
        public virtual Publisher publisher { get; set; }

        [Required]
        [Display(Name = "Categorie")]
        public int categoryID {get; set; }

        [ForeignKey("categoryID")]
        [Display(Name = "Categorie")]
        public virtual Category category { get; set; }

        [Column("MagazinePrice")]
        [Range(typeof(Decimal), "0", "99", ErrorMessage = "{0} moet een prijs zijn tussen {1} and {2}.")]
        public decimal price { get; set; } 
    }

    /// <summary>
    /// Database context for the magazine
    /// </summary>
    public class MagazineContext : DbContext
    {
        public DbSet<Magazine> Magazines { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Category> Categories { get; set; } 

        public MagazineContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MagazineContext, Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    public class MagazineDbInitializer : CreateDatabaseIfNotExists<MagazineContext>
    {
        protected override void Seed(MagazineContext context)
        {
            // Add one demo magazine entry 
            context.Magazines.Add(new Magazine
            {
                ID = 1,
                name = "PC Magazine",
                price = 2.50M,
                publisher = new Publisher { ID = 1, name = "Minoc Media Services" },
                category = new Category {  ID = 1, name = "Computer" }
            });

            base.Seed(context);
        }
    }
}