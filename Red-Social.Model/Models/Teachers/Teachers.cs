using System;
using System.Collections.Generic;
using System.Text;

namespace Red_Social.Model.Models.Teachers
{
    public class Teachers:BaseModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string enrollment { get; set; }
        public virtual ICollection<MatterAssignment.MatterAssignment> matterSelections { get; set; }

    }
}
