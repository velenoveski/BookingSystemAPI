using AutoMapper;
using BookingSystemApi.Database.Data;
using BookingSystemApi.Repository.Interfaces;
using BookingSystemApi.Services.Commands;
using BookingSystemApi.Services.DTO;
using Microsoft.EntityFrameworkCore;

namespace BookingSystemApi.Repository
{
    public class BookingCommandService : IBookingCommandService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public BookingCommandService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Booking> GetAvailableResourceRequestedPeriodAsync(int resourceId, DateTime DateFrom, DateTime DateTo)
        {
            string dateFrom = DateFrom.ToString("yyyy-MM-dd 00:00:00");
            DateTime _DateFrom = Convert.ToDateTime(dateFrom);
            string dateTo = DateTo.ToString("yyyy-MM-dd 23:59:59");
            DateTime _DateTo = Convert.ToDateTime(dateTo);

            var availableResource = await _context.Booking.Where(a => a.ResourceId == resourceId && a.DateFrom >= _DateFrom && a.DateTo <= _DateTo).FirstOrDefaultAsync();
            return _mapper.Map<Booking>(availableResource);
        }

        public async Task<Booking> RequestBookingAsync(RequestBookingCommand body)
        {
            BookingSystemApi.Database.Entities.Booking? bookingEntity = new BookingSystemApi.Database.Entities.Booking();

            string dateFrom = body.DateFrom.ToString("yyyy-MM-dd 00:00:00");
            body.DateFrom = Convert.ToDateTime(dateFrom);
            string dateTo = body.DateTo.ToString("yyyy-MM-dd 23:59:59");
            body.DateTo = Convert.ToDateTime(dateTo);

            var availableResource = _context.Booking.Where(a => a.ResourceId == body.ResourceId && a.DateFrom == body.DateFrom && a.DateTo == body.DateTo).FirstOrDefault();

            if (availableResource == null)
            {
                bookingEntity.DateFrom = body.DateFrom;
                bookingEntity.DateTo = body.DateTo;
                bookingEntity.BookedQuantity = body.BookedQuantity;
                bookingEntity.ResourceId = body.ResourceId;

                _context.Booking.Add(bookingEntity);
                await _context.SaveChangesAsync();
            }
            else
            {
                bookingEntity = null;
            }

            return _mapper.Map<Booking>(bookingEntity);
        }
    }
}
