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
    public class BookingController : Controller
    {
        private readonly IBookingCommandService _bookingCommandService;
        public BookingController(IBookingCommandService bookingCommandService)
        {
            _bookingCommandService = bookingCommandService;
        }

        [HttpGet("{resourceId}/{DateFrom}/{DateTo}")]
        public async Task<ActionResult<Booking>> GetAvailableResourceRequestedPeriod(int resourceId, DateTime DateFrom, DateTime DateTo)
        {
            var response = await _bookingCommandService.GetAvailableResourceRequestedPeriodAsync(resourceId, DateFrom, DateTo);

            if (response == null)
            {
                return StatusCode(404, response);
            }
            return StatusCode(200, response);
        }

        [HttpPost("requestbooking")]
        public async Task<IActionResult> RequestBooking([FromBody][Required] RequestBookingCommand body)
        {
            var response = await _bookingCommandService.RequestBookingAsync(body);
            if (response == null)
            {
                return StatusCode(404, response);
            }
            return StatusCode(200, response);
        }

    }
}
