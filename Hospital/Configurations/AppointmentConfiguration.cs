using Hospital.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Configurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasOne(a => a.Schedule)
                   .WithOne(ds => ds.Appointment)
                   .HasForeignKey<Appointment>(a => a.ScheduleId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Patient)
                   .WithMany()
                   .HasForeignKey(a => a.PatientId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property<DateTime>("CreatedAt").HasDefaultValueSql("GETDATE()");
            builder.Property(a => a.Version).IsRowVersion();

            builder.HasData(
                new Appointment
                {
                    Id = 1,
                    PatientId = 3,
                    ScheduleId = 1,
                    Status = AppointmentStatus.Confirmed,
                    CancellationReason = string.Empty,
                    IsDeleted = false,
                    LastModified = new DateTime(2026, 01, 01)
                });
        }
    }
}
