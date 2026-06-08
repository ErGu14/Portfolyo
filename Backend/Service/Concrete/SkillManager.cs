using Data.Abstract;
using Entity;
using Entity.DTOs;
using Service.Abstract;

namespace Service.Concrete
{
    public class SkillManager : ISkillService
    {
        private readonly IGenericRepository<Skill> _repository;

        public SkillManager(IGenericRepository<Skill> repository)
        {
            _repository = repository;
        }

        public async Task<SkillDto> AddAsync(SkillCreateDto dto)
        {
            var entity = new Skill
            {
                Title = dto.Title,
                IconPath = dto.IconPath,
                Items = dto.Items,
                IsActive = dto.IsActive
            };
            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
            return new SkillDto { Id = entity.Id, Title = entity.Title, IconPath = entity.IconPath, Items = entity.Items, IsActive = entity.IsActive };
        }

        public async Task DeleteAsync(int id)
        {
            _repository.Delete(id);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<SkillDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(e => new SkillDto
            {
                Id = e.Id,
                Title = e.Title,
                IconPath = e.IconPath,
                Items = e.Items,
                IsActive = e.IsActive
            });
        }

        public async Task<SkillDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;
            return new SkillDto
            {
                Id = entity.Id,
                Title = entity.Title,
                IconPath = entity.IconPath,
                Items = entity.Items,
                IsActive = entity.IsActive
            };
        }

        public async Task UpdateAsync(SkillUpdateDto dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity != null)
            {
                entity.Title = dto.Title;
                entity.IconPath = dto.IconPath;
                entity.Items = dto.Items;
                entity.IsActive = dto.IsActive;
                _repository.UpdateAsync(entity);
                await _repository.SaveAsync();
            }
        }
    }
}
