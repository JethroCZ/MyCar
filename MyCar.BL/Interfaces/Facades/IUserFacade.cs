using MyCar.BL.Dto;

namespace MyCar.BL.Interfaces.Facades
{
    public interface IUserFacade
    {
        void Add(UserDto user);

        UserDto[] GetUsers();
    }
}