using FlashWish.Core.DTOs;
using FlashWish.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashWish.Core.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        UserDTO? GetUserById(int id);
        UserDTO AddUser(UserDTO user);
        UserDTO? UpdateUser(int id, UserDTO user);
        bool DeleteUser(int id);
    }
}
