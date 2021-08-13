using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Red_Social.Model.Models.Teachers;
using Red_Social.Services;
using Red_Social.Services.Services.TeacherService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Red_Social.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _TeacherService;
        public TeacherController(ITeacherService TeacherService)
        {
            _TeacherService = TeacherService;
        }

        [HttpPost]
        public IActionResult Add(Teachers model)
        {
            _TeacherService.Save(model);
            return Ok("Exito");
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Teachers model)
        {
            model.ID = id;
            _TeacherService.Update(id,model);
            return Ok("Exito");
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var data= _TeacherService.GetAll();
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _TeacherService.Delete(id);
            return Ok("Deleted");
        }

        [HttpGet("{enroll}")]
        public IActionResult getByEnroll(string enroll)
        {
            var data = _TeacherService.GetByEnroll(enroll);
            if (data is null) return NotFound();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data = _TeacherService.GetById(id);
            if (data is null) return NotFound();
            return Ok(data);
        }
    }
}
