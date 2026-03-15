using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.models
{
    public class Prescription : BaseModel
    {
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        public int MedicationId { get; set; }
        public Medication Medication { get; set; }

        public string Dosage { get; set; }
        public string Frequency { get; set; }
    }
}
