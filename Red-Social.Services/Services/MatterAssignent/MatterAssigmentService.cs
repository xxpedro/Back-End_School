using Red_Social.Model.Models;
using Red_Social.Model.Models.Courses;
using Red_Social.Model.Models.MatterAssignment;
using Red_Social.Repository;
using Red_Social.Services.Services.CoursesServices;
using Red_Social.Services.Services.TeacherService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Red_Social.Services.Services.MatterAssignent
{
    public interface IMatterAssigmentService : IBaseService<MatterAssignment>
    {
        public ErrorControl AddSelection(MatterAssignment Model);
        public object getSelectionCourses(int studentId);
        public void updateSelection(MatterAssignment Model);

    }
    public class MatterAssigmentService : BaseService<MatterAssignment>, IMatterAssigmentService
    {
        private readonly ICourseService _courseService;
        private readonly ITeacherService _studentServices;

        public MatterAssigmentService(IBaseRepository<MatterAssignment> baseRepository, ICourseService courseService, ITeacherService studentServices) : base(baseRepository)
        {
            _courseService = courseService;
            _studentServices = studentServices;
        }

        public void updateSelection(MatterAssignment Model)
        {
            Courses getMatterName = _courseService.GetAll().Where(x => x.ID.Equals(Model.CoursesId)).First();
            var getSelecionId = GetAll().Where(x => x.TeachersId.Equals(Model.TeachersId) && x.CoursesId.Equals(Model.CoursesId)).First();

            getMatterName.NumberOfTeachers = getMatterName.NumberOfTeachers - 1;
            _courseService.Update(getMatterName.ID, getMatterName);
            Delete(getSelecionId.ID);
        }


        public ErrorControl AddSelection(MatterAssignment Model)
        {
            Courses getMatterName = _courseService.GetAll().Where(x => x.ID.Equals(Model.CoursesId)).First();
            var validateIfMatterExistAlready = validateIfCourseIsAlreadySelected(Model);
            var validateQuota = validateIfQuotaIsFull(Model);

            if (!validateQuota) return new ErrorControl()
            {
                Message = "Esta materia tiene los cupos completos"
            };

            if (!validateIfMatterExistAlready) return new ErrorControl
            {
                Message = "Esta materia ya esta seleccionada"
            };
            if (getMatterName.Day == "Lunes")
            {
                var validateMonday = validateMondays(Model);
                if (!validateMonday) return new ErrorControl()
                {
                    Message = "Esta sobrepasando el limite de horas diarias los lunes"
                };
                getMatterName.NumberOfTeachers = getMatterName.NumberOfTeachers + 1;
                _courseService.Update(getMatterName.ID, getMatterName);
            }
            if (getMatterName.Day == "Martes")
            {
                var validateTuesday = ValidateTuesday(Model);
                if (!validateTuesday) return new ErrorControl()
                {
                    Message = "Esta sobrepasando el limite de horas diarias los Martes"
                };
                getMatterName.NumberOfTeachers = getMatterName.NumberOfTeachers + 1;
                _courseService.Update(getMatterName.ID, getMatterName);
            }
            if (getMatterName.Day == "Miercoles")
            {
                var validateTuesday = ValidateWednesday(Model);
                if (!validateTuesday) return new ErrorControl()
                {
                    Message = "Esta sobrepasando el limite de horas diarias los Miercoles"
                };

                getMatterName.NumberOfTeachers = getMatterName.NumberOfTeachers + 1;
                _courseService.Update(getMatterName.ID, getMatterName);
            }
            if (getMatterName.Day == "Jueves")
            {
                var validateTuesday = ValidateThursday(Model);
                if (!validateTuesday) return new ErrorControl()
                {
                    Message = "Esta sobrepasando el limite de horas diarias los Jueves"
                };
                getMatterName.NumberOfTeachers = getMatterName.NumberOfTeachers + 1;
                _courseService.Update(getMatterName.ID, getMatterName);
            }
            if (getMatterName.Day == "Viernes")
            {
                var validateTuesday = ValidateFriday(Model);
                if (!validateTuesday) return new ErrorControl()
                {
                    Message = "Esta sobrepasando el limite de horas diarias los Viernes"
                };
                getMatterName.NumberOfTeachers = getMatterName.NumberOfTeachers + 1;
                _courseService.Update(getMatterName.ID, getMatterName);
            }
            if (getMatterName.Day == "Sabados")
            {
                var validateTuesday = ValidateSaturday(Model);
                if (!validateTuesday) return new ErrorControl()
                {
                    Message = "Esta sobrepasando el limite de horas diarias los Sabados"
                };
                getMatterName.NumberOfTeachers = getMatterName.NumberOfTeachers + 1;
                _courseService.Update(getMatterName.ID, getMatterName);
            }


            Save(Model);

            return new ErrorControl()
            {
                Message = "Materia Seleccionada Con exito"
            };
        }

        public object getSelectionCourses(int studentId)
        {


            object validateMonday =
                (from selection in GetAll()
                 join courses in _courseService.GetAll() on selection.CoursesId equals courses.ID
                 join student in _studentServices.GetAll() on selection.TeachersId equals student.ID
                 where selection.TeachersId.Equals(studentId)
                 select new { courseId = courses.ID,id = selection.ID, courseName = courses.Name, Day = courses.Day, Inicial = courses.InitialTime, Final = courses.FinalTime }).ToList();

            return validateMonday;
        }

        public bool validateIfQuotaIsFull(MatterAssignment Model)
        {
            var courses = _courseService.GetAll().Where(x => x.ID.Equals(Model.CoursesId)).ToList();

            foreach (var item in courses)
            {
                if (item.quotaTeachers.Equals(item.NumberOfTeachers))
                {
                    return false;
                }
            }

            return true;
        }

        public bool validateMondays(MatterAssignment Model)
        {

            int horas = 0;
            var validateMonday =
                 (from selection in GetAll()
                  join courses in _courseService.GetAll() on selection.CoursesId equals courses.ID
                  where selection.TeachersId.Equals(Model.TeachersId) && courses.Day.Equals("Lunes")
                  select new { Inicial = courses.InitialTime, Final = courses.FinalTime }).ToList();

            Courses getMatterName = _courseService.GetAll().Where(x => x.ID.Equals(Model.CoursesId)).First();


            foreach (var mondayValidate in validateMonday)
            {
                int initialHour = Convert.ToInt32(mondayValidate.Inicial);
                int finalHour = Convert.ToInt32(mondayValidate.Final);

                int calculateMondayHours = (finalHour - initialHour);
                horas = horas + calculateMondayHours;

                if (horas >= 8) return false;
            }

            return true;
        }

        public bool validateIfCourseIsAlreadySelected(MatterAssignment Model)
        {
            var getCurrentCourse = _courseService.GetAll().Where(x => x.ID.Equals(Model.CoursesId)).ToList();
            var getAlCourses =
                 (from selection in GetAll()
                  join courses in _courseService.GetAll() on selection.CoursesId equals courses.ID
                  where selection.TeachersId.Equals(Model.TeachersId)
                  select new { Name = courses.Name, Inicial = courses.InitialTime, Final = courses.FinalTime }).ToList();

            foreach (var data in getCurrentCourse)
            {
                foreach (var item in getAlCourses)
                {
                    if (data.Name.Equals(item.Name))
                    {
                        return false;
                    }
                }

            }

            return true;
        }

        public bool ValidateTuesday(MatterAssignment Model)
        {
            var getCurrentMatter = _courseService.GetAll().Where(x => x.ID.Equals(Model.CoursesId)).First();
            int initialcurrent = Convert.ToInt32(getCurrentMatter.InitialTime);
            int finalciurrent = Convert.ToInt32(getCurrentMatter.FinalTime);
            int currentHour = (finalciurrent - initialcurrent);

            int horas = 0;
            var validateMonday =
                 (from selection in GetAll()
                  join courses in _courseService.GetAll() on selection.CoursesId equals courses.ID
                  where selection.TeachersId.Equals(Model.TeachersId) && courses.Day.Equals("Sabados")
                  select new { Inicial = courses.InitialTime, Final = courses.FinalTime }).ToList();

            foreach (var mondayValidate in validateMonday)
            {
                int initialHour = Convert.ToInt32(mondayValidate.Inicial);
                int finalHour = Convert.ToInt32(mondayValidate.Final);

                int calculateMondayHours = (finalHour - initialHour);
                horas = horas + (calculateMondayHours + currentHour);

                if (horas >= 8) return false;
                currentHour = 0;

            }

            return true;
        }

        public bool ValidateWednesday(MatterAssignment Model)
        {
            var getCurrentMatter = _courseService.GetAll().Where(x => x.ID.Equals(Model.CoursesId)).First();
            int initialcurrent = Convert.ToInt32(getCurrentMatter.InitialTime);
            int finalciurrent = Convert.ToInt32(getCurrentMatter.FinalTime);
            int currentHour = (finalciurrent - initialcurrent);

            int horas = 0;
            var validateWednesday =
                 (from selection in GetAll()
                  join courses in _courseService.GetAll() on selection.CoursesId equals courses.ID
                  where selection.TeachersId.Equals(Model.TeachersId) && courses.Day.Equals("Miercoles")
                  select new { Inicial = courses.InitialTime, Final = courses.FinalTime }).ToList();

            foreach (var mondayValidate in validateWednesday)
            {
                int initialHour = Convert.ToInt32(mondayValidate.Inicial);
                int finalHour = Convert.ToInt32(mondayValidate.Final);

                int calculateMondayHours = (finalHour - initialHour);
                horas = horas + (calculateMondayHours + currentHour);

                if (horas >= 8) return false;
                currentHour = 0;

            }

            return true;
        }

        public bool ValidateThursday(MatterAssignment Model)
        {
            var getCurrentMatter = _courseService.GetAll().Where(x => x.ID.Equals(Model.CoursesId)).First();
            int initialcurrent = Convert.ToInt32(getCurrentMatter.InitialTime);
            int finalciurrent = Convert.ToInt32(getCurrentMatter.FinalTime);
            int currentHour = (finalciurrent - initialcurrent);

            int horas = 0;
            var validateThursday =
                 (from selection in GetAll()
                  join courses in _courseService.GetAll() on selection.CoursesId equals courses.ID
                  where selection.TeachersId.Equals(Model.TeachersId) && courses.Day.Equals("Jueves")
                  select new { Inicial = courses.InitialTime, Final = courses.FinalTime }).ToList();

            foreach (var mondayValidate in validateThursday)
            {
                int initialHour = Convert.ToInt32(mondayValidate.Inicial);
                int finalHour = Convert.ToInt32(mondayValidate.Final);

                int calculateMondayHours = (finalHour - initialHour);
                horas = horas + (calculateMondayHours + currentHour);
                ;

                if (horas >= 8) return false;
                currentHour = 0;

            }

            return true;
        }

        public bool ValidateFriday(MatterAssignment Model)
        {
            var getCurrentMatter = _courseService.GetAll().Where(x => x.ID.Equals(Model.CoursesId)).First();
            int initialcurrent = Convert.ToInt32(getCurrentMatter.InitialTime);
            int finalciurrent = Convert.ToInt32(getCurrentMatter.FinalTime);
            int currentHour = (finalciurrent - initialcurrent);

            int horas = 0;
            var validateFriday =
                 (from selection in GetAll()
                  join courses in _courseService.GetAll() on selection.CoursesId equals courses.ID
                  where selection.TeachersId.Equals(Model.TeachersId) && courses.Day.Equals("Viernes")
                  select new { Inicial = courses.InitialTime, Final = courses.FinalTime }).ToList();

            foreach (var mondayValidate in validateFriday)
            {
                int initialHour = Convert.ToInt32(mondayValidate.Inicial);
                int finalHour = Convert.ToInt32(mondayValidate.Final);

                int calculateMondayHours = (finalHour - initialHour);
                horas = horas + (calculateMondayHours + currentHour);

                if (horas >= 8) return false;
                currentHour = 0;

            }
            return true;
        }

        public bool ValidateSaturday(MatterAssignment Model)
        {
            var getCurrentMatter = _courseService.GetAll().Where(x => x.ID.Equals(Model.CoursesId)).First();
            int initialcurrent = Convert.ToInt32(getCurrentMatter.InitialTime);
            int finalciurrent = Convert.ToInt32(getCurrentMatter.FinalTime);
            int currentHour = (finalciurrent - initialcurrent);

            int horas = 0;
            var validateSaturday =
                 (from selection in GetAll()
                  join courses in _courseService.GetAll() on selection.CoursesId equals courses.ID
                  where selection.TeachersId.Equals(Model.TeachersId) && courses.Day.Equals("Sabados")
                  select new { Inicial = courses.InitialTime, Final = courses.FinalTime }).ToList();

            foreach (var mondayValidate in validateSaturday)
            {
                int initialHour = Convert.ToInt32(mondayValidate.Inicial);
                int finalHour = Convert.ToInt32(mondayValidate.Final);

                int calculateMondayHours = (finalHour - initialHour);
                horas = horas + (calculateMondayHours + currentHour);

                if (horas >= 8) return false;
                currentHour = 0;

            }

            return true;
        }
    }
}
