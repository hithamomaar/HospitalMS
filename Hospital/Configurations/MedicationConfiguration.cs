using Hospital.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Configurations
{
    public class MedicationConfiguration : IEntityTypeConfiguration<Medication>
    {
        public void Configure(EntityTypeBuilder<Medication> builder)
        {
            builder.Property<DateTime>("CreatedAt").HasDefaultValueSql("GETDATE()");
            builder.Property(m => m.Version).IsRowVersion();

            builder.HasData(
                new Medication
                {
                    Id = 1,
                    Name = "Panadol",
                    GenericName = "Paracetamol",
                    IsDeleted = false,
                    LastModified = new DateTime(2026, 01, 01)
                },
                new Medication
                {
                    Id = 2,
                    Name = "Augmentin",
                    GenericName = "Amoxicillin/Clavulanate",
                    IsDeleted = false,
                    LastModified = new DateTime(2026, 01, 01)
                },
                new Medication
                {
                    Id = 3,
                    Name = "Aspirin",
                    GenericName = "Acetylsalicylic Acid",
                    IsDeleted = false,
                    LastModified = new DateTime(2026, 01, 01)
                });
        }
    }
}
