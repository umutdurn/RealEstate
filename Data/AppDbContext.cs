using Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { 

        }

        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<Features> Features { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var featuresBuilder = modelBuilder.Entity<Features>();
            var realEstateBuilder = modelBuilder.Entity<RealEstate>();

            var features1 = new Features { Id = 1, Title = "Satılık" };
            var features2 = new Features { Id = 2, Title = "Kiralık" };
            var features3 = new Features { Id = 3, Title = "Günlük" };

            var features4 = new Features { Id = 4, Title = "Eşyalı" };
            var features5 = new Features { Id = 5, Title = "Eşyasız" };

            var features6 = new Features { Id = 6, Title = "1+0" };
            var features7 = new Features { Id = 7, Title = "1+1" };
            var features8 = new Features { Id = 8, Title = "2+1" };
            var features9 = new Features { Id = 9, Title = "3+1" };
            var features10 = new Features { Id = 10, Title = "3+2" };
            var features11 = new Features { Id = 11, Title = "4+2" };

            var realEstate1 = new RealEstate
            {
                Id = 1,
                Title = "Avcılar Kiralık",
                BuildingYear = 2005,
                Floor = 3,
                M2 = 100,
                Price = 10,
                Image = "https://picsum.photos/300/500"
            };

            var realEstate2 = new RealEstate
            {
                Id = 2,
                Title = "Berlikdüzü Kiralık",
                BuildingYear = 2015,
                Floor = 1,
                M2 = 75,
                Price = 15,
                Image = "https://picsum.photos/500/300"
            };

            var realEstate3 = new RealEstate
            {
                Id = 3,
                Title = "Beşiktaş Kiralık",
                BuildingYear = 2022,
                Floor = 10,
                M2 = 150,
                Price = 20,
                Image = "https://picsum.photos/500/300"
            };

            var realEstate4 = new RealEstate
            {
                Id = 4,
                Title = "Esenyurt Satılık",
                BuildingYear = 2022,
                Floor = 2,
                M2 = 70,
                Price = 5,
                Image = "https://picsum.photos/500/300"
            };

            var realEstate5 = new RealEstate
            {
                Id = 5,
                Title = "Bağcılar Satılık",
                BuildingYear = 1999,
                Floor = 1,
                M2 = 90,
                Price = 7,
                Image = "https://picsum.photos/500/300"
            };

            featuresBuilder.HasData(features1, features2, features3, features4, features5, features6, features7, features8, features9, features10, features11);

            realEstateBuilder.HasData(realEstate1, realEstate2, realEstate3, realEstate4, realEstate5);

            modelBuilder.Entity<RealEstate>()
                        .HasMany(p => p.Features)
                        .WithMany(p => p.RealEstate)
                        .UsingEntity(j => j.HasData(
                            new { FeaturesId = features1.Id, RealEstateId = realEstate1.Id },
                            new { FeaturesId = features4.Id, RealEstateId = realEstate1.Id },
                            new { FeaturesId = features6.Id, RealEstateId = realEstate1.Id },

                            new { FeaturesId = features2.Id, RealEstateId = realEstate2.Id },
                            new { FeaturesId = features5.Id, RealEstateId = realEstate2.Id },
                            new { FeaturesId = features7.Id, RealEstateId = realEstate2.Id },

                            new { FeaturesId = features1.Id, RealEstateId = realEstate3.Id },
                            new { FeaturesId = features5.Id, RealEstateId = realEstate3.Id },
                            new { FeaturesId = features9.Id, RealEstateId = realEstate3.Id },

                            new { FeaturesId = features3.Id, RealEstateId = realEstate4.Id },
                            new { FeaturesId = features4.Id, RealEstateId = realEstate4.Id },
                            new { FeaturesId = features10.Id, RealEstateId = realEstate4.Id },

                            new { FeaturesId = features2.Id, RealEstateId = realEstate5.Id },
                            new { FeaturesId = features5.Id, RealEstateId = realEstate5.Id },
                            new { FeaturesId = features8.Id, RealEstateId = realEstate5.Id }
                        ));

            base.OnModelCreating(modelBuilder);
        }
    }
}
