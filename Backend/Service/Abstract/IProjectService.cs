using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract
{
    public interface IProjectService
    {
        Task<List<ProjectListDto>> GetAllAsync();
        Task<ProjectListDto> GetByIdAsync(int id);
        Task<bool> AddAsync(ProjectCreateDto projectCreateDto);
        Task<bool> UpdateAsync(ProjectUpdateDto projectUpdateDto);
        Task<bool> DeleteAsync(int id);
    }
}
