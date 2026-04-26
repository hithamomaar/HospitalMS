using Hospital.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Configurations
{
    public class SpecialtyConfiguration : IEntityTypeConfiguration<Specialty>
    {
        public void Configure(EntityTypeBuilder<Specialty> builder)
        {
            builder.Property<DateTime>("CreatedAt").HasDefaultValueSql("GETDATE()");
            builder.Property(s => s.Version).IsRowVersion();

            builder.HasData(
                new Specialty
                {
                    Id = 1,
                    Name = "Cardiology",
                    Image = "cardiology.png",
                    Description = "Diagnosis and treatment of heart diseases",
                    IsDeleted = false,
                    LastModified = new DateTime(2026, 01, 01)
                },
                new Specialty
                {
                    Id = 2,
                    Name = "Neurology",
                    Image = "neurology.png",
                    Description = "Brain, spinal cord, and nervous system care",
                    IsDeleted = false,
                    LastModified = new DateTime(2026, 01, 01)
                },
                new Specialty
                {
                    Id = 3,
                    Name = "Orthopedics",
                    Image = "orthopedics.png",
                    Description = "Bones, joints, and musculoskeletal treatment",
                    IsDeleted = false,
                    LastModified = new DateTime(2026, 01, 01)
                });
        }
    }
}
