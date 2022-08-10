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
    public class PodcastController : ControllerBase
    {
        private IPodcastsManager podcastsManager;
        public PodcastController(IPodcastsManager podcastsManager)
        {
            this.podcastsManager = podcastsManager;
        }


        [HttpGet("get-podcasts")]
        public async Task<IActionResult> GetPodcasts()
        {
            try
            {
                var podcast = podcastsManager.GetPodcasts().ToList();
                return Ok(podcast);
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }

        [HttpGet("get-podcast-by-id/{id}")]
        public async Task<IActionResult> GetPodcastById([FromRoute] string id)
        {
            try
            {
                var podcast = podcastsManager.GetPodcastById(id);
                return Ok(podcast);
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }


        [HttpPost("create-podcast")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Create([FromBody] PodcastCreationModel model)
        {
            try
            {
                podcastsManager.Create(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }

        [HttpPut("update-podcast")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Update([FromBody] PodcastCreationModel model)
        {
            try
            {
                podcastsManager.Update(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }

        [HttpDelete("delete-podcast/{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            try
            {
                podcastsManager.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }
    }
}
