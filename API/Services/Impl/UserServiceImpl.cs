using API.Dtos;
using API.Entities;
using API.Repositories;

namespace API.Services.Impl;

public class UserServiceImpl : IUserService
{
    private readonly UserRepository _userRepository;

    public UserServiceImpl(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public List<UserEntity> FindAllUsers()
    {
        return _userRepository.FindAll();
    }

    public UserEntity FindById(Guid id)
    {
        return _userRepository.FindById(id) ?? throw new Exception("User was not found");
    }

    public UserEntity CreateUser(UserCreateDto userDto)
    {
        var user = new UserEntity(userDto.Name);
        _userRepository.Save(user);

        return user;
    }
}
