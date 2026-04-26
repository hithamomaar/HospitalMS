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

            builder.HasData(
                new DoctorSchedule
                {
                    Id = 1,
                    DoctorId = 1,
                    StartTime = new DateTime(2026, 03, 20, 10, 00, 00),
                    EndTime = new DateTime(2026, 03, 20, 11, 00, 00),
                    IsBooked = true,
                    IsDeleted = false,
                    LastModified = new DateTime(2026, 01, 01)
                },
                new DoctorSchedule
                {
                    Id = 2,
                    DoctorId = 1,
                    StartTime = new DateTime(2026, 03, 20, 11, 00, 00),
                    EndTime = new DateTime(2026, 03, 20, 12, 00, 00),
                    IsBooked = false,
                    IsDeleted = false,
                    LastModified = new DateTime(2026, 01, 01)
                },
                new DoctorSchedule
                {
                    Id = 3,
                    DoctorId = 2,
                    StartTime = new DateTime(2026, 03, 21, 09, 00, 00),
                    EndTime = new DateTime(2026, 03, 21, 10, 00, 00),
                    IsBooked = false,
                    IsDeleted = false,
                    LastModified = new DateTime(2026, 01, 01)
                });
        }

    }
}
