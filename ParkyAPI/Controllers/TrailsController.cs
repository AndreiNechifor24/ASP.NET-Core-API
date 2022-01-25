using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkyAPI.Model;
using ParkyAPI.Repository.IRepositories;

namespace ParkyAPI.Controllers
{
    //[Route("api/[controller]/[action]")]
    [Route("api/v{version:apiVersion}/trails")]
    [ApiController]
    //[ApiExplorerSettings(GroupName = "ParkyAPI - Trails")]
    public class TrailsController : ControllerBase
    {
        private ITrailRepository _repo;

        public TrailsController(ITrailRepository repository)
        {
            _repo = repository;
        }

        [HttpGet]
        //[ProducesResponseType()]
        public IActionResult Index()
        {
            var objList = _repo.GetTrails();             
            return Ok(objList);
        }

        [HttpPost]

        public IActionResult CreateTrail([FromBody] Trail model)
        {
            //  check for null

            // check for duplicate => 40

            // check for object structure => 500

            // eventually create obj

            if (model == null)
            {
                return BadRequest(ModelState);
            }

            if (_repo.TrailExists(model.Name))
            {
                ModelState.AddModelError("", "Trail already exists");
                return StatusCode(409, ModelState);
            }

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please check your input fields again");
                return BadRequest(ModelState);
            }

            if (!_repo.CreateTrail(model))
            {
                ModelState.AddModelError("", "Something went wrong while saving your Trail");
                return StatusCode(500, ModelState);
            }

            return Ok();

        }

        [HttpPatch("{TrailId:int}", Name = "UpdateTrail")]
        public IActionResult UpdateTrail(int Id, [FromBody] Trail updatedModel)
        {
            if (updatedModel.Id != Id || updatedModel == null)
            {
                return BadRequest(ModelState);
            }

            if (_repo.UpdateTrail(updatedModel))
            {
                ModelState.AddModelError("", "Something went wrong while updating the record");
                return StatusCode(500, ModelState);
            }

            //ViewBag.Message = "Successfully updated the record";
            return NoContent();
        }

        [HttpDelete("{TrailId:int}", Name = "DeleteTrail")]
        public IActionResult DeleteTrail(int parkId)
        {
            if (!_repo.TrailExists(parkId))
            {
                return NotFound();
            }

            if (!_repo.DeleteTrail(parkId))
            {
                ModelState.AddModelError("", "Something went wrong. That's all we know");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
