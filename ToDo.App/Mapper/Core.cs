using AutoMapper;
using ToDo.App.Dto.User;
using ToDo.Domain.Models;

namespace ToDo.App.Mapper
{
    public class Core : Profile
    {
        public Core()
        {
            UserMap();
        }

        private void UserMap()
        {
            CreateMap<CreateUserDTO, UserModel>();

            CreateMap<UserModel, UserResponseDTO>();
        }
    }
}
