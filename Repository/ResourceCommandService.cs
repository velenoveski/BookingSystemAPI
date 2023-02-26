using AutoMapper;
using BookingSystemApi.Database.Data;
using BookingSystemApi.Repository.Interfaces;
using BookingSystemApi.Services.Commands;
using BookingSystemApi.Services.DTO;
using Microsoft.EntityFrameworkCore;

namespace BookingSystemApi.Repository
{
    public class ResourceCommandService : IResourceCommandService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ResourceCommandService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Resource>> GetAllResourcesAsync()
        {
            var resources = await _context.Resource.ToListAsync();
            return _mapper.Map<List<Resource>>(resources);
        }

        public async Task<Resource> GetResourceByIdAsync(int id)
        {
            var resource = await _context.Resource.Where(a => a.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<Resource>(resource);
        }

        public async Task<Resource> GetAvailableResourceQuantityAsync(int id, int quantity)
        {
            var resourceQuantity = await _context.Resource.Where(a => a.Id == id && a.Quantity == quantity).FirstOrDefaultAsync();
            return _mapper.Map<Resource>(resourceQuantity);
        }

        public async Task<Resource> AddResourcesAsync(AddResourcesCommand body)
        {
            BookingSystemApi.Database.Entities.Resource resourceEntity = new BookingSystemApi.Database.Entities.Resource();

            resourceEntity.Name = body.Name;
            resourceEntity.Quantity = body.Quantity;

            _context.Resource.Add(resourceEntity);
            await _context.SaveChangesAsync();

            return _mapper.Map<Resource>(resourceEntity);
        }
    }
}
