using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.App.Dto.User;
using ToDo.Domain.Models;

namespace ToDo.App.Interfaces
{
    public interface IUserApplication
    {
        Task CreateUserAsync(CreateUserDTO user);
        Task UpdateUserAsync(UpdateUserDTO user);

        Task<IEnumerable<UserResponseDTO>> GetAllUsersAsync();
        /*
        Task DeleteUserAsync(int userId);
        
        Task<UserModel> GetUserByIdAsync(int userId);
        */
    }
}
