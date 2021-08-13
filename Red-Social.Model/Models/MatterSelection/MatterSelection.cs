using System;
using System.Collections.Generic;
using System.Text;

namespace Red_Social.Model.Models.MatterSelection
{
    public class MatterSelection:BaseModel
    {
        public int StudentId { get; set; }
        public int CoursesId { get; set; }
        public virtual Students.Students Students { get; set; }
        public virtual Courses.Courses Courses { get; set; }
    }
}
