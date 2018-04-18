namespace WebApi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBmodels : DbContext
    {
        public DBmodels()
            : base("name=DBmodels")
        {
        }

        public virtual DbSet<cursist> cursist { get; set; }
        public virtual DbSet<cursus> cursus { get; set; }
        public virtual DbSet<schip> schip { get; set; }
        public virtual DbSet<schipklasse> schipklasse { get; set; }
        public virtual DbSet<soortcursus> soortcursus { get; set; }
        public virtual DbSet<werknemers> werknemers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cursist>()
                .Property(e => e.EMAILADRES)
                .IsUnicode(false);

            modelBuilder.Entity<cursist>()
                .Property(e => e.ROEPNAAM)
                .IsUnicode(false);

            modelBuilder.Entity<cursist>()
                .Property(e => e.TUSSENVOEGSEL)
                .IsUnicode(false);

            modelBuilder.Entity<cursist>()
                .Property(e => e.ACHTERNAAM)
                .IsUnicode(false);

            modelBuilder.Entity<cursist>()
                .Property(e => e.ADRES)
                .IsUnicode(false);

            modelBuilder.Entity<cursist>()
                .Property(e => e.WOONPLAATS)
                .IsUnicode(false);

            modelBuilder.Entity<cursist>()
                .Property(e => e.TELEFOON)
                .IsUnicode(false);

            modelBuilder.Entity<cursus>()
                .HasMany(e => e.cursist)
                .WithMany(e => e.cursus)
                .Map(m => m.ToTable("cursistcursus").MapLeftKey("CURSUSCODE").MapRightKey("EMAILADRES"));

            modelBuilder.Entity<schip>()
                .Property(e => e.NAAM)
                .IsUnicode(false);

            modelBuilder.Entity<schipklasse>()
                .Property(e => e.NAAM)
                .IsUnicode(false);

            modelBuilder.Entity<schipklasse>()
                .HasMany(e => e.schip)
                .WithOptional(e => e.schipklasse)
                .HasForeignKey(e => e.KLASSE);

            modelBuilder.Entity<soortcursus>()
                .Property(e => e.CURSUSSOORT)
                .IsUnicode(false);

            modelBuilder.Entity<werknemers>()
                .Property(e => e.GEBRUIKERSNAAM)
                .IsUnicode(false);

            modelBuilder.Entity<werknemers>()
                .Property(e => e.WACHTWOORD)
                .IsUnicode(false);

            modelBuilder.Entity<werknemers>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<werknemers>()
                .Property(e => e.TELEFOON)
                .IsUnicode(false);
        }
    }
}
