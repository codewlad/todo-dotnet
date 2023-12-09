using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.App.Dto.User;

namespace ToDo.App.Interfaces
{
    public interface IUserApplication
    {
        Task CreateUserAsync(CreateUserDTO user);
    }
}
