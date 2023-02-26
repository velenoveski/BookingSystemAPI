
using BookingSystemApi.Services.Commands;
using BookingSystemApi.Services.DTO;

namespace BookingSystemApi.Repository.Interfaces
{
    public interface IResourceCommandService
    {
        Task<List<Resource>> GetAllResourcesAsync();
        Task<Resource> GetResourceByIdAsync(int id);
        Task<Resource> GetAvailableResourceQuantityAsync(int id, int quantity);
        Task<Resource> AddResourcesAsync(AddResourcesCommand body);
    }
}
