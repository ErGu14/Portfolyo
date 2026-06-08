using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract
{
    public interface ICertificateService
    {
        Task<List<CertificateListDto>> GetAllAsync();
        Task<CertificateListDto> GetByIdAsync(int id);
        Task<bool> AddAsync(CertificateCreateDto dto);
        Task<bool> UpdateAsync(CertificateUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
