using Hospital.Configurations;
using Hospital.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Services
{
    public class AppointmentService
    {
        private readonly HospitalContext context;

        public AppointmentService(HospitalContext _context)
        {
            context = _context;
        }

        public void CancelAppointment(int appointmentId, string reason)
        {
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var appointment = context.Appointments.Include(a => a.Schedule)
                                         .FirstOrDefault(a => a.Id == appointmentId);
                if (appointment != null)
                {
                    appointment.Status = AppointmentStatus.Canceled;
                    appointment.CancellationReason = reason;
                    appointment.Schedule.IsBooked = false;

                    context.SaveChanges();
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw;
            }
        }
        private static readonly Func<HospitalContext, int, IEnumerable<DoctorSchedule>> GetAvailableSchedules =
              EF.CompileQuery((HospitalContext db, int doc_id) =>
                  db.DoctorSchedules
                    .AsNoTracking() 
                    .Where(s => s.DoctorId == doc_id && !s.IsBooked));
        public IEnumerable<DoctorSchedule> GetDoctorAvailableSchedules(int doctorId)
        {
            return GetAvailableSchedules(context, doctorId).ToList();
        }
    }
}
