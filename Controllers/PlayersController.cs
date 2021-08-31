using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoccerNetCore.Models;
using SoccerNetCore.Services;

namespace SoccerNetCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : ControllerBase
    {
        readonly IPlayerService _playerService;
        private readonly IMapper _mapper;
        public PlayersController(IPlayerService playersService, IMapper mapper)
        {
            _playerService = playersService;
            _mapper = mapper;
        }

        //Decorator for Odata - For example: players?$filter=contains(name, 'Lionel')
        [EnableQuery]
        [HttpGet]
        public ActionResult<IEnumerable<Player>> Get()
        {
            return _playerService.GetList();
        }

        [HttpGet("{id}")]
        public ActionResult<Player> Get(int id)
        {
            return _playerService.Get(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Player request, IFormFile FileLogo)
        {
            var bodyPlayer = _mapper.Map<Player>(request);
            bodyPlayer.Logo = FileLogo.FileName;
            var streamFile = new MemoryStream();
            FileLogo.CopyTo(streamFile);

            _playerService.Post(bodyPlayer, streamFile);
            return Ok();
        }

        [HttpDelete("{playerId}")]
        public async Task<IActionResult> Delete([FromRoute] int playerId)
        {
            try
            {
                _playerService.Delete(playerId);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{playerId}")]
        public async Task<IActionResult> Put([FromRoute] int playerId, [FromForm] Player request)
        {
            try
            {
                var bodyPlayer = _mapper.Map<Player>(request);
                _playerService.Update(playerId, bodyPlayer);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("sendemail/{id}")]
        public ActionResult<Player> GetSendEmail(int id)
        {
            _playerService.GetSendEmail(id);
            return Ok();
        }
    }
}
