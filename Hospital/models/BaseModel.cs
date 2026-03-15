using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.models
{
    public abstract class BaseModel
    {
        public bool IsDeleted { get; set; }
        public DateTime LastModified { get; set; }
        public byte[] Version { get; set; }
    }
}
