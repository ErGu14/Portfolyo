using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract
{
    public interface IMessageService
    {
        Task<List<MessageListDto>> GetAllAsync();
        Task<MessageListDto> GetByIdAsync(int id);
        Task<bool> AddAsync(MessageCreateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
