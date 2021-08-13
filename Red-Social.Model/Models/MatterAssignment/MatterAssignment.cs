using System;
using System.Collections.Generic;
using System.Text;

namespace Red_Social.Model.Models.MatterAssignment
{
    public class MatterAssignment:BaseModel
    {
        public int TeachersId { get; set; }
        public int CoursesId { get; set; }
        public virtual Teachers.Teachers Teachers { get; set; }
        public virtual Courses.Courses Courses { get; set; }

    }
}
