namespace API.Entities;

public class UserEntity
{
    public UserEntity(string userName)
    {
        Id = Guid.Empty;
        UserName = userName;
    }

    public Guid Id { get; set; }
    public string UserName { get; set; } = null!;
}
