using Microsoft.AspNetCore.Mvc;

using API.Services;
using API.Dtos;

namespace API.Controllers;

[Controller]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public IActionResult FindAll()
    {
        return Ok(_productService.FindAllProducts());
    }

    [HttpGet("{id}")]
    public IActionResult FindById(Guid id)
    {
        return Ok(_productService.FindById(id));
    }

    [HttpPost]
    public IActionResult Create([FromBody] ProductCreateDto userDto)
    {
        var result = _productService.CreateProduct(userDto);
        return Created($"/api/products/{result.Id}", result);
    }
}
