using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductViewer.Models;

namespace ProductViewer.Data
{
    public class ApplicationDbContext : IdentityDbContext<Korisnik>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Proizvod> Proizvodi { get; set; }
        public DbSet<Aktivnost> Aktivnosti { get; set; }
        public DbSet<Izvjestaj> Izvjestaji { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<TipKategorije> TipKategorije{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Proizvod>().ToTable("Proizvod");
            modelBuilder.Entity<Aktivnost>().ToTable("Aktivnost");
            modelBuilder.Entity<Izvjestaj>().ToTable("Izvjestaj");
            modelBuilder.Entity<Korisnik>().ToTable("Korisnik");
            modelBuilder.Entity<TipKategorije>().ToTable("TipKategorije");

            // Definisanje odnosa i dodatnih svojstava za Korisnik
            modelBuilder.Entity<Korisnik>(b =>
            {
                b.Property(k => k.Ime).IsRequired().HasMaxLength(20);
            });

            // Navigacija Proizvod - Aktivnost
            modelBuilder.Entity<Aktivnost>()
                .HasOne(a => a.Proizvod)
                .WithMany() // Ako želiš kasnije `List<Aktivnost>` u Proizvod, zamijeni sa `.WithMany(p => p.Aktivnosti)`
                .HasForeignKey(a => a.ProizvodID)
                .OnDelete(DeleteBehavior.Cascade);

            // Navigacija Proizvod - Izvjestaj
            modelBuilder.Entity<Izvjestaj>()
                .HasOne(i => i.Proizvod)
                .WithMany()
                .HasForeignKey(i => i.ProizvodID)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
