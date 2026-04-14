using Hospital.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Configurations
{
    public class HospitalContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=HospitalMSDB;Trusted_Connection=True;TrustServerCertificate=True;");
        //}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new PatientConfiguration());
            builder.ApplyConfiguration(new SpecialtyConfiguration());
            builder.ApplyConfiguration(new DoctorConfiguration());
            builder.ApplyConfiguration(new AppointmentConfiguration());
            builder.ApplyConfiguration(new DoctorScheduleConfiguration());
            builder.ApplyConfiguration(new MedicationConfiguration());
            builder.ApplyConfiguration(new PrescriptionConfiguration());

            builder.Entity<User>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<Specialty>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<Appointment>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<DoctorSchedule>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<Medication>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<Prescription>().HasQueryFilter(x => !x.IsDeleted);

            base.OnModelCreating(builder);
        }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<BaseModel>())
            {
                if (entry.State == EntityState.Unchanged) continue;
                if (entry.State == EntityState.Detached) continue;

                entry.Entity.LastModified = DateTime.UtcNow;
                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.Entity.IsDeleted = true;
                }
            }
            return base.SaveChanges();
        }
    }
}
