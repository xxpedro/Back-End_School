using System;
using System.Collections.Generic;
using System.Text;

namespace Red_Social.Model.Models.Courses
{
    public class Courses:BaseModel
    {
        public string Name { get; set; }
        public string Day { get; set; }
        public string InitialTime { get; set; }
        public string FinalTime { get; set; }
        public int quota { get; set; }
        public int quotaTeachers { get; set; }
        public int NumberOfStudents { get; set; }
        public int NumberOfTeachers { get; set; }

        public virtual ICollection<MatterAssignment.MatterAssignment> MatterAssignments { get; set; }

    }
}
