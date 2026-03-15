using Hospital.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Configurations
{
    public class DoctorScheduleConfiguration : IEntityTypeConfiguration<DoctorSchedule>
    {
        public void Configure(EntityTypeBuilder<DoctorSchedule> builder)
        {
            builder.HasOne(ds => ds.Doctor)
                   .WithMany()
                   .HasForeignKey(ds => ds.DoctorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasCheckConstraint("CK_Schedule_Time", "EndTime > StartTime");

            builder.Property<DateTime>("CreatedAt").HasDefaultValueSql("GETDATE()");
            builder.Property(ds => ds.Version).IsRowVersion();
        }

    }
}
