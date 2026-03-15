using Hospital.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Configurations
{
    public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(p => new { p.AppointmentId, p.MedicationId });

            builder.HasOne(p => p.Appointment)
                   .WithMany(a => a.Prescriptions)
                   .HasForeignKey(p => p.AppointmentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Medication)
                   .WithMany(m => m.Prescriptions)
                   .HasForeignKey(p => p.MedicationId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property<DateTime>("CreatedAt").HasDefaultValueSql("GETDATE()");
            builder.Property(p => p.Version).IsRowVersion();
        }
    }
}
