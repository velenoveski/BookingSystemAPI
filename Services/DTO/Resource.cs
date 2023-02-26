using System.Runtime.Serialization;

namespace BookingSystemApi.Services.DTO
{
    public class Resource
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
