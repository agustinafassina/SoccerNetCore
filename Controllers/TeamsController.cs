using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using SoccerNetCore.Models;
using SoccerNetCore.Services;

namespace SoccerNetCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        readonly ITeamService _teamService;
        private readonly IMapper _mapper;
        public TeamsController(IMapper mapper, ITeamService teamService)
        {
            _teamService = teamService;
            _mapper = mapper;
        }

        [EnableQuery]
        [HttpGet]
        public ActionResult<IEnumerable<Team>> Get()
        {
            return _teamService.GetList();
        }

        [HttpGet("{id}")]
        public ActionResult<Team> Get(int id)
        {
            return _teamService.Get(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Team request)
        {
            var team = _mapper.Map<Team>(request);
            _teamService.Post(team);
            return Ok();
        }
    }
}
