using BookingSystemApi.Services.DTO;
using System.ComponentModel.DataAnnotations;

namespace BookingSystemApi.Services.Commands
{
    public class RequestBookingCommand
    {
        [Required]
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int BookedQuantity { get; set; }
        public int ResourceId { get; set; }
    }
}
