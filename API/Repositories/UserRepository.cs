using API.Entities;

namespace API.Repositories;

public class UserRepository
{
    private readonly Dictionary<Guid, UserEntity> _data = new();

    public List<UserEntity> FindAll()
    {
        return _data.Values.ToList();
    }

    public UserEntity? FindById(Guid id)
    {
        return _data.GetValueOrDefault(id);
    }

    public UserEntity Save(UserEntity user)
    {
        if (user.Id == Guid.Empty)
        {
            user.Id = Guid.NewGuid();
        }

        _data[user.Id] = user;
        return user;
    }
}
