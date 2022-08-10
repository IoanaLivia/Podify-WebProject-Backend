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
    public class PodcastHostController : ControllerBase
    {
        private IPodcastHostsManager hostsManager;
        public PodcastHostController(IPodcastHostsManager hostsManager)
        {
            this.hostsManager = hostsManager;
        }


        [HttpGet("get-hosts")]
        public async Task<IActionResult> GetPodcastHosts()
        {
            try
            {
                var host = hostsManager.GetPodcastHosts().ToList();
                return Ok(host);
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }

        [HttpGet("get-host-by-id/{id}")]
        public async Task<IActionResult> GetPodcastHostById([FromRoute] string id)
        {
            try
            {
                var host = hostsManager.GetPodcastHostById(id);
                return Ok(host);
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }


        [HttpPost("create-host")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Create([FromBody] PodcastHostCreationModel model)
        {
            try
            {
                hostsManager.Create(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }

        [HttpPut("update-host")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Update([FromBody] PodcastHostCreationModel model)
        {
            try
            {
                hostsManager.Update(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }

        [HttpDelete("delete-host/{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            try
            {
                hostsManager.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }

        [HttpGet("get-join")]
        public async Task<IActionResult> GetJoin()
        {
            try
            {
                var host = hostsManager.Join();
                return Ok(host);
            }
            catch (Exception ex)
            {
                return BadRequest("Exception caught");
            }
        }

    }
}
