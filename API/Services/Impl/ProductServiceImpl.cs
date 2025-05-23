using API.Dtos;
using API.Entities;
using API.Repositories;

namespace API.Services.Impl;

public class ProductServiceImpl : IProductService
{
    private readonly ProductRepository _productRepository;
    private readonly UserRepository _userRepository;

    public ProductServiceImpl(ProductRepository productRepository, UserRepository userRepository)
    {
        _productRepository = productRepository;
        _userRepository = userRepository;
    }

    public List<ProductEntity> FindAllProducts()
    {
        return _productRepository.FindAll();
    }

    public ProductEntity FindById(Guid id)
    {
        return _productRepository.FindById(id)
                ?? throw new Exception("Product was not found");
    }

    public ProductEntity CreateProduct(ProductCreateDto productDto)
    {
        UserEntity user = _userRepository.FindById(productDto.CreatorId)
                ?? throw new Exception("User was not found");

        var product = new ProductEntity(productDto.Name, productDto.Description, user);

        _productRepository.Save(product);
        return product;
    }
}
