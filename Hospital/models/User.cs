using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.models
{
    public abstract class User : BaseModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string NationalId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string ProfileImage { get; set; }
    }
}
