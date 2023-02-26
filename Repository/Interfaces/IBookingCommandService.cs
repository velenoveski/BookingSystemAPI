using BookingSystemApi.Services.Commands;
using BookingSystemApi.Services.DTO;
using System;

namespace BookingSystemApi.Repository.Interfaces
{
    public interface IBookingCommandService
    {
        Task<Booking> GetAvailableResourceRequestedPeriodAsync(int resourceId, DateTime DateFrom, DateTime DateTo);
        Task<Booking> RequestBookingAsync(RequestBookingCommand body);
    }
}
