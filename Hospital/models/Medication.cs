using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.models
{
    public class Medication : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GenericName { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    }
}
