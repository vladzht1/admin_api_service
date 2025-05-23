using API.Dtos;
using API.Entities;

namespace API.Services;

public interface IProductService
{
    List<ProductEntity> FindAllProducts();
    ProductEntity FindById(Guid id);
    ProductEntity CreateProduct(ProductCreateDto productDto);
}
