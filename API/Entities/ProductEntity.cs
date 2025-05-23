namespace API.Entities;

public class ProductEntity
{
    public ProductEntity(string name, string description, UserEntity creator)
    {
        Id = Guid.Empty;
        Name = name;
        Description = description;
        Creator = creator;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public UserEntity Creator { get; set; }
}
