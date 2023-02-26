using BookingSystemApi.Repository.Interfaces;
using BookingSystemApi.Services.Commands;
using BookingSystemApi.Services.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookingSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : Controller
    {
        private readonly IResourceCommandService _resourceCommandService;
        public ResourceController(IResourceCommandService resourceCommandService)
        {
            _resourceCommandService = resourceCommandService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Resource>>> GetAllResources()
        {
            var response = await _resourceCommandService.GetAllResourcesAsync();
            if (response == null)
            {
                return StatusCode(404, response);
            }
            return StatusCode(200, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Resource>> GetResourceById(int id)
        {
            var response = await _resourceCommandService.GetResourceByIdAsync(id);

            if (response == null)
            {
                return StatusCode(404, response);
            }
            return StatusCode(200, response);
        }

        [HttpGet("{id}/{quantity}")]
        public async Task<ActionResult<Resource>> GetAvailableResourceQuantity(int id, int quantity)
        {
            var response = await _resourceCommandService.GetAvailableResourceQuantityAsync(id, quantity);

            if (response == null)
            {
                return StatusCode(404, response);
            }
            return StatusCode(200, response);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddResources([FromBody][Required] AddResourcesCommand body)
        {
            var response = await _resourceCommandService.AddResourcesAsync(body);
            if (response == null)
            {
                return StatusCode(404, response);
            }
            return StatusCode(200, response);
        }

    }
}
