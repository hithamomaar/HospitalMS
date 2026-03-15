using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.models
{
    public class Patient: User
    {
        public BloodType BloodType { get; set; }

        public ICollection<ChronicCondition> ChronicConditions { get; set; }
        public ICollection<Allergy> Allergies { get; set; }
    }
}
