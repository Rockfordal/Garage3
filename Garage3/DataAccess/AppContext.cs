using Garage3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Garage3.DataAccess
{
    public class AppContext : DbContext
    {
        public AppContext() : base("DefaultConnection") { }

        public virtual DbSet<VehicleType>   VehicleTypes { get; set; }
        public virtual DbSet<Vehicle>       Vehicles     { get; set; }
        public virtual DbSet<Person>        People       { get; set; }
        public virtual DbSet<Owner>         Owners       { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VehicleType>()
                .Property(t => t.Type)
                .IsRequired()
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_Type", 1) { IsUnique = true }));

            modelBuilder.Entity<Person>()
                .Property(t => t.SSN)
                .IsRequired()
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_SSN", 1) { IsUnique = true }));

            modelBuilder.Entity<Vehicle>()
                .Property(t => t.RegNr)
                .IsRequired()
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_RegNr", 1) { IsUnique = true }));
        }
    }
}