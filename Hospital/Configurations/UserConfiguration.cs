using Hospital.models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.UseTptMappingStrategy();
            builder.HasIndex(u => u.NationalId).IsUnique();
            builder.HasCheckConstraint("CK_User_DOB", "DateOfBirth < GETDATE()");
            builder.Property<DateTime>("CreatedAt").HasDefaultValueSql("GETDATE()");
            builder.Property(u => u.Version).IsRowVersion();
        }
    }
}
