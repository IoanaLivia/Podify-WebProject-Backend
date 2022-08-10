using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Podify.Managers;
using Podify.Models;
using Podify.Entities;

namespace Podify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodeController : ControllerBase
    {
        private IEpisodesManager episodesManager;
        public EpisodeController(IEpisodesManager episodesManager)
        {
            this.episodesManager = episodesManager;
        }


        [HttpGet("get-episodes")]
        public async Task<IActionResult> GetEpisodes()
        {
            try
            {
                var episode = episodesManager.GetEpisodes().ToList();
                return Ok(episode);
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }

        [HttpGet("get-episode-by-id/{id}")]
        public async Task<IActionResult> GetEpisodeById([FromRoute] string id)
        {
            try
            {
                var episode = episodesManager.GetEpisodeById(id);
                return Ok(episode);
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }


        [HttpPost("create-episode")]
        public async Task<IActionResult> Create([FromBody] EpisodeCreationModel model)
        {
            try
            {
                episodesManager.Create(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }

        [HttpPut("update-episode")]
        public async Task<IActionResult> Update([FromBody] EpisodeCreationModel model)
        {
            try
            {
                episodesManager.Update(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }

        [HttpDelete("delete-episode/{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            try
            {
                episodesManager.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }

        [HttpGet("EpisodeGuests/{id}")]
        public async Task<IActionResult> GetEpisodeGuests(string id)
        {
            var res = episodesManager.GetGuestEpisodes(id);
            return Ok(res);
        }
    }

}

