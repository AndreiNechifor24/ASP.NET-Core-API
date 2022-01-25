using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ParkyAPI.Model;
using ParkyAPI.Repository.IRepositories;

namespace ParkyAPI.Controllers
{
    //[Route("api/[controller]/[action]")]
    [Route("api/v{version:apiVersion}/nationalparks")]
    //[ApiVersion("1.0")]
    [ApiController]
    //[ApiExplorerSettings(GroupName = "ParkyAPI - National Park")]
    public class NationalParksController : ControllerBase
    {
        private INationalParkRepository _repo;

        public NationalParksController(INationalParkRepository repository)
        {
            _repo = repository;
        }

        [HttpGet]
        [Authorize]
        //[ProducesResponseType()]
        public IActionResult Index()
        {
            var objList = _repo.GetNationalParks();             
            return Ok(objList);
        }

        [HttpPost]
        public IActionResult CreateNationalPark([FromBody] NationalPark model)
        {
            //  check for null

            // check for duplicate => 40

            // check for object structure => 500

            // eventually create obj

            if (model == null)
            {
                return BadRequest(ModelState);
            }

            if (_repo.NationalParkExists(model.Name))
            {
                ModelState.AddModelError("", "National Park already exists");
                return StatusCode(409, ModelState);
            }

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please check your input fields again");
                return BadRequest(ModelState);
            }

            if (!_repo.CreateNationalPark(model))
            {
                ModelState.AddModelError("", "Something went wrong while saving your national park");
                return StatusCode(500, ModelState);
            }

            //return Ok();
            return CreatedAtRoute("GetNationalPark", new
            {
                Version = HttpContext.GetRequestedApiVersion().ToString(),
                nationalParkId = model.Id
            },
                model);

        }

        [HttpPatch("{nationalParkId:int}", Name = "UpdateNationalPark")]
        public IActionResult UpdateNationalPark(int Id, [FromBody] NationalPark updatedModel)
        {
            if (updatedModel.Id != Id || updatedModel == null)
            {
                return BadRequest(ModelState);
            }

            if (_repo.UpdateNationalPark(updatedModel))
            {
                ModelState.AddModelError("", "Something went wrong while updating the record");
                return StatusCode(500, ModelState);
            }

            // ViewBag.Message = "Successfully updated the record";
            return NoContent();
        }

        [HttpDelete("{nationalParkId:int}", Name = "DeleteNationalPark")]
        public IActionResult DeleteNationalPark(int parkId)
        {
            if (!_repo.NationalParkExists(parkId))
            {
                return NotFound();
            }

            if (!_repo.DeleteNationalPark(parkId))
            {
                ModelState.AddModelError("", "Something went wrong. That's all we know");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
