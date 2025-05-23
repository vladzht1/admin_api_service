using API.Dtos;
using API.Entities;

namespace API.Services;

public interface IUserService
{
    List<UserEntity> FindAllUsers();
    UserEntity FindById(Guid id);
    UserEntity CreateUser(UserCreateDto user);
}
