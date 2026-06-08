using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract
{
    public interface ISocialMediaService
    {
        
        Task<List<SocialMediaListDto>> GetAllAsync();
        
        Task<SocialMediaListDto> GetByIdAsync(int id);
        
        Task<bool> AddAsync(SocialMediaCreateDto socialMediaCreateDto);
        
        Task<bool> UpdateAsync(SocialMediaUpdateDto socialMediaUpdateDto);
        
        Task<bool> DeleteAsync(int id);
    }
}
