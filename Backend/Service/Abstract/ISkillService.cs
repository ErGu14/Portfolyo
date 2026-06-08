using Entity.DTOs;

namespace Service.Abstract
{
    public interface ISkillService
    {
        Task<IEnumerable<SkillDto>> GetAllAsync();
        Task<SkillDto> GetByIdAsync(int id);
        Task<SkillDto> AddAsync(SkillCreateDto dto);
        Task UpdateAsync(SkillUpdateDto dto);
        Task DeleteAsync(int id);
    }
}
