using Data.Abstract;
using Entity;
using Entity.DTOs;
using Service.Abstract;

namespace Service.Concrete
{
    public class FeatureManager : IFeatureService
    {
        private readonly IGenericRepository<Feature> _repository;

        public FeatureManager(IGenericRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<FeatureDto> AddAsync(FeatureCreateDto dto)
        {
            var entity = new Feature
            {
                Title = dto.Title,
                Description = dto.Description,
                IconPath = dto.IconPath,
                IsActive = dto.IsActive
            };
            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
            return new FeatureDto { Id = entity.Id, Title = entity.Title, Description = entity.Description, IconPath = entity.IconPath, IsActive = entity.IsActive };
        }

        public async Task DeleteAsync(int id)
        {
            _repository.Delete(id);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<FeatureDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(e => new FeatureDto
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description,
                IconPath = e.IconPath,
                IsActive = e.IsActive
            });
        }

        public async Task<FeatureDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;
            return new FeatureDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                IconPath = entity.IconPath,
                IsActive = entity.IsActive
            };
        }

        public async Task UpdateAsync(FeatureUpdateDto dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity != null)
            {
                entity.Title = dto.Title;
                entity.Description = dto.Description;
                entity.IconPath = dto.IconPath;
                entity.IsActive = dto.IsActive;
                _repository.UpdateAsync(entity);
                await _repository.SaveAsync();
            }
        }
    }
}
