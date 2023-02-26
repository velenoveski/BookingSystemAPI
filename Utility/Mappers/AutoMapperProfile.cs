using AutoMapper;

namespace BookingSystemApi.Utility.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<Database.Entities.Booking, Services.DTO.Booking>().ReverseMap();
            this.CreateMap<Database.Entities.Resource, Services.DTO.Resource>().ReverseMap();
        }
    }
}
