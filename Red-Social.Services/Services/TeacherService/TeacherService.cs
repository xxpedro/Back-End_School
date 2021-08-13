using Red_Social.Model.Models.Courses;
using Red_Social.Model.Models.Teachers;
using Red_Social.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Red_Social.Services.Services.TeacherService
{
    public interface ITeacherService:IBaseService<Teachers>
    {
        public Teachers GetByEnroll(string enroll);
    }
    public class TeacherService:BaseService<Teachers>, ITeacherService
    {
        public TeacherService(IBaseRepository<Teachers> baseRepository):base(baseRepository)
        { 
            
        }

        public Teachers GetByEnroll(string enroll)
        {
            var data = GetAll().Where(x => x.enrollment.Equals(enroll)).FirstOrDefault();
            return data;
        }
    }
}
