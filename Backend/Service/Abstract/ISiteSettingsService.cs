using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract
{
    public interface ISiteSettingsService
    {
        
        Task<List<SiteSettingsDto>> GetAllAsync();
       
        Task<SiteSettingsDto> GetByIdAsync(int id);
        
        Task<bool> AddAsync(SiteSettingsUpdateDto siteSettingsCreateDto);
        
        Task<bool> UpdateAsync(SiteSettingsUpdateDto siteSettingsUpdateDto);
        
        Task<bool> DeleteAsync(int id);
    }
}
