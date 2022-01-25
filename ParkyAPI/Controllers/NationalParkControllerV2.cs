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
    [Route("api/v{version:apiVersion}/nationalparks")]
    [ApiVersion("2.0")]
    [ApiController]
    //[ApiExplorerSettings(GroupName = "ParkyAPI - National Park")]
    public class NationalParksV2Controller : ControllerBase
    {
        private INationalParkRepository _repo;

        public NationalParksV2Controller(INationalParkRepository repository)
        {
            _repo = repository;
        }

        [HttpGet("{dummyStringParam:required}", Name = "Dummy String param")]
        public IActionResult DummyAdditionMethod()
        {
            return Ok();
        }
    }
}
