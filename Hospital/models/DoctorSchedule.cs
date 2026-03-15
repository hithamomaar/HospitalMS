using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.models
{
    public class DoctorSchedule : BaseModel
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsBooked { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public Appointment Appointment { get; set; }
    }
}
