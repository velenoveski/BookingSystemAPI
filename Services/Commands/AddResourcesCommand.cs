using BookingSystemApi.Services.DTO;
using System.ComponentModel.DataAnnotations;

namespace BookingSystemApi.Services.Commands
{
    public class AddResourcesCommand
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
