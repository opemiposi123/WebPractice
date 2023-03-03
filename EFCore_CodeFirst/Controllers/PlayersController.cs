using EFCore_CodeFirst.Db.Models;
using EFCore_CodeFirst.Dto;
using EFCore_CodeFirst.Dto.Players;
using EFCore_CodeFirst.Interface;
using EFCore_CodeFirst.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EFCore_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpPost("add_player")]
        public async Task<IActionResult> PostPlayerAsync([FromBody] CreatePlayerRequest playerRequest)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
            await _playerService.CreatePlayerAsync(playerRequest);
            return Ok("Record has been added successfully.");
        }

        [HttpGet("getAllPlayer")]
        public async Task<IActionResult> GetPlayersAsync([FromQuery] UrlQueryParameters urlQueryParameters)
        {
            var player = await _playerService.
            GetPlayersAsync(urlQueryParameters);
            //removed null validation check for brevity
            return Ok(player);
        }

        [HttpGet("{id}/detail")]
        public async Task<IActionResult> GetPlayerDetailAsync(int id)
        {
            var player = await _playerService.GetPlayerDetailAsync(id);
            //removed null validation check for brevity
            return Ok(player);
        }

        [HttpPut("{id}/update_player")]
        public async Task<IActionResult> PutPlayerAsync(int id, [FromBody] UpdatePlayerRequest playerRequest)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
            var isUpdated = await _playerService.UpdatePlayerAsync(id, playerRequest);
            if (!isUpdated)
            {
                return NotFound($"PlayerId {id} not found.");
            }
            return Ok("Record has been updated successfully.");
        }

        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> DeletePlayerAsync(int id)
        {
            var isDeleted = await _playerService.DeletePlayerAsync(id);
            if (!isDeleted)
            {
                return NotFound($"PlayerId { id } not found.");
            }
            return Ok("Record has been deleted successfully.");
        }
    }
}
