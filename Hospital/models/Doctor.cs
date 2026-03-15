using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.models
{
    public class Doctor: User
    {
        public string LicenseNumber { get; set; }
        public DateTime HireDate { get; set; }
        public decimal HourRate { get; set; }

        public int SpecialtyId { get; set; }
        public Specialty Specialty { get; set; }
    }
}
