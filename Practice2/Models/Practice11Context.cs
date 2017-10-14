using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Practice2.Models
{
    public partial class Practice11Context : DbContext
    {
        public virtual DbSet<Person> Person { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-DARFT2D\MSSQLSERVER01;Database=Practice11;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.PersonId).HasColumnName("Person_id");

                entity.Property(e => e.PersonDob)
                    .HasColumnName("Person_DOB")
                    .HasMaxLength(50);

                entity.Property(e => e.PersonName)
                    .HasColumnName("Person_name")
                    .HasMaxLength(50);

                entity.Property(e => e.PersonSkill)
                    .HasColumnName("Person_skill")
                    .HasMaxLength(50);
            });
        }
    }
}