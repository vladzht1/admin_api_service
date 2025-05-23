using Microsoft.AspNetCore.Mvc;

using API.Services;
using API.Dtos;

namespace API.Controllers;

[Controller]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult FindAll()
    {
        return Ok(_userService.FindAllUsers());
    }

    [HttpGet("{id}")]
    public IActionResult FindById(Guid id)
    {
        return Ok(_userService.FindById(id));
    }

    [HttpPost]
    public IActionResult Create([FromBody] UserCreateDto userDto)
    {
        var result = _userService.CreateUser(userDto);
        return Created($"/api/users/{result.Id}", result);
    }
}
