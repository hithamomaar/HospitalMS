using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.models
{
    public class Appointment : BaseModel
    {
        public int Id { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int ScheduleId { get; set; }
        public DoctorSchedule Schedule { get; set; }
        public AppointmentStatus Status { get; set; }
        public string CancellationReason { get; set; }
    }
}
