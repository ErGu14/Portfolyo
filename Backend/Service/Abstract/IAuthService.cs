using Businness.DTOs;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract
{
    public interface IAuthService
    {
        Task<TokenDto> LoginAsync(LoginDto dto);
        Task<bool> ChangePasswordAsync(string userId,ChangePasswordDto dto);
    }
}
