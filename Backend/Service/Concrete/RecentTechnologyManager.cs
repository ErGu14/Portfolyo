using Data.Abstract;
using Entity;
using Entity.DTOs;
using Service.Abstract;

namespace Service.Concrete
{
    public class RecentTechnologyManager : IRecentTechnologyService
    {
        private readonly IGenericRepository<RecentTechnology> _repository;

        public RecentTechnologyManager(IGenericRepository<RecentTechnology> repository)
        {
            _repository = repository;
        }

        public async Task<RecentTechnologyDto> AddAsync(RecentTechnologyCreateDto dto)
        {
            var entity = new RecentTechnology
            {
                Name = dto.Name,
                IsActive = dto.IsActive
            };
            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
            return new RecentTechnologyDto { Id = entity.Id, Name = entity.Name, IsActive = entity.IsActive };
        }

        public async Task DeleteAsync(int id)
        {
            _repository.Delete(id);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<RecentTechnologyDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(e => new RecentTechnologyDto
            {
                Id = e.Id,
                Name = e.Name,
                IsActive = e.IsActive
            });
        }

        public async Task<RecentTechnologyDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;
            return new RecentTechnologyDto
            {
                Id = entity.Id,
                Name = entity.Name,
                IsActive = entity.IsActive
            };
        }

        public async Task UpdateAsync(RecentTechnologyUpdateDto dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity != null)
            {
                entity.Name = dto.Name;
                entity.IsActive = dto.IsActive;
                _repository.UpdateAsync(entity);
                await _repository.SaveAsync();
            }
        }
    }
}
