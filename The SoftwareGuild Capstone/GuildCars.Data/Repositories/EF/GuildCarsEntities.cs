namespace GuildCars.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Models;

    public partial class GuildCarsEntities : DbContext
    {
        public GuildCarsEntities()
            : base("name=GuildCarsEntities")
        {
        }

        public virtual DbSet<BodyType> BodyTypes { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Make> Makes { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<PurchaseType> PurchaseTypes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Special> Specials { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>()
                .HasMany(e => e.Vehicles)
                .WithOptional(e => e.Color)
                .HasForeignKey(e => e.ExteriorColorID);

            modelBuilder.Entity<Color>()
                .HasMany(e => e.Vehicles1)
                .WithOptional(e => e.Color1)
                .HasForeignKey(e => e.InteriorColorID);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Model>()
                .HasMany(e => e.Vehicles)
                .WithOptional(e => e.Model)
                .HasForeignKey(e => e.ModelID);

            modelBuilder.Entity<Sale>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Sale>()
                .Property(e => e.PurchasePrice)
                .HasPrecision(8, 2);

            modelBuilder.Entity<State>()
                .Property(e => e.StateAbbreviation)
                .IsUnicode(false);

            modelBuilder.Entity<Vehicle>()
                .Property(e => e.SalesPrice)
                .HasPrecision(8, 2);

            //modelBuilder.Entity<Vehicle>()
            //    .Property(e => e.MSRP)
            //    .HasPrecision(8, 2);
        }
    }
}
