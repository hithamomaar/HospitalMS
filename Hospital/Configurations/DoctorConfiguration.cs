using Hospital.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasOne(d => d.Specialty)
                   .WithMany(s => s.Doctors)
                   .HasForeignKey(d => d.SpecialtyId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(d => d.LicenseNumber).IsUnique();

            builder.HasData(
                new Doctor
                {
                    Id = 1,
                    FullName = "Dr. Ahmed Samir",
                    NationalId = "29801010100001",
                    DateOfBirth = new DateTime(1980, 01, 01),
                    Gender = Gender.Male,
                    ProfileImage = "doctor1.jpg",
                    LicenseNumber = "LIC-1001",
                    HireDate = new DateTime(2021, 03, 01),
                    HourRate = 700,
                    SpecialtyId = 1,
                    IsDeleted = false,
                    LastModified = new DateTime(2026, 01, 01)
                },
                new Doctor
                {
                    Id = 2,
                    FullName = "Dr. Sara Nabil",
                    NationalId = "29202020200002",
                    DateOfBirth = new DateTime(1985, 02, 02),
                    Gender = Gender.Female,
                    ProfileImage = "doctor2.jpg",
                    LicenseNumber = "LIC-1002",
                    HireDate = new DateTime(2022, 06, 15),
                    HourRate = 800,
                    SpecialtyId = 2,
                    IsDeleted = false,
                    LastModified = new DateTime(2026, 01, 01)
                });


        }
    }
}
