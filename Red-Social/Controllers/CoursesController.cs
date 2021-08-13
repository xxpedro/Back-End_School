using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Red_Social.Model.Models.Courses;
using Red_Social.Services.Services.CoursesServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Red_Social.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public IActionResult GetCourses() 
        {
            var data =_courseService.GetAll();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Add(Courses model)
        {
            _courseService.Save(model);
            return Ok();
        }

        [HttpGet("{id:int}")]
        public IActionResult getById(int id)
        {
            var data= _courseService.GetById(id);
            return Ok(data);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _courseService.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult update(int id,Courses model)
        {
            model.ID = id;
            _courseService.Update(id,model);
            return Ok();
        }
    }
}
