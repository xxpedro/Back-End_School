using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Red_Social.Model.Models.MatterAssignment;
using Red_Social.Services.Services.MatterAssignent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Red_Social.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatterAssigmentController : ControllerBase
    {
        private readonly IMatterAssigmentService _matterAssigmentService;
        public MatterAssigmentController(IMatterAssigmentService matterAssigmentService)
        {
            _matterAssigmentService = matterAssigmentService;
        }

        [HttpPost]
        public IActionResult Post(MatterAssignment model)
        {
            var data = _matterAssigmentService.AddSelection(model);
            return Ok(data);
        }



        [HttpGet("{studentId:int}")]
        public IActionResult getSelectionMatters(int studentId)
        {
            var data = _matterAssigmentService.getSelectionCourses(studentId);
            return Ok(data);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _matterAssigmentService.Delete(id);
            return Ok();
        }

        [Route("api/[controller]/updateQuota")]
        [HttpPost]
        public IActionResult DeleteQuota(MatterAssignment model)
        {
            _matterAssigmentService.updateSelection(model);
            return Ok();
        }
    }
}
