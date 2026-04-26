using Hospital.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.OwnsMany(p => p.Allergies);

            builder.OwnsMany(p => p.ChronicConditions);

            builder.HasData(
                new Patient
                {
                    Id = 3,
                    FullName = "Hassan Omar",
                    NationalId = "30103030300003",
                    DateOfBirth = new DateTime(2001, 03, 03),
                    Gender = Gender.Male,
                    ProfileImage = "patient1.jpg",
                    BloodType = BloodType.A,
                    IsDeleted = false,
                    LastModified = new DateTime(2026, 01, 01)
                },
                new Patient
                {
                    Id = 4,
                    FullName = "Mona Adel",
                    NationalId = "30204040400004",
                    DateOfBirth = new DateTime(2002, 04, 04),
                    Gender = Gender.Female,
                    ProfileImage = "patient2.jpg",
                    BloodType = BloodType.O,
                    IsDeleted = false,
                    LastModified = new DateTime(2026, 01, 01)
                });
        }
    }
}
