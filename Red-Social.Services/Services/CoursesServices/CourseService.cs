using Red_Social.Model.Models.Courses;
using Red_Social.Repository;
using Red_Social.Services.Services.SelectionCoursesServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Red_Social.Services.Services.CoursesServices
{
    public interface ICourseService : IBaseService<Courses>
    {
    }
    public class CourseService: BaseService<Courses>, ICourseService
    {
        public CourseService(IBaseRepository<Courses> baseRepository) : base(baseRepository)
        {
        }


    }
}
