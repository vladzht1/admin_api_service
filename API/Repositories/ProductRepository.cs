using API.Entities;

namespace API.Repositories;

public class ProductRepository
{
    private readonly Dictionary<Guid, ProductEntity> _data = new();

    public List<ProductEntity> FindAll()
    {
        return _data.Values.ToList();
    }

    public ProductEntity? FindById(Guid id)
    {
        return _data.GetValueOrDefault(id);
    }

    public ProductEntity Save(ProductEntity product)
    {
        if (product.Id == Guid.Empty)
        {
            product.Id = Guid.NewGuid();
        }

        _data[product.Id] = product;
        return product;
    }
}
