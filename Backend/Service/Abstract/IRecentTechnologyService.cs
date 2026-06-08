using Entity.DTOs;

namespace Service.Abstract
{
    public interface IRecentTechnologyService
    {
        Task<IEnumerable<RecentTechnologyDto>> GetAllAsync();
        Task<RecentTechnologyDto> GetByIdAsync(int id);
        Task<RecentTechnologyDto> AddAsync(RecentTechnologyCreateDto dto);
        Task UpdateAsync(RecentTechnologyUpdateDto dto);
        Task DeleteAsync(int id);
    }
}
