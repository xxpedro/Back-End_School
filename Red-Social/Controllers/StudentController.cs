using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Red_Social.Model.Models.Students;
using Red_Social.Services.Services.StudentServices;
using Red_Social.Services.Services.TeacherService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Red_Social.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IStudentServices _studentServices;
        public StudentController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }

        [HttpGet("{enrrollment}")]
        public IActionResult getByEnrollment(string enrrollment) 
        {
            var UserData = _studentServices.getCoursesByEnrollment(enrrollment);
            if (UserData is null) return NotFound();
            return Ok(UserData);
        }

        [HttpGet]
        public IActionResult Get() 
        {
            var studentData = _studentServices.GetAll();
            return Ok(studentData);
        }

        [HttpPost]
        public IActionResult Add(Students model)
        {
            _studentServices.Save(model);
            return Ok();
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var data=_studentServices.GetById(id);
            return Ok(data);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _studentServices.Delete(id);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Students Model)
        {
            Model.ID = id;
            _studentServices.Update(id, Model);
            return Ok();
        }

    }
}
