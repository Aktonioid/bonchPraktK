using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_6_01.Domain;
using Microsoft.EntityFrameworkCore;
using WebAPI_6_01.Domain.Model;

namespace WebAPI_6_01.Infrastructure
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<GeoObjectType> GeoObjectTypes { get; set; }
        public DbSet<TypeSection> TypeSections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GeoObjectType>().HasKey(e => e.Code);
            modelBuilder.Entity<TypeSection>().HasKey(e => e.Code);
            modelBuilder.Entity<GeoObjectType>()
                .HasOne(g => g.TypeSection)
                .WithMany(ts => ts.GeoObjectTypes)
                .HasForeignKey(g => g.TypeSectionCode);
        }
    }
}
