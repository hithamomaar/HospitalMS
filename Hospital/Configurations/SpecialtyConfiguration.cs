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
        }
    }
}
