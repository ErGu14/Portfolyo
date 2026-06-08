using Entity.DTOs;

namespace Service.Abstract
{
    public interface IFeatureService
    {
        Task<IEnumerable<FeatureDto>> GetAllAsync();
        Task<FeatureDto> GetByIdAsync(int id);
        Task<FeatureDto> AddAsync(FeatureCreateDto dto);
        Task UpdateAsync(FeatureUpdateDto dto);
        Task DeleteAsync(int id);
    }
}
