using System;
using System.Collections.Generic;
using System.Text;

namespace Red_Social.Model.Models
{
    public class BaseModel
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        
    }
}
