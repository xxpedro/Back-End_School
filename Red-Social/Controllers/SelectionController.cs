using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Red_Social.Model.Models.MatterSelection;
using Red_Social.Services.Services.SelectionCoursesServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Red_Social.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelectionController : ControllerBase
    {
        private readonly ISelectionCoursesServices _selectionCoursesServices;
        public SelectionController(ISelectionCoursesServices selectionCoursesServices)
        {
            _selectionCoursesServices = selectionCoursesServices;
        }

        [HttpPost]
        public IActionResult Post(MatterSelection model)
        {
            var data = _selectionCoursesServices.AddSelection(model);
            return Ok(data);
        }

        [HttpGet("{studentId:int}")]
        public IActionResult getSelectionMatters(int studentId)
        {
            var data = _selectionCoursesServices.getSelectionCourses(studentId);
            return Ok(data);
        }

        [Route("api/[controller]/updateQuota")]
        [HttpPost]
        public IActionResult DeleteQuota(MatterSelection model)
        {
            _selectionCoursesServices.updateSelection(model);
            return Ok();
        }
    }
}
