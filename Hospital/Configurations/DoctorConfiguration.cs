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


        }
    }
}
