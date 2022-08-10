using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Podify.Managers;
using Podify.Models;
using Podify.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Podify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private IGuestsManager guestsManager;
        public GuestController(IGuestsManager guestsManager)
        {
            this.guestsManager = guestsManager;
        }


        [HttpGet("get-guests")]
        public async Task<IActionResult> GetGuests()
        {
            try
            {
                var guest = guestsManager.GetGuests().ToList();
                return Ok(guest);
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }

        [HttpGet("get-guest-by-id/{id}")]
        public async Task<IActionResult> GetGuestById([FromRoute] string id)
        {
            try
            {
                var guest = guestsManager.GetGuestById(id);
                return Ok(guest);
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }


        [HttpPost("create-guest")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Create([FromBody] GuestCreationModel model)
        {
            try
            {
                guestsManager.Create(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }

        [HttpPut("update-guest")]   
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Update([FromBody] GuestCreationModel model)
        {
            try
            {
                guestsManager.Update(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }

        [HttpDelete("delete-guest/{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            try
            {
                guestsManager.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }

        [HttpGet("GuestEpisodes/{id}")]
        public async Task<IActionResult> GetGuestEpisodes([FromRoute] string id)
        {
            var res = guestsManager.GetGuestEpisodes(id);
            return Ok(res);
        }


        [HttpGet("OrderGuestsByDescription")]
        [Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetOrderedGuestsByDescription()
        {
            var res = guestsManager.GetGuestsOrderedByDescription();
            return Ok(res);
        }


        [HttpGet("GetNoGuests")]
        public async Task<IActionResult> GetNoGuests()
        {
            var res = guestsManager.GetNumberOfGuests();
            return Ok(res);
        }

        [HttpGet("GetNoGuestTypes")]
        public async Task<IActionResult> GetNoGuestTypes()
        {
            var res = guestsManager.GetNumberOfGuestTypes();
            return Ok(res);
        }
    }
}

