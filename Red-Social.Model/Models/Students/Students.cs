using System;
using System.Collections.Generic;
using System.Text;

namespace Red_Social.Model.Models.Students
{
    public class Students:BaseModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Enrollment { get; set; }
        public virtual ICollection<MatterSelection.MatterSelection> MatterSelections { get; set; }
    }
}
